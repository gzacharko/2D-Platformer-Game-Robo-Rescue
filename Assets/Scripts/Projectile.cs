using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{

    //Projectile that checks for collisions with the player or an enemy.
    void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player") {
            Rigidbody2D body = other.gameObject.GetComponent<Rigidbody2D>();
            body.velocity = new Vector2(0, body.velocity.y);
            other.gameObject.GetComponent<Health>().LoseHeart();
        }
        else if(other.gameObject.tag == "Enemy") {
            Destroy(other.gameObject);
        }

        Destroy(gameObject);
    }
}
