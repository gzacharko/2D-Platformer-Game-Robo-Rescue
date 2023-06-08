using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Aaron Youch
//Out of Bounds trigger, check from player.
//When it enters, the player will lose a life and go to respawn point.
public class OutOfBounds : MonoBehaviour
{
    [SerializeField]private Vector2 respawnPoint;

    public Vector2 RespawnPoint { get; }
}
