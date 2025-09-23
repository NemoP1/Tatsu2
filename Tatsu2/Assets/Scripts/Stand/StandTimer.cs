using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StandTimer : MonoBehaviour
{
    void Start()
    {
        // Start()でタイマー開始
        StartCoroutine(TimerCoroutine());
    }

    private IEnumerator TimerCoroutine()
    {
        // 10秒待機
        yield return new WaitForSeconds(10f);

        // シーン遷移
        SceneManager.LoadScene("DragonScene");
    }
}
