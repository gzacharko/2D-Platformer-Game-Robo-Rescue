using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Aaron Youch
//Fires a laser that damages 
public class Laser : MonoBehaviour
{
    [SerializeField] private int lingerTime = 10; //Time the laser lingers
    [SerializeField]private float growthPerUpdate = 5; //Growth of the laser per tick
    [SerializeField]private int cooldown = 300;
    [SerializeField]private GameObject laserObject;
    private int lingerTimer;
    private bool firing;
    private int cooldownTimer;
    private GameObject currentLaser;

    void Start()
    {
        firing = false;
        lingerTimer = 0;
        cooldownTimer = cooldown;
    }

    //Manage cooldown of laser firing
    void Update() {
        if(Input.GetKeyDown(KeyCode.Space)) { 
            Fire();
        }
        if(!firing && cooldownTimer > 0) {
            cooldownTimer--;
        }
    }

    //Cause the laser to travel.
    void FixedUpdate() {
        if(firing) {
            currentLaser.transform.localScale += new Vector3(growthPerUpdate, 0, 0);
            Vector2 size = currentLaser.GetComponent<BoxCollider2D>().size;
            //currentLaser.GetComponent<BoxCollider2D>().size += new Vector2(growethPerUpdate, 0);
            currentLaser.transform.position = gameObject.transform.position;
            lingerTimer--;
            if(lingerTimer <= 0) {
                firing = false;
                Destroy(currentLaser);
                cooldownTimer = cooldown;
            }
        }
    }

    //Display cooldown timer
    void OnGUI() {
        GUI.Box(new Rect(0, 0, 64, 32), ""+cooldownTimer);
    }

    //Fire the laser!
    public void Fire() {
        if(!firing && cooldownTimer <= 0) {
            firing = true;
            lingerTimer = lingerTime;
            currentLaser = Instantiate(laserObject, gameObject.transform.position, gameObject.transform.rotation);
        }
    }
}
