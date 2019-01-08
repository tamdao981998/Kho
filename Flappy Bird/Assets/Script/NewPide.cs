using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPide : MonoBehaviour {
    public GameObject pide;
	// Use this for initialization
	void Start () {
        StartCoroutine(New());
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    IEnumerator New()
    {
        yield return new WaitForSeconds(1.5f);
        Vector3 temp = pide.transform.position;
        temp.y = Random.Range(-3.5f, -0.5f);
        transform.position = temp;
        Instantiate(pide, transform.position, Quaternion.identity);  
        StartCoroutine(New());
    }

 
}
