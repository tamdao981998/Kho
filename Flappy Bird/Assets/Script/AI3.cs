using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AI3 : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    private void OnTriggerEnter2D(Collider2D target)
    {

        if (target.tag == "pipe2")
        {
            BirdController.instance.time = 0.05f;
        }
    }
}
