using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Shift : MonoBehaviour
{
    public int Level_1 = 2;
    public int Options = 3;
    public void StartGame()
    {
        SceneManager.LoadScene(Level_1);
    }

    public void OptionsMenu()
    {
        SceneManager.LoadScene(Options);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
