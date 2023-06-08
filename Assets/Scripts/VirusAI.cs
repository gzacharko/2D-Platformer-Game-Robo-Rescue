using UnityEngine;

//Aaron Youch
//Base virus class
//Moves in random direction and bounces off walls.
public class VirusAI : MonoBehaviour {
    [SerializeField]private float speed = 5; //Speed is the force applied, not the actual velocity.
    [SerializeField]private float torque = .1f;
     
    private Vector2 startPos;
    private Rigidbody2D body;

    
    //Start initial movement and torque
    public void Start() {
        startPos = gameObject.transform.position;
        body = gameObject.GetComponent<Rigidbody2D>();
        body.AddTorque(Torque);
        body.AddForce(new Vector2(Speed, 0));

        body.AddForce(Random.insideUnitCircle.normalized * speed);
    }

    public float Speed { get => speed; set => speed = value; }
    public float Torque { get => torque; set => torque = value; }
    public Vector2 StartPos { get => startPos; set => startPos = value; }
    public Rigidbody2D Body { get => body; set => body = value; }
}