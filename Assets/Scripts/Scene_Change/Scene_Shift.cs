using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Shift : MonoBehaviour
{
    SoundManager Soundman;
    public int Main_screen = 1;
    public int Options = 2;
    public int Level_1 = 3;
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
        SceneManager.LoadScene(Level_1);
    }


    void Awake()
    {
        Soundman = GameObject.FindGameObjectWithTag("AudioMan").GetComponent<SoundManager>();
    }
    public void MainScreen()
    {
        SceneManager.LoadScene(Main_screen);
    }

    public void OptionsMenu()
    {
        SceneManager.LoadScene(Options);
    }

    public void Level1()
    {
        Soundman.levelmusic();
        Timer = true;
    } 

    public void QuitGame()
    {
        Application.Quit();
    }
}
