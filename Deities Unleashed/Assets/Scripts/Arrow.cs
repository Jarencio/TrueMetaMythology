using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public CharacterLevelSystem CS;
    [SerializeField] float life = 10;
    [SerializeField] int minDamage; // Minimum damage
    [SerializeField] int maxDamage; // Maximum damage


    // Define the tags that the arrow should compare against
    private string[] targetTags = { "Phoenix", "Tiyanak", "BalBal", "TikTik", "Golem", "Wolf", "Cyclops", "ElectricGolem", "Eagle" };

    private bool damageApplied = false; // Flag to track if damage has already been applied

    void Awake()
    {
        // Find the "Player" GameObject and get the attached "CharacterLevelSystem" script
        GameObject player = GameObject.Find("Player");
        if (player != null)
        {
            CS = player.GetComponent<CharacterLevelSystem>();
        }
        else
        {
            Debug.LogError("Player GameObject not found. Make sure the GameObject is named 'Player' and has the 'CharacterLevelSystem' script attached.");
        }

        Destroy(gameObject, life);
    }

    void OnCollisionEnter(Collision collision)
    {
        minDamage = 2 + (3 * CS.currentLevel);
        maxDamage = 10 + (5 * CS.currentLevel);
        Debug.Log("" + minDamage + " & " + maxDamage);
        // Check if damage has already been applied
        if (damageApplied)
            return;

        // Generate a random damage value between minDamage and maxDamage
        int damage = Random.Range(minDamage, maxDamage + 1); // +1 to include the maximum value

        // Generate a random number between 1 and 10 for critical hit
        int criticalRoll = Random.Range(1, 11);
        Debug.Log("Critical: " + criticalRoll);
        // Check for a critical hit (e.g., if the roll is 2, add 1000 damage)
        if (criticalRoll == 2)
        {
            damage += 1000;
            Debug.Log("Critical Hit! Added 1000 damage.");
        }

        foreach (string targetTag in targetTags)
        {
            if (collision.gameObject.CompareTag(targetTag))
            {
                EnemyTarget enemyDamageReceiver = collision.gameObject.GetComponent<EnemyTarget>();
                if (enemyDamageReceiver != null)
                {
                    enemyDamageReceiver.TakeDamage(damage);
                    Debug.Log("Applied Damage: " + damage);
                    damageApplied = true; // Set the flag to true to indicate damage has been applied
                }
                Destroy(gameObject);
                return; // Exit the loop once we've found a matching tag
            }
        }

        // If no matching tag is found, simply destroy the arrow
        Destroy(gameObject);
    }
}