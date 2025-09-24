using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class CloudEffectFade : MonoBehaviour
{
    private Image cloudImage;
    private Color color;

    void Awake()
    {
        cloudImage = GetComponent<Image>();
        color = cloudImage.color;
        color.a = 0f; //透明
        cloudImage.color = color; //更新
    }

    public void Play()
    {
        StartCoroutine(FadeInOut()); 
    }

    private IEnumerator FadeInOut()
    {
        // フェードイン
        float duration = 0.1f;
        float time = 0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            color.a = Mathf.Lerp(0f, 1f, t);
            cloudImage.color = color;
            yield return null;
        }

        // 少し待つ
        yield return new WaitForSeconds(1.2f);

        // フェードアウト
        duration = 0.3f;
        time = 0f;
        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;
            color.a = Mathf.Lerp(1f, 0f, t);
            cloudImage.color = color;
            yield return null;
        }
        //Destroy(gameObject);
    }
}
