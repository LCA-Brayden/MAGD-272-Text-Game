using UnityEngine;
using System.Collections;

public class ImageFader : MonoBehaviour
{

    void Start()
    {
        FadeIn();
    }


    public void FadeOut()
    {
        StartCoroutine(FadeOutC());
    }
    public void FadeIn()
    {
        StartCoroutine(FadeInC());
    }

    IEnumerator FadeOutC()
    {
        CanvasGroup canvasGroup1 = GetComponent<CanvasGroup>();
        while (canvasGroup1.alpha > 0)
        {
            canvasGroup1.alpha -= Time.deltaTime / 2;
            yield return null;
        }
        canvasGroup1.interactable = false;
        yield return null;
    }
    IEnumerator FadeInC()
    {
        CanvasGroup canvasGroup2 = GetComponent<CanvasGroup>();
        while (canvasGroup2.alpha < 1)
        {
            canvasGroup2.alpha += Time.deltaTime / 2;
            yield return null;
        }
        canvasGroup2.interactable = true;
        yield return null;
    }
}
