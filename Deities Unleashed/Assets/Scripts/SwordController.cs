using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SwordController : MonoBehaviour
{
    public AudioSource slashSound;

    public GameObject sword;
    public bool canAttack = true;
    public float attackCooldown = 1.0f;
    public bool isAttacking = false;
    public Button swordAttackButton;

    // Reference to the player's level system
    public CharacterLevelSystem CS;

    private string[] targetTags = { "Phoenix", "Tiyanak", "BalBal", "TikTik", "Golem", "Wolf", "Cyclops", "ElectricGolem", "Eagle" };

    void Start()
    {
        slashSound = GetComponent<AudioSource>();
        swordAttackButton.onClick.AddListener(OnClickSwordAttack);

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
    }

    public void OnClickSwordAttack()
    {
        if (canAttack)
        {
            SwordAttack();
            slashSound.Play();
            StartCoroutine(StartCooldown());
        }
    }

    public void SwordAttack()
    {
        isAttacking = true;
        canAttack = false;
        Animator anim = sword.GetComponent<Animator>();
        anim.SetTrigger("attack");

        int damage = CalculateSwordDamage();
        Debug.Log("Sword Damage: " + damage);

        DealDamage(damage);
    }

    public int CalculateSwordDamage()
    {
        int minDamage = 2 + (3 * CS.currentLevel);
        int maxDamage = 10 + (5 * CS.currentLevel);

        int damage = Random.Range(minDamage, maxDamage + 1);
        Debug.Log("Calculated Damage: " + damage);

        int criticalRoll = Random.Range(1, 11);
        Debug.Log("Critical Roll: " + criticalRoll);

        if (criticalRoll == 5)
        {
            damage += 1000;
            Debug.Log("Critical Hit! Added 1000 damage.");
        }

        return damage;
    }

    void DealDamage(int damage)
    {
        // Check for collision with enemies
        Collider[] hitColliders = Physics.OverlapSphere(sword.transform.position, sword.GetComponent<BoxCollider>().size.x);

        foreach (Collider collision in hitColliders)
        {
            bool isTarget = false;

            foreach (string targetTag in targetTags)
            {
                if (collision.gameObject.CompareTag(targetTag))
                {
                    isTarget = true;
                    break;
                }
            }

            if (isTarget)
            {
                EnemyTarget enemyDamageReceiver = collision.gameObject.GetComponent<EnemyTarget>();
                if (enemyDamageReceiver != null)
                {
                    enemyDamageReceiver.TakeDamage(damage);
                    Debug.Log("Applied Damage: " + damage);
                    // Additional logic can be added here if needed
                }
            }
        }
    }


    IEnumerator StartCooldown()
    {
        yield return new WaitForSeconds(attackCooldown);
        canAttack = true;
    }
}
