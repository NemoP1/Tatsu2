using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HitController : MonoBehaviour
{
    [SerializeField] private GameObject finishUI;
    [SerializeField] private GameObject failUI;
    [SerializeField] private GameObject cloudEffect;
    [SerializeField] private TextMeshProUGUI coinText;
    private int coinCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        finishUI.SetActive(false);
        failUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Goal")
        {
            finishUI.SetActive(true);
        }
        else if (other.gameObject.tag == "Cloud")
        {
            cloudEffect.GetComponent<CloudEffectFade>().Play();
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "Coin")
        {
            coinCount++;
            coinText.text = "×" + coinCount.ToString();
            other.gameObject.SetActive(false);
        }
        else if (other.gameObject.tag == "Wind")
        {
            failUI.SetActive(true);
            Time.timeScale = 0; 
        }
    }
}
