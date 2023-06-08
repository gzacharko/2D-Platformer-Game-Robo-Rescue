using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Aaron Youch
//Moving platform
public class MovingPlatform : MonoBehaviour
{
    [SerializeField]private Vector2 translateApply = new Vector2(.01f, 0);
    [SerializeField]private float distance = 2;
    private Vector2 startPos;
    
    private bool forward;

    void Start()
    {
        forward = true;
        startPos = gameObject.transform.position;
    }

    //Move the platform and change direction once we reach our distance.
    void FixedUpdate() {
        if(forward) {
            gameObject.transform.Translate(translateApply);
            
            if(gameObject.transform.position.x >= startPos.x + distance)
                forward = false;

        }
        else {
            gameObject.transform.Translate(-translateApply);
            
            if(gameObject.transform.position.x <= startPos.x - distance) {
                forward = true;
            }
        }
    }
}