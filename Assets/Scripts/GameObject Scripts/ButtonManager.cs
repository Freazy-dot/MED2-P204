using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ButtonManager : MonoBehaviour
{
    private Dictionary<Color, int> buttonCounts = new Dictionary<Color, int>();
    private HashSet<Color> matchedColors = new HashSet<Color>();
    private Timer timer;

    public void HandleButtonPress(Color color, GameObject player)
    {
        timer = player.GetComponent<Timer>();

        if (timer.timeLeft <= 0) 
        {
            timer.StartTimer();
            ResetButtonCounts();
        }

        if (!buttonCounts.ContainsKey(color))
        {
            buttonCounts[color] = 0;
        }

        buttonCounts[color]++;

        if (buttonCounts[color] == 3)
        {
            Debug.Log("Pressed 3 buttons of the same color: " + color);
            matchedColors.Add(color);
            buttonCounts[color] = 0;

            if (matchedColors.Count == 3)
            {
                Debug.Log("All three colors have been matched!");
            }
        }
    }

    public void ResetButtonCounts()
    {
        foreach (Color color in buttonCounts.Keys.ToList())
        {
            if (!matchedColors.Contains(color))
            {
                buttonCounts[color] = 0;
            }
        }
    }
}
