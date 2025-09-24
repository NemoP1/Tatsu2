using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{ 
     [SerializeField] Transform playerTr;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.x < 65)
        {
            transform.position = new Vector3(playerTr.position.x + 6, 0, -10f);
        }
        
    }
}
