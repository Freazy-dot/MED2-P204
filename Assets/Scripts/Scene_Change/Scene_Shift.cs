using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Shift : MonoBehaviour
{
    SoundManager Soundman;
    public float targetTime = 5.0f; 
    public bool Timer = false;

    void Update()
    {
        if (Timer)
        {
            targetTime -= Time.deltaTime;  
        } 
         
        if (targetTime <= 0.0f)
        {
            timerEnded();
        }
    }

    void timerEnded()
    {
        SceneManager.LoadScene("Level-1");
    }


    void Awake()
    {
        Soundman = GameObject.FindGameObjectWithTag("AudioMan").GetComponent<SoundManager>();
    }

    public void MainScreen()
    {
        SceneManager.LoadScene("Title_Screen");
    }

    public void OptionsMenu()
    {
        SceneManager.LoadScene("Settings");
    }

    public void Level1()
    {
        SceneManager.LoadScene("Level-1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
