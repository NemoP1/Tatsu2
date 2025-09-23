using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI limitText;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private TextMeshProUGUI scoreText;
    private float limitTime;
    private float start; // 計測の開始時間を格納
    private bool beingMeasured; //計測中かどうか
    private bool ended; //終了したかどうか
    private float elapsedTime; // 経過時間を格納

    // Start is called before the first frame update
    void Start()
    {
        elapsedTime = 0f;
        beingMeasured = false; 
        ended = false;
        limitTime = Random.Range(7.9f, 13.9f);
        timerText.text = "0.0秒";
        limitText.text = limitTime.ToString("0.0") + "秒で止めろ！";
    }

    // Update is called once per frame
    void Update()
    {
        if (ended) return;

        if (Input.GetMouseButtonDown(0))
        {
            beingMeasured = !beingMeasured;
            if (beingMeasured)
            {
                start = Time.time; // 開始時間を格納
                timerText.text = "計測中...";
            }
            else
            {
                elapsedTime = Time.time - start; // 経過時間を格納
                timerText.text = elapsedTime.ToString("0.0") + "秒";
                float difference = Mathf.Abs(limitTime - elapsedTime); //絶対値
                if(limitTime.ToString("0.0") == elapsedTime.ToString("0.0"))
                {
                    scoreText.text = "ピッタリ！";
                }
                else if(difference <= 0.3f)
                {
                    scoreText.text = "おしい！";
                }
                else if(difference <= 2.0f)
                {
                    scoreText.text = "いいね！";
                }
                else
                {
                    scoreText.text = "伸びしろあり！";
                }
                ended = true; // 計測終了
                Invoke("ChangeScene", 2.0f); 
            }
        }
    }
    void ChangeScene()
    {
        SceneManager.LoadScene("CutScene");
    }
}
