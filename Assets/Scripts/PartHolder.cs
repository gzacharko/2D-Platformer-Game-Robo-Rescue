using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Aaron Youch
//Holds a specific part when the player collides with it.
public class PartHolder : MonoBehaviour
{
    [SerializeField]private Sprite holdsPart;
    [SerializeField]private AudioSource placeSound;
    private bool holdingPart;

    void Awake() {
        holdingPart = false;
    }   
    
    public void AddPart() {
        if(!holdingPart) {
            holdingPart = true;
            placeSound.Play();
            GetComponent<SpriteRenderer>().sprite = holdsPart;
            GameObject.Find("Check level").GetComponent<FinalLevel>().CheckComplete();
        }
    }
    public bool HoldingPart { get => holdingPart; set => holdingPart = value; }
}
