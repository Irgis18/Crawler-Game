using UnityEngine;

public class PlayerBase : MonoBehaviour
{

    public PlayerAttack playerAttack;

    public Playerhealth playerhealth;

    public PlayerMovement playerMovement;

    public PlayerMoney playerMoney;


    public static PlayerBase Instance;

    void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    
}
