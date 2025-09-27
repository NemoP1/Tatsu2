using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;
using TMPro;

public class SwipeMoveY : MonoBehaviour
{
    private Vector2 startTouchPos;
    private Vector2 endTouchPos;
    private float moveDistanceY = 0f;
    private bool isSwiping = false;
    private bool isSceneEnd = false;
    private bool isClear = false;
    [SerializeField] private TextMeshProUGUI finishText;
    [SerializeField] private float moveDuration = 0.3f; // アニメーション時間
    
    [SerializeField] private AudioSource moveAudio;
    private Vector3 lastPos;         // 前フレームの位置
    private float stillTimer = 0f;   // 静止している時間を計測

    void Start()
    {
        finishText.text = "10秒以内にすすりきれ！";
        moveAudio.loop = true; // 常にループ再生可能に
        lastPos = transform.position;
        StartCoroutine(TimerCoroutine()); //タイマー開始
    }

    void Update()
    {
        Vector2 pos = transform.position;
        if(isSceneEnd == true || isClear == true)
        {
            return;
        }
        if(Input.GetMouseButtonDown(0))
        {
            isSwiping = true;
            startTouchPos = Input.mousePosition;
        }
        
        if(Input.GetMouseButtonUp(0) && isSwiping)
        {
            isSwiping = false;
            endTouchPos = Input.mousePosition;
            moveDistanceY = (endTouchPos.y - startTouchPos.y)/8;
            if(moveDistanceY >= 0)
            {
                transform.DOMoveY(transform.position.y + moveDistanceY, moveDuration)
                         .SetEase(Ease.OutCubic);
            }
        }

        // --- 移動判定 ---
        if (transform.position != lastPos)
        {
            stillTimer = 0f;

            if (moveAudio != null && !moveAudio.isPlaying)
            {
                moveAudio.Play(); // 動き始めた瞬間に効果音再生
            }
        }
        else
        {
            stillTimer += Time.deltaTime;
            if (stillTimer >= 1f) // 1秒以上止まったら効果音停止
            {
                if (moveAudio != null && moveAudio.isPlaying)
                {
                    moveAudio.Stop();
                }
            }
        }

        lastPos = transform.position;
    }

    private IEnumerator TimerCoroutine()
    {
        yield return new WaitForSeconds(10f); //10秒待機
        isSceneEnd = true;
        SceneManager.LoadScene("DragonScene");
    }

    // カメラから完全に見えなくなった瞬間に呼ばれる
    private void OnBecameInvisible()
    {
        finishText.text = "天才！";
        moveAudio.Stop();
        isClear = true;
    }
}
