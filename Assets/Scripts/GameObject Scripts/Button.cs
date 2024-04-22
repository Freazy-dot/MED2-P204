using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, IInteractable
{
    public Color buttonColor;
    private Timer timer;
    public static Dictionary<Color, int> buttonCounts = new Dictionary<Color, int>();
    public static HashSet<Color> matchedColors = new HashSet<Color>();
    private bool hasBeenPressed;

    public void Interact(GameObject player)
    {
        timer = player.GetComponent<Timer>();

        if (timer.timeLeft <= 0) 
        {
            if (!hasBeenPressed)
            {
                IncrementButtonCount(buttonColor);
                hasBeenPressed = true;
            }
            timer.StartTimer();
            return;
        }

        if (!hasBeenPressed)
        {
            IncrementButtonCount(buttonColor);
            hasBeenPressed = true;
        }
    }

    private void IncrementButtonCount(Color color)
    {
        if (!buttonCounts.ContainsKey(color))
        {
            buttonCounts[color] = 0;
        }

        buttonCounts[color]++;

        // Check if the player has pressed 3 buttons of the same color
        if (buttonCounts[color] == 3)
        {
            Debug.Log("Pressed 3 buttons of the same color: " + color);
            matchedColors.Add(color);
            buttonCounts[color] = 0; // Reset the count for this color
            hasBeenPressed = false;

            // Check if all three colors have been matched
            if (matchedColors.Count == 3)
            {
                Debug.Log("All three colors have been matched!");
            }
        }
    }
}