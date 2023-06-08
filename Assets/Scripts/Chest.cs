using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Aaron Youch
//Chest that will open and spawn an object if the player has a key
public class Chest : MonoBehaviour
{
    [SerializeField]private int openKeyCode = 1;
    [SerializeField]private GameObject content;
    [SerializeField]private bool isOpen = false;

    public void OpenChest() {
        if(!isOpen) {
            Instantiate(content, new Vector3(gameObject.transform.position.x, 
                                            gameObject.transform.position.y,
                                            gameObject.transform.position.z - 1), 
                                            gameObject.transform.rotation);
            isOpen = true;
        }
    }

    //Setters/Getters
    public int OpenKeyCode { get => openKeyCode; set => openKeyCode = value; }
    public GameObject Content { get => content; set => content = value; }
}
