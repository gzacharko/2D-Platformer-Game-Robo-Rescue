using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Aaron Yocuh
//Virus that moves in a linear fashion either vertically or horizontally
public class VirusLinear : VirusAI
{
    public enum Direction {horizontal, vertical};
    //Pace distance is the distance from the origin point
    //the AI will move in both directions.
    //So the total pace will be paceDistance * 2
    [SerializeField]private float paceDistance = 5;
    [SerializeField]private Direction direction =  Direction.horizontal;
    private bool forward;
    
    //Start the movement
    public new void Start()
    {
        StartPos = gameObject.transform.position;
        Body = gameObject.GetComponent<Rigidbody2D>();
        Body.AddTorque(Torque);
        if(direction == Direction.horizontal)
            Body.AddForce(new Vector2(Speed, 0));
        else {
            Body.AddForce(new Vector2(0, Speed));
        }
        forward = true;
    }

    //Pace the virus back and forth
    public void FixedUpdate()
    {
        if(forward && gameObject.transform.position.x > StartPos.x + paceDistance && direction == Direction.horizontal) { 
            forward = false;
            Body.velocity = new Vector2(0, 0);
            Body.AddForce(new Vector2(-Speed, 0));
        }
        else if(!forward && gameObject.transform.position.x < StartPos.x - paceDistance && direction == Direction.horizontal) {
            forward = true;
            Body.velocity = new Vector2(0, 0);
            Body.AddForce(new Vector2(Speed, 0));
        }
        else if(forward && gameObject.transform.position.y > StartPos.y + paceDistance && direction == Direction.vertical) { 
            forward = false;
            Body.velocity = new Vector2(0, 0);
            Body.AddForce(new Vector2(0, -Speed));
        }
        else if(!forward && gameObject.transform.position.y < StartPos.y - paceDistance && direction == Direction.vertical) { 
            forward = true;
            Body.velocity = new Vector2(0, 0);
            Body.AddForce(new Vector2(0, Speed));
        }
    }
}
