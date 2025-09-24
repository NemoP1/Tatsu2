using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CloudHit : MonoBehaviour
{
    [SerializeField] private GameObject cloudEffect;
    private Color color;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        cloudEffect.GetComponent<CloudEffectFade>().Play();
        gameObject.SetActive(false);
    }
}
