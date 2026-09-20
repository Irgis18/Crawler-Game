using UnityEngine;
using UnityEngine.UI;
public class Playerhealth : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public bool isAlive = true;

    public Transform healthbarUI;

    public GameObject hpPrefab;

    public Animator animator;

    public SpriteRenderer spriteRenderer;

    public Image bloodVignette;

    public GameOver gameOver;
    public float bloodAlpha2HP = 0.35f;
    public float bloodAlpha1HP = 0.75f;
    public float bloodAlpha0HP = 1f;

    void Awake()
    {
        currentHealth = maxHealth;
        UpdateHealthbarUi();
        UpdateBloodVignette();
    }
    public void TakeDamage(int damage)
    {
        if (isAlive)
        {
                  currentHealth -= damage;
        UpdateHealthbarUi();
        UpdateBloodVignette();
        if(currentHealth <= 0)
        {
            isAlive = false;
            animator.SetTrigger("Die");
            gameOver.gameOverEND();
        }
        }
  
    }

    public void UpdateHealthbarUi()
    {
        foreach (Transform child in healthbarUI)
        {
            Destroy(child.gameObject);
        }

        for (int i = 0; i < currentHealth; i++)
        {
            Instantiate(hpPrefab, healthbarUI);
        }
    }

    public void UpdateBloodVignette()
    {
        if(bloodVignette == null)
        {
            Debug.Log("Rien n'est dedans bg");
             return;
        }
       
        Color color = bloodVignette.color;

        if (currentHealth >= 3)
        {
            color.a = 0f;
        }

        else if (currentHealth == 2)
        {
            color.a = bloodAlpha2HP;
        }

        
        else if (currentHealth == 1)
        {
            color.a = bloodAlpha1HP;
        }

        
        else
        {
            color.a = bloodAlpha0HP;
        }

        bloodVignette.color = color;
    }

    public void DisablePlayerVisual()
    {
        spriteRenderer.enabled = false;
    }

    public void IncreaseMaxHealth(int hpCount)
    {
        maxHealth += hpCount;
        currentHealth += hpCount;
        UpdateHealthbarUi();
        UpdateBloodVignette();
    }
}
