using System.Collections;
using UnityEngine;
using TMPro;

public class Effects : MonoBehaviour
{
    
public void BlinkingText(TextMeshProUGUI text)
{
    StartCoroutine(BlinkTextEffect(text));
}

public void ScalingEffect(Transform target, float duration, float scaleMultiplier = 1.5f)
{
    StartCoroutine(ScaleEffect(target, duration, scaleMultiplier));
}

IEnumerator ScaleEffect(Transform target, float duration, float scaleMultiplier = 1.5f)
{
    Vector3 originalScale = target.localScale;
    Vector3 targetScale = originalScale * scaleMultiplier;

    while (true)
    {
        float elapsedTime = 0f;

        // aumenta
        while (elapsedTime < duration)
        {
            target.localScale = Vector3.Lerp(originalScale, targetScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        target.localScale = targetScale;

        elapsedTime = 0f;

        // diminui
        while (elapsedTime < duration)
        {
            target.localScale = Vector3.Lerp(targetScale, originalScale, elapsedTime / duration);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        target.localScale = originalScale;
    }
}

IEnumerator BlinkTextEffect(TextMeshProUGUI text, float speed = 1f, float minAlpha = 0.2f)
{
    Color color = text.color;
    float time = 0f;

    while (true)
    {
        time += Time.deltaTime * speed;

        float alpha = Mathf.Lerp(minAlpha, 1f, Mathf.PingPong(time, 1));
        color.a = alpha;

        text.color = color;

        yield return null;
    }
}


}
