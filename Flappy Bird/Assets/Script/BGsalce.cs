using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGsalce : MonoBehaviour
{
    void Start()
    {
        SpriteRenderer sp = GetComponent<SpriteRenderer>();
        Vector3 temp = transform.localScale;
        float h = sp.bounds.size.y;
        float w = sp.bounds.size.x;
        float height = Camera.main.orthographicSize * 2f; // phóng to = camera
        float width = height * Screen.width / Screen.height;
        temp.y = height / h;
        temp.x = width / w;
        transform.localScale = temp;
    }
    void Update()
    {

    }
}
