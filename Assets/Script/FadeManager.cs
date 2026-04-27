using UnityEngine;
using System.Collections;

public class FadeManager : MonoBehaviour
{

    public CanvasGroup fadeCanvasGroup;

    public float fadeDuration = 0.5f;

    public static FadeManager Instance;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(FadeIn());
    }

    public IEnumerator FadeIn()
    {
        fadeCanvasGroup.alpha = 1;
        float t = 0;
        while(t < fadeDuration)
        {
            t+= Time.deltaTime;

            fadeCanvasGroup.alpha = 1 - ( t /fadeDuration);
            yield return null;
        }
        fadeCanvasGroup.alpha = 0;
    }

    public IEnumerator FadeOut()
    {
        fadeCanvasGroup.alpha = 0;
        float t = 0;
        while(t < fadeDuration)
        {
            t+= Time.deltaTime;

            fadeCanvasGroup.alpha = 1 - t /fadeDuration;
            yield return null;
        }
        fadeCanvasGroup.alpha = 1;
    }
}
