using UnityEngine;
using UnityEngine.UI;

public class PlayerMoney : MonoBehaviour
{

    public Text coinText;
    public int currentCoins;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        coinText = GameObject.FindGameObjectWithTag("CoinsText").GetComponent<Text>();
        UpdateCoinsCount();
    }

    void UpdateCoinsCount()
    {
        coinText.text = currentCoins.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddCoin(int CoinsCount = 1)
    {
        currentCoins = currentCoins + CoinsCount;
        UpdateCoinsCount();
    }
}
