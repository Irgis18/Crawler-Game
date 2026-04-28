using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour
{
    public string levelToLoad;

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SaveData();
            StartCoroutine(LoadSceneWithFade(levelToLoad));
            
        }

        void SaveData()
        {
            PlayerPrefs.SetInt("Money", PlayerBase.Instance.playerMoney.currentCoins);
            PlayerPrefs.Save();
        }

    IEnumerator LoadSceneWithFade(string sceneName)
    {
        yield return FadeManager.Instance.FadeOut();
        yield return SceneManager.LoadSceneAsync(sceneName);
    }
}
}
