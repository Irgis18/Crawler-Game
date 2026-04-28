using UnityEngine;
using UnityEngine.UIElements;

public class Coin : MonoBehaviour
{

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerBase.Instance.playerMoney.AddCoin();
            Destroy(gameObject);
        }        
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
