using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Keeps music between scenes.
//https://answers.unity.com/questions/1260393/make-music-continue-playing-through-scenes.html
public class MusicSwitcher : MonoBehaviour {
    private static MusicSwitcher instance = null;
    public static MusicSwitcher Instance
     {
         get { return instance; }
     }
     void Awake()
     {
         if (instance != null && instance != this) {
             Destroy(this.gameObject);
             return;
         } else {
             instance = this;
         }
         DontDestroyOnLoad(this.gameObject);
     }
}
