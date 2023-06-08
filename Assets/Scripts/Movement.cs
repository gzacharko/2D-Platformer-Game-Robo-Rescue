using UnityEngine;

//Aaron Youch
//Handles player movement and jumping.
public class Movement : MonoBehaviour
{
    [SerializeField]private KeyCode jump = KeyCode.W;
    [SerializeField]private KeyCode left = KeyCode.A;
    [SerializeField]private KeyCode right = KeyCode.D;
    [SerializeField]private KeyCode down = KeyCode.S;
    [SerializeField]private float maxVelocity = 1;
    [Range(100f,1000f)][SerializeField]private float jumpForce = 10;
    [SerializeField]private LayerMask mask;
    [SerializeField]private AudioSource jumpSound;
    private Rigidbody2D body;
    private bool grounded;
    private bool jumpRequest;
    private Animator animator;
    private SpriteRenderer sprite;
    private bool allowJump;
    private bool isLeft, isRight;
    
    //Get components and set initial values.
    void Start() {
        body = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        sprite = gameObject.GetComponent<SpriteRenderer>();
        grounded = true;
        jumpRequest = true;
        allowJump = true;
        isLeft = false;
        isRight = false;
    }

    //Handles key pressing and movement accordingly
    void Update()
    {
        if(Input.GetKeyDown(jump) && grounded && allowJump) { //jump
            jumpRequest = true;
            //animator.SetBool("isJumping", true);
        }
        else if(!allowJump) { //ladder
            if(Input.GetKeyDown(jump)) {
                body.velocity = new Vector2(body.velocity.x, maxVelocity);
            }
            else if(Input.GetKeyDown(down)) {
                body.velocity = new Vector2(body.velocity.x, -maxVelocity);
            }
        }

        if(Input.GetKey(left)) { //left
            isLeft = true;
            isRight = false;
        }
        else if (Input.GetKey(right)) { //right
            isRight = true;
            isLeft = false;
        }
        else { //Stop player
            isLeft = false; 
            isRight = false;        
        }
        /*else if(Input.GetKeyUp(right)) {
            isRight = false;
        }*/
    }


    //Handle our jump requests by applying the jump force if we are on the ground.
    void FixedUpdate()
    {
        if(isLeft) { //left
            body.velocity = new Vector2(-maxVelocity, body.velocity.y);
            sprite.flipX = true;
            gameObject.transform.GetChild(0).transform.localRotation = new Quaternion(0, 180, 0, 1);
            gameObject.transform.GetChild(0).transform.localPosition = new Vector2(-.55f, .183f);
        }
        else if (isRight) { //right
            body.velocity = new Vector2(maxVelocity, body.velocity.y);
            sprite.flipX = false;
            gameObject.transform.GetChild(0).transform.localRotation = new Quaternion(0, 0, 0, 1);
            gameObject.transform.GetChild(0).transform.localPosition = new Vector2(.55f, .183f);
        }
        else { //Stop player
            body.velocity = new Vector2(0, body.velocity.y);
        }
        animator.SetFloat("speed", Mathf.Abs(body.velocity.x));
        
        if(jumpRequest) {
            body.AddForce(new Vector2(0, jumpForce));
            jumpRequest = false;
            grounded = false;
        }
        else {
            float rayDistance = .02f;
            float castWidth = gameObject.GetComponent<BoxCollider2D>().size.x / 2;
            Vector2 rayStartRight = new Vector2(gameObject.transform.position.x + castWidth, gameObject.transform.position.y - GetComponent<BoxCollider2D>().size.y * .5f);
            //Vector2 rayStart = (Vector2)gameObject.transform.position + Vector2.down * GetComponent<BoxCollider2D>().size.y * .5f;
            Vector2 rayStartLeft = new Vector2(gameObject.transform.position.x - castWidth, gameObject.transform.position.y - GetComponent<BoxCollider2D>().size.y * .5f);
            bool groundedRight = Physics2D.Raycast(rayStartRight, Vector2.down, rayDistance, mask);
            bool groundedLeft = Physics2D.Raycast(rayStartLeft, Vector2.down, rayDistance, mask);
            if(groundedRight == true || groundedLeft == true) {
                grounded = true;
            }
            else {
                grounded = false;
            }
        }
        
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.tag == "Ladder") {
            body.gravityScale = 0;
            allowJump = false;
        }
    }

     void OnTriggerExit2D(Collider2D other) {
       
        if(other.gameObject.tag == "Ladder") {
            allowJump = true;
            body.gravityScale = 1;
        }
    }
}