using UnityEngine;

public class CrossBowController : MonoBehaviour
{
    public Sprite IdleSprite;
    public Sprite AttackSprite;

    public SpriteRenderer crossbowSpriteRenderer;

    void Start()
    {
        crossbowSpriteRenderer = GetComponent<SpriteRenderer>();
        UpdateCrossBowSprite();
    }

    public void SetCrossBowState(bool canShoot, bool isOnCooldown)
    {
        if (crossbowSpriteRenderer == null)
        {
            Debug.LogError("crossbowSpriteRenderer is null. Make sure it is properly assigned.");
            return;
        }

        if (canShoot && !isOnCooldown)
        {
            crossbowSpriteRenderer.sprite = IdleSprite;
        }
        else
        {
            crossbowSpriteRenderer.sprite = AttackSprite;
        }
    }


    public void UpdateCrossBowSprite()
    {
        // You can add logic to set the initial sprite here if needed.
    }
}
