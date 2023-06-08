using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Aaron Youch
//Button that destroys (a) gameobject(s) on load
public class ButtonDestroy : MonoBehaviour
{
    [SerializeField]private GameObject[] destroyOnPress;
    
    void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Player") {
            foreach (GameObject o in destroyOnPress) {
                Destroy(o);
            }
            Destroy(gameObject);
        }
    }
}
