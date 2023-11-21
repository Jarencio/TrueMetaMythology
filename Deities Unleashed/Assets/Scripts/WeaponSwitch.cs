using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitch : MonoBehaviour
{
    public Shoot shoot;

    [SerializeField] GameObject slot1;
    [SerializeField] GameObject slot2;

    public Button CrossBowButton;
    public Button SwordButton;
    public int currentWeapon = 0;

    void Awake()
    {
        // Attach the OnSwitchButtonClick method to the button click events
        CrossBowButton.onClick.AddListener(SwitchToCrossbow);
        SwordButton.onClick.AddListener(SwitchToSword);

        // Initially equip the first weapon
        SwitchToCrossbow(); // Assuming you want the CrossBow as the initial weapon
    }

    public void SwitchToCrossbow()
    {
        if (currentWeapon == 0)
            return; // If it's already the current weapon, do nothing

        currentWeapon = 0;
        Equip1();
    }


    void SwitchToSword()
    {
        if (currentWeapon == 1)
            return; // If it's already the current weapon, do nothing

        currentWeapon = 1;
        Equip2();
    }

    void Equip1()
    {
        slot1.SetActive(true);
        slot2.SetActive(false);
        shoot.SetCanShoot(true); // Allow shooting with this weapon
    }

    void Equip2()
    {
        slot1.SetActive(false);
        slot2.SetActive(true);
        shoot.SetCanShoot(false); // Prevent shooting with this weapon
    }
}
