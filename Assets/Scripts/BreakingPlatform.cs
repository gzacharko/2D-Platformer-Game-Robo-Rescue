using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Aaron Youch
//Platform that breaks after a specified time of the player colliding with it
//It also respawns after a set amount of time.
public class BreakingPlatform : MonoBehaviour
{
    [SerializeField]private int breakTime = 100;
    [SerializeField]private int respawnTime = 500;
    private int breakTimer;
    private int respawnTimer;
    [SerializeField]private Sprite breaking;
    private Sprite defaultSprite;

    void Start()
    {
        defaultSprite = GetComponent<SpriteRenderer>().sprite;
        breakTimer = -1;
        respawnTimer = -1;
    }

    //Mange break timer and respawn timer
    void FixedUpdate() {
        if(breakTimer > 0) {
            breakTimer--;
        }
        if(breakTimer == breakTime / 2) {
            GetComponent<SpriteRenderer>().sprite = breaking;
        }
        else if(breakTimer == 0) {
            GetComponent<SpriteRenderer>().sprite = defaultSprite;
            SetComponents(false);
            respawnTimer = respawnTime;
            breakTimer = -1;
        }
        else if(respawnTimer > 0) {
            respawnTimer--;
        }
        else if(respawnTimer == 0) {
            SetComponents(true);
            respawnTimer = -1;
        }
    }

    //On collision, start break timer
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player" && breakTimer == -1) {
            breakTimer = breakTime;
        }
    }

    //Set Collider and SpriteRenderer active or inactive
    public void SetComponents(bool active) {
        gameObject.GetComponent<Collider2D>().enabled = active;
        gameObject.GetComponent<SpriteRenderer>().enabled = active;
    }
}
