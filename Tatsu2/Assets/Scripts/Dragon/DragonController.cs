using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragonController : MonoBehaviour
{
    public float speed = 5.0f;
    private Rigidbody2D rb;
    private Vector2 startTouchPos;
    private Vector2 endTouchPos;
    private float laneWidth = 3f; // レーンの幅
    private int currentLane = 0; 

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(speed, 0);
        MoveToLane(); // 初期位置を中央に
    }

    // Update is called once per frame
    void Update()
    {
         // タッチ開始
        if (Input.GetMouseButtonDown(0))
        {
            startTouchPos = Input.mousePosition;
        }

        // タッチ終了
        if (Input.GetMouseButtonUp(0))
        {
            endTouchPos = Input.mousePosition;
            DetectSwipe();
        }

        if (Input.GetKeyDown (KeyCode.UpArrow) || Input.GetKeyDown (KeyCode.W)) {
            MoveUp();
        }
        if (Input.GetKeyDown (KeyCode.DownArrow) || Input.GetKeyDown (KeyCode.S)) {
            MoveDown();
        }
    }

    void DetectSwipe()
    {
        Vector2 swipe = endTouchPos - startTouchPos;

        if (swipe.y > 70f && Mathf.Abs(swipe.y) > Mathf.Abs(swipe.x)) //上
        {
            MoveUp();
        }
        if (swipe.y < -70f && Mathf.Abs(swipe.y) > Mathf.Abs(swipe.x)) //下
        {
            MoveDown();
        }
    }

    void MoveUp()
    {
        if (currentLane < 1) // 上段は +1 まで
        {
            currentLane++;
            MoveToLane();
        }
    }
    void MoveDown()
    {
        if (currentLane > -1) // 下段は -1 まで
        {
            currentLane--;
            MoveToLane();
        }
    }

    void MoveToLane()
    {
        // レーン番号からY座標を決定
        float targetY = currentLane * laneWidth;
        transform.position = new Vector2(transform.position.x, targetY);
    }
}
