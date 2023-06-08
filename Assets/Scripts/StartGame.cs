using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour {   
    private string path;
    private int loaded;
    private GameObject[] saveSlots;
    private GameObject[] otherButtons;
    private bool isNewGame;

    void Awake() {
        DontDestroyOnLoad(gameObject);
        loaded = 0;
        path = Application.persistentDataPath;
        isNewGame = true;
    }

    void Start() {
        saveSlots = GameObject.FindGameObjectsWithTag("SaveButton");
        int index = 0;
        foreach(GameObject i in saveSlots) {
            index++;
            i.SetActive(false);
            if(File.Exists($"{path}/{index}")) {
                using (StreamReader sr = new StreamReader($"{path}/{index}"))
                {
                    string line;
                    string output = "";
                        
                    while ((line = sr.ReadLine()) != null) {
                        output += line;
                    }
                    i.GetComponentInChildren<Text>().text = output;
                }
            }
            
        }
        otherButtons = GameObject.FindGameObjectsWithTag("MainButtons");
    }

    public void NewGame(string levelName) {
        isNewGame = true;
        ShowSaveSlots();
    }

    public void NewSlotClicked(int buttonNumber) {
        loaded = buttonNumber;
        if(isNewGame) {
            SaveGame("Level1");
            SceneManager.LoadScene("Level1");
        }
        else if(File.Exists($"{path}/{loaded}")) {
            using (StreamReader sr = new StreamReader($"{path}/{loaded}"))
            {
                string line;
                string output = "";
                        
                while ((line = sr.ReadLine()) != null) {
                    output += line;
                }
                SceneManager.LoadScene(output);
            }  
        }
        
    }

    public bool SaveGame(string level) {
        StreamWriter writer = new StreamWriter($"{path}/{loaded}", false);
        writer.Write(level);
        writer.Close();
        return true;
    }       

    public void LoadGame(bool load) {
        isNewGame = false;
        ShowSaveSlots();
    }

    public void QuitGame(bool anyTruers) {
        Application.Quit();
    }

    public void ShowSaveSlots() {
        foreach(GameObject i in otherButtons) {
            i.SetActive(false);
        }
        foreach(GameObject i in saveSlots) {
            i.SetActive(true);
        }
    }
}
