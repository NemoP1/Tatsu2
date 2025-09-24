using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class SwipeMoveY : MonoBehaviour
{
    private Vector2 startTouchPos;
    private Vector2 endTouchPos;
    private float moveDistanceY = 0f;
    private bool isSwiping = false;
    private bool isSceneEnd = false;

    [SerializeField] private float moveDuration = 0.3f; // アニメーション時間
    
    void Start()
    {
        StartCoroutine(TimerCoroutine()); //タイマー開始
    }

    void Update()
    {
        Vector2 pos = transform.position;
        if(isSceneEnd == true)
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
    }

    private IEnumerator TimerCoroutine()
    {
        yield return new WaitForSeconds(10f); //10秒待機
        isSceneEnd = true;
        SceneManager.LoadScene("DragonScene");
    }
}
