using UnityEngine;
using UnityEngine.Rendering;

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

    void Start()
    {
        LoadData();
    }

    public void SaveData()
    {
        PlayerPrefs.SetInt("Money", PlayerBase.Instance.playerMoney.currentCoins);
        PlayerPrefs.SetInt("Attack", PlayerBase.Instance.playerAttack.damage);
        PlayerPrefs.SetFloat("Speed", PlayerBase.Instance.playerMovement.moveSpeed);
        PlayerPrefs.SetInt("MaxHP", PlayerBase.Instance.playerhealth.maxHealth);
        PlayerPrefs.SetInt("HP", PlayerBase.Instance.playerhealth.currentHealth);
        PlayerPrefs.Save();
    }

    void LoadData()
{
    playerMoney.currentCoins = PlayerPrefs.GetInt("Money", 0);
    playerAttack.damage = PlayerPrefs.GetInt("Attack", 1);
    playerMovement.moveSpeed = PlayerPrefs.GetFloat("Speed", 3f);
    playerhealth.maxHealth = PlayerPrefs.GetInt("MaxHP", 3);

    playerhealth.currentHealth = Mathf.Clamp(
        PlayerPrefs.GetInt("HP", playerhealth.maxHealth),
        1,
        playerhealth.maxHealth
    );

    Debug.Log("HP chargé: " + playerhealth.currentHealth);

    playerhealth.UpdateHealthbarUi();
}

}
