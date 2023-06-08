using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Aaron Youch
//Final level script to check if all parts were placed.
public class FinalLevel : MonoBehaviour
{
    [SerializeField]List<PartHolder> partHolders = new List<PartHolder>();
    // Start is called before the first frame update

    public void CheckComplete() {
        if(partHolders.TrueForAll(x => x.HoldingPart)) {
            Destroy(GameObject.Find("Manager"));
            Destroy(GameObject.Find("MusicSwitcher"));
            SceneManager.LoadScene("End Credits");
        }    
    }
}
