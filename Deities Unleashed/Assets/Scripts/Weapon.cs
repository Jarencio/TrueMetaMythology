using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public AttackButtonController attackButtonController;

    int totalWeapons = 1;
    public int currentWeaponIndex;

    public GameObject[] weapons;
    public GameObject weaponHolder;
    public GameObject currentWeapon;

    public Button CrossBowButton;
    public Button SwordButton;
    public Button Sword2Button;
    public Button SpearButton;
    public Button BowButton;
    public AudioSource equipSound;

    private bool canSwitchWeapon = true;
    public float switchCooldownDuration = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        equipSound = GetComponent < AudioSource>();

        CrossBowButton.onClick.AddListener(() => SwitchWeapon(0, CrossBowButton));
        SwordButton.onClick.AddListener(() => SwitchWeapon(1, SwordButton));
        Sword2Button.onClick.AddListener(() => SwitchWeapon(2, Sword2Button));
        SpearButton.onClick.AddListener(() => SwitchWeapon(3, SpearButton));
        BowButton.onClick.AddListener(() => SwitchWeapon(4, BowButton));

        attackButtonController = FindObjectOfType<AttackButtonController>();

        if (attackButtonController == null)
        {
            Debug.LogError("AttackButtonController not found in the scene!");
        }

        totalWeapons = weaponHolder.transform.childCount;
        weapons = new GameObject[totalWeapons];

        for (int i = 0; i < totalWeapons; i++)
        {
            weapons[i] = weaponHolder.transform.GetChild(i).gameObject;
            weapons[i].SetActive(false);
        }

        weapons[0].SetActive(true);
        currentWeapon = weapons[0];
        currentWeaponIndex = 0;
    }

    void SwitchWeapon(int newIndex, Button button)
    {
        if (canSwitchWeapon)
        {
            Debug.Log("Switching to weapon: " + newIndex);

            equipSound.Play();
            weapons[currentWeaponIndex].SetActive(false);
            currentWeaponIndex = newIndex;
            weapons[currentWeaponIndex].SetActive(true);
            currentWeapon = weapons[currentWeaponIndex];

            attackButtonController.SwitchAttackButtons(newIndex);

            // Disable all buttons immediately
            CrossBowButton.interactable = false;
            SwordButton.interactable = false;
            Sword2Button.interactable = false;
            SpearButton.interactable = false;
            BowButton.interactable = false;

            StartCoroutine(StartSwitchCooldown());
        }
        else
        {
            Debug.Log("Cannot switch weapon. Still on cooldown.");
        }
    }

    IEnumerator StartSwitchCooldown()
    {
        // Call the Cooldown method from the Popup script

        // Wait for the specified cooldown duration
        yield return new WaitForSeconds(switchCooldownDuration);

        // Reset the text to nothing after the cooldown
        

        // Enable all buttons after cooldown
        CrossBowButton.interactable = true;
        SwordButton.interactable = true;
        Sword2Button.interactable = true;
        SpearButton.interactable = true;
        BowButton.interactable = true;

        canSwitchWeapon = true;
    }

}
