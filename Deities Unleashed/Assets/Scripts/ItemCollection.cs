using System;
using UnityEngine;
using UnityEngine.UI;

public class ItemCollection : MonoBehaviour
{
    public static event Action OnCollected;

    public GameObject ItemPrefab;
    public GameObject spawnedItem;
    public GameObject enemyToDestroy;

    public Inventory inventory;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("COLLECTED");
            OnCollected?.Invoke();

            // Destroy the enemy GameObject
            if (enemyToDestroy != null)
            {
                Destroy(enemyToDestroy);
            }

            // Destroy the item GameObject
            Destroy(gameObject);

        }
        inventory.EnableAnimator1();
    }

    public void RespawnItem()
    {
        // Deactivate the current item
        if (spawnedItem != null)
        {
            spawnedItem.SetActive(false);
        }

        // Respawn the item at a new position
        Vector3 respawnPosition = transform.position + new Vector3(UnityEngine.Random.Range(-5f, 5f), 0.5f, UnityEngine.Random.Range(-5f, 5f));

        // Spawn a new item at the calculated position
        spawnedItem = Instantiate(ItemPrefab, respawnPosition, Quaternion.identity);
        spawnedItem.SetActive(true);
    }
}