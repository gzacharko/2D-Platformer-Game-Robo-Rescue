using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Aaron Youch
//Inventory management for collected items and keys the player has.
[SerializeField]
public class Inventory : MonoBehaviour
{
    [SerializeField]private int guiSpriteScale = 32;
    private List<int> keys;
    private List<GameObject> collectedItems;
    

    void Start()
    {
        collectedItems = new List<GameObject>();
        keys = new List<int>();
    }

    void Update()
    {
        
    }

    void OnGUI() {
        if(collectedItems.Count > 0) {
            for(int i=0; i<collectedItems.Count; i++) {
                GUI.DrawTexture(new Rect(i*guiSpriteScale+2, 0, guiSpriteScale, guiSpriteScale),
                                collectedItems[i].GetComponent<SpriteRenderer>().sprite.texture);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.GetComponent<Key>() != null) { //key
            AddKey(other.gameObject.GetComponent<Key>().KeyCode);
            Destroy(other.gameObject);
        }
        else if(other.gameObject.GetComponent<Chest>() != null) { //chest
            if(CheckKey(other.gameObject.GetComponent<Chest>().OpenKeyCode)) {
                other.gameObject.GetComponent<Chest>().OpenChest();
            }
        }
        else if(other.gameObject.GetComponent<Collectible>() != null) {
            AddItem(other.gameObject);
            other.gameObject.SetActive(false);
            GameObject.Find("GameManager").GetComponent<GameManager>().NextLevel();
        }
        else if(other.gameObject.GetComponent<PartHolder>() != null) {
            other.gameObject.GetComponent<PartHolder>().AddPart();
        }
    }

    public void AddKey(int key) {
        Keys.Add(key);
    }

    public bool CheckKey(int key) {
        return Keys.Contains(key);
    }

    public void AddItem(GameObject item) {
        collectedItems.Add(item);
    }

    public List<int> Keys { get => keys; set => keys = value; }
    public List<GameObject> CollectedItems { get => collectedItems; set => collectedItems = value; }
}
