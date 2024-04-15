using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Scene_Intro_Shift : MonoBehaviour
{
    
   public int TitleScreen = 1;
   public float targetTime = 12.6f; 

        void Update()
        {

            targetTime -= Time.deltaTime;

            if (targetTime <= 0.0f)
            {
                timerEnded();
            }
        }

        void timerEnded()
        {
            SceneManager.LoadScene(TitleScreen);
        }
    
}
