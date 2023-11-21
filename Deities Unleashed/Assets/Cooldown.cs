using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Cooldown : MonoBehaviour
{
    public Image[] weapons; // Array to store all weapon images
    public float cooldown = 20.0f;
    private bool isCooldown = false;

    // Add a reference to your UI buttons in the Unity Editor
    public Button cooldownButton;
    public Button cooldownButton1;
    public Button cooldownButton2;
    public Button cooldownButton3;
    public Button cooldownButton4;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize fill amounts for all weapons
        foreach (Image weapon in weapons)
        {
            weapon.fillAmount = 1;
        }

        // Add onClick listeners to the cooldown buttons
        cooldownButton.onClick.AddListener(StartCooldown);
        cooldownButton1.onClick.AddListener(StartCooldown);
        cooldownButton2.onClick.AddListener(StartCooldown);
        cooldownButton3.onClick.AddListener(StartCooldown);
        cooldownButton4.onClick.AddListener(StartCooldown);
    }

    // Method to start the cooldown for all weapons
    void StartCooldown()
    {
        if (!isCooldown)
        {
            StartCoroutine(PerformCooldown());
        }
    }

    IEnumerator PerformCooldown()
    {
        isCooldown = true;

        // Gradually fill up all weapon images
        float timer = 0f;
        while (timer < cooldown)
        {
            timer += Time.deltaTime;

            // Set fill amount for each weapon
            foreach (Image weapon in weapons)
            {
                weapon.fillAmount = timer / cooldown;
            }

            yield return null;
        }

        // Reset fill amounts for all weapon images immediately
        foreach (Image weapon in weapons)
        {
            weapon.fillAmount = 1;
        }

        isCooldown = false;
    }
}
