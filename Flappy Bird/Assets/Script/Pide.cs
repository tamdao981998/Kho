using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pide : MonoBehaviour {

    public static Pide intance;
    public float speed = 3;
    private void Instance()
    {
        if (intance == null)
        {
            intance = this;
        }
    }
    void Update() { 
        Vector3 temp = transform.position;
        temp.x -= speed * Time.deltaTime ;
        transform.position = temp ;
        //Instantiate(gameObject, transform.position, Quaternion.identity);
    }
}
