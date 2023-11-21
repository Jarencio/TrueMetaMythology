using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Popup : MonoBehaviour
{
    private TextMeshPro TextMesh;
    private TextMeshProUGUI Texts; // Change the type to TextMeshProUGUI

    private void Awake()
    {
        TextMesh = transform.GetComponent<TextMeshPro>();
    }

    public void Setup(int Damage)
    {
        if (Damage > 800)
        {
            TextMesh.SetText("CRIT");
        }
        else
        {
            Damage = Damage * 100;
            TextMesh.SetText(Damage.ToString());
        }
    }

    public void Lvl(int Level)
    {
        // Set the text
        TextMesh.SetText("LVL. " + Level.ToString());
        // Flip the TextMesh sideways by changing the local scale
        transform.localScale = new Vector3(-1f, 1f, 1f);
    }

    public void Cooldown()
    {
        if (Texts != null)
        {
            Texts.text = "Currently in Weapon Switch Cooldown";
        }
        else
        {
            Debug.LogError("TextMesh component not assigned in the inspector!");
        }
    }

    public void ResetText()
    {
        if (Texts != null)
        {
            Texts.text = "";
        }
        else
        {
            Debug.LogError("TextMesh component not assigned in the inspector!");
        }
    }
}
