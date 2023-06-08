using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VirusShooter : MonoBehaviour
{
    [SerializeField]private GameObject projectile;
    [SerializeField]private int fireIncrement = 100;
    [SerializeField]private float projectileOffset = .2f;
    [SerializeField]private float fireSpeed = 20;
    private int incrementTimer;
    // Start is called before the first frame update
    void Start()
    {
        incrementTimer = fireIncrement;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        incrementTimer--;
        if(incrementTimer <= 0) {
            Fire();
            incrementTimer = fireIncrement;
        }
    } 

    public void Fire() {
        GameObject activeProjectile = Instantiate(projectile, 
                        gameObject.transform.position + Vector3.left * projectileOffset,
                        gameObject.transform.rotation);
        activeProjectile.GetComponent<Rigidbody2D>().AddForce(Vector3.left * fireSpeed);
    }
}
