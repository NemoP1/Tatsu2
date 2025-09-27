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
    [SerializeField] private AudioSource cutSE;

    private bool isStopped = false;
    private bool hasPlayed = false;

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
        

        if (Input.GetMouseButtonDown(0) && !hasPlayed)
        {
            if (pos.x > -0.2f && pos.x < 0.2f)
            {
                isStopped = true;
                hasPlayed = true;
                cutSE.PlayOneShot(cutSE.clip);
                Invoke(nameof(DisableAudioSource), cutSE.clip.length); // 再生が終わったら AudioSource を無効化
                beforePaprika.SetActive(false);
                afterPaprika.SetActive(true);
                Invoke("ChangeScene", 2.0f);
            }
        }
    }
    private void ChangeScene()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("StandScene");
    }
    private void DisableAudioSource()
    {
        cutSE.enabled = false;
    }
}
