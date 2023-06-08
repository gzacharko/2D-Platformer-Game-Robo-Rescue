using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Aaron Youch
//Health keeps track of the player's hearts and displays them.
//Also handles player death (running out of hearts).
public class Health : MonoBehaviour {
    [SerializeField]private int baseHearts = 3;
    [SerializeField]private int safeTime = 500;
    [SerializeField]private Texture fullHeart;
    [SerializeField]private Texture emptyHeart;
    [SerializeField]private float heartTextureSize = 64;
    [SerializeField]private int invulBlinkInterval = 100;
    [SerializeField]private AudioSource damageSound, deathSound;
    private int safeTimer;
    private int currentHearts;
    private int invulBlinkTimer;
    private Vector3 spawnPoint;
    


    void Awake() {
        spawnPoint = gameObject.transform.position;
        currentHearts = baseHearts;
        safeTimer = 0;
        invulBlinkTimer = 0;
    }

    void FixedUpdate() {
        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
        if(safeTimer > 0) {
            safeTimer--;
            if(invulBlinkTimer <= 0 && sprite.enabled) {
                sprite.enabled = false;
                invulBlinkTimer = invulBlinkInterval;
            }
            else if(invulBlinkTimer <= 0 && !sprite.enabled) {
                invulBlinkTimer = invulBlinkInterval;
                sprite.enabled = true;
            }
            invulBlinkTimer--;
        }
        if(safeTimer == 0) {
            safeTimer = -1;
            sprite.enabled = true;
        }
    }

    //Lose health on collision with enemy.
    void OnCollisionEnter2D(Collision2D other) {
        if((other.gameObject.tag == "Enemy" || other.gameObject.tag == "Spike") && safeTimer <= 0) {
            safeTimer = safeTime;
            LoseHeart();
            Destroy(other.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if(other.gameObject.GetComponent<OutOfBounds>()) {
            safeTimer = safeTime;
            //gameObject.GetComponent<Rigidbody2D>().Sleep();
            gameObject.GetComponent<Rigidbody2D>().position = other.gameObject.GetComponent<OutOfBounds>().RespawnPoint; 
            //gameObject.GetComponent<Rigidbody2D>().WakeUp();
            LoseHeart();
        }
    }

    //Paint Hearts to screen using a for loop.
    //If < current hearts then paint a full heart,
    //if not, paint an empty one.
    void OnGUI() {
        
        for(int i=0; i<baseHearts; i++) {
            if(i < currentHearts) {
                GUI.Label(new Rect(i*heartTextureSize/2, Screen.height-(heartTextureSize/2+3), 
                            heartTextureSize, heartTextureSize), fullHeart);
            }
            else {
                GUI.Label(new Rect(i*heartTextureSize/2, Screen.height-(heartTextureSize/2+3), 
                            heartTextureSize, heartTextureSize), emptyHeart);
            }
        }
    }

    //Decrement one heart
    public void LoseHeart() {
        currentHearts--;
        invulBlinkTimer = invulBlinkInterval;
        damageSound.Play();

        if(currentHearts <= 0) {
            deathSound.Play();
            GameManager manager = GameObject.Find("GameManager").GetComponent<GameManager>();
            manager.Death();
        }    
    }
}