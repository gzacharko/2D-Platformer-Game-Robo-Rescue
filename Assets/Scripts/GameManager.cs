using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Aaron Youch
//Game Manager script, manages pause, death, and resume.
public class GameManager : MonoBehaviour
{
    [SerializeField]private GameObject resume, quit;
    private GameObject deathText;
    private bool dead;
    
    void Awake() {
        dead = false;
        resume.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
        deathText = GameObject.Find("DeathText");
        deathText.SetActive(false);
        if(GameObject.Find("Manage") != null)
            GameObject.Find("Manage").GetComponent<StartGame>().SaveGame(SceneManager.GetActiveScene().name);
    }
    
    public void PauseGame() {
        resume.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void ResumeGame() {
        resume.gameObject.SetActive(false);
        quit.gameObject.SetActive(false);
        Time.timeScale = 1;
        if(dead) {
            dead = false;
             SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void Death() {
        dead = true;
        deathText.SetActive(true);
        resume.gameObject.SetActive(true);
        quit.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
    public void Quit(bool anyTruers) {
        Time.timeScale = 1;
        Destroy(GameObject.Find("Manage"));
        Destroy(GameObject.Find("MusicSwitcher"));
        SceneManager.LoadScene("MainMenu");
    }

    public void Resume(bool anyTruers) {
        ResumeGame();
    }

    public void NextLevel() {
        string name = SceneManager.GetActiveScene().name;
        if(name == "Level1") {
            SceneManager.LoadScene("Level2");
        }
        else if(name == "Level2") {
            SceneManager.LoadScene("Level3");
        }
        else if(name == "Level3") {
            SceneManager.LoadScene("Level4");
        }
        else {
            GameObject music = GameObject.Find("MusicSwitcher");
            Destroy(music);
            SceneManager.LoadScene("Level5");
        }
    }

    void Update() {
        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(Time.timeScale == 1)
                PauseGame();
            else {
                ResumeGame();
            }
        }
    }
}
