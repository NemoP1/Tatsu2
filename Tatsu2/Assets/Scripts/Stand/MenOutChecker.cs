using UnityEngine;
using TMPro;

public class MenOutChecker : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI finishText;

    private void Start()
    {
        finishText.text = "10秒以内にすすりきれ！";
    }

    // カメラから完全に見えなくなった瞬間に呼ばれる
    private void OnBecameInvisible()
    {
        finishText.text = "天才！";
    }
}
