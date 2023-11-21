using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Import the UnityEngine.UI namespace to use the Text component.

public class TextChanger : MonoBehaviour
{
    public Text displayText; // Reference to the Text component in the Inspector.

    void Start()
    {
        displayText.text = "Popup"; // Set the initial text.
    }

    // This method takes an int and converts it to a string before setting the text.
    public void Text(int damage)
    {
        displayText.text = damage.ToString(); // Convert int to string and set the text.
    }
}
