using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Aaron Yocuh
//Key that will open a chest if the keyCode matches the one for the chest.
public class Key : MonoBehaviour
{
    [SerializeField]private int keyCode = 1;

    public int KeyCode { get => keyCode; set => keyCode = value; }
}
