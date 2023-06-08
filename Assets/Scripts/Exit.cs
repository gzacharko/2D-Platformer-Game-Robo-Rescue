using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Aaron Youch
//Exit level script check if player touched the exit, if so end the game.
public class Exit : MonoBehaviour
{   
    void OnCollisionEnter2D(Collision2D other){
        if(other.gameObject.tag == "Player") {
            Destroy(GameObject.Find("MusicSwitcher"));
            SceneManager.LoadScene("MainMenu");
        }
    }
}
