using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public GameObject inventoryPanel;
    public Animator item1anim;

    public void Start()
    {
        if (item1anim == null)
        {
            item1anim = GetComponent<Animator>();
        }
    }

    // Call this method when you want to enable the animator
    public void EnableAnimator1()
    {
        if (item1anim != null)
        {
            item1anim.enabled = true;
        }
    }

    // Attach this method to the Bag Button's onClick event in the Unity Editor
    public void OnBagButtonClick()
    {
        // Set the inventory panel to active when the bag button is clicked
        inventoryPanel.SetActive(true);
    }

    // Attach this method to the X Button's onClick event in the Unity Editor
    public void OnCloseButtonClick()
    {
        // Set the inventory panel to inactive when the X button is clicked
        inventoryPanel.SetActive(false);
    }
}