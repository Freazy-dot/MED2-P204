using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour, IInteractable
{
    public Color buttonColor;
    private Timer timer;
    private static Dictionary<Color, int> buttonCounts = new Dictionary<Color, int>();

    public void Interact(GameObject player)
    {
        timer = player.GetComponent<Timer>();

        if (timer.timeLeft <= 0) {
            IncrementButtonCount(buttonColor);
            timer.StartTimer();
            return;
        }

        IncrementButtonCount(buttonColor); // Increment count as soon as button is pressed
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
            buttonCounts[color] = 0; // Reset the count for this color
        }
    }
}
