using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasiFollow : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // マウス座標（スクリーン座標 → ワールド座標）
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 newPos = transform.position;
        newPos.y = mousePos.y;
        transform.position = newPos;
    }
}
