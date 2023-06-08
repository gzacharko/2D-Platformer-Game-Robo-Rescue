using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Aaron Youch
//Loops a Game Object by Translating its position alone the x-axis.
//Once it reaches a certain x-axis limit it is placed back at a return point.
public class LoopBackground : MonoBehaviour
{
    [SerializeField]float returnPoint = -10;
    [SerializeField]float limitPoint = 10;
    [SerializeField]Vector2 translateApply = new Vector2(.05f, 0);
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        gameObject.transform.Translate(translateApply);
        if(gameObject.transform.position.x >= limitPoint) {
            gameObject.transform.position = new Vector2(returnPoint, gameObject.transform.position.y);
        }
    }
}
