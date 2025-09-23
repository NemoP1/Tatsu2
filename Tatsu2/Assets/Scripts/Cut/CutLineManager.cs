using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutLineManager : MonoBehaviour
{
    private Vector2 pos;
    public int direction = 1;
    [SerializeField] private float rightLimit;
    [SerializeField] private float leftLimit;
    [SerializeField] private float speed;

    [SerializeField] private GameObject beforePaprika;
    [SerializeField] private GameObject afterPaprika;

    private bool isStopped = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        pos = transform.position;

        if (!isStopped)
        {
            transform.Translate(transform.right * Time.deltaTime * speed * direction);
         
            if(pos.x > rightLimit)
            {
                direction = -1;
            }
            if(pos.x < leftLimit)
            {
                direction = 1;
            }
        }
        

        // クリック検知
        if (Input.GetMouseButtonDown(0))
        {
            // pos.x が -0.1 ～ 0.1 の範囲に入っているか判定
            if (pos.x > -0.2f && pos.x < 0.2f)
            {
                isStopped = true; // 停止
                beforePaprika.SetActive(false);
                afterPaprika.SetActive(true);
                Invoke("ChangeScene", 2.0f); // 2秒後にChangeSceneを呼び出す
            }
        }
    }
    private void ChangeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StandScene");
    }
}
