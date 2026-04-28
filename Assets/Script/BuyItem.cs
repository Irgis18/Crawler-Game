using JetBrains.Annotations;
using UnityEngine;

public class BuyItem : MonoBehaviour
{

    public int price;

    public float speedMultiplier;

    public int hpModifier;

    public float damageMultiplier;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && price <= PlayerBase.Instance.playerMoney.currentCoins)
        {
            PlayerBase.Instance.playerMoney.AddCoin(-price);

            if(speedMultiplier != 0)
            {
                PlayerBase.Instance.playerMovement.MultiplySpeed(speedMultiplier);
            }
            if(damageMultiplier != 0)
            {
                PlayerBase.Instance.playerAttack.MultiplyDamages(damageMultiplier);
            }

           PlayerBase.Instance.playerhealth.IncreaseMaxHealth(hpModifier);
        }
    }
}

