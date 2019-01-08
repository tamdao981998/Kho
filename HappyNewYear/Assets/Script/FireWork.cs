using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FireWork : MonoBehaviour {

    public float speed =0;
    public Text text;
    private Animator anima;
    private Rigidbody2D rig;
	void Start () {
        rig = GetComponent<Rigidbody2D>();
        anima = GetComponent<Animator>();
        StartCoroutine(FireTime());
    }
	
	// Update is called once per frame
	void Update () {
        rig.velocity = new Vector2(rig.velocity.x, speed);
		
	}
    
    private void OnTriggerEnter2D(Collider2D target)
    {
        //if(target.tag == "pa")
        //{
        //    anima.SetBool("true",true);
        //}
    }
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "pa")
        {
            
            Destroy(gameObject, 2.25f);
            rig.velocity = new Vector2(rig.velocity.x, -1f);          
        }
       
    }
    IEnumerator FireTime()
    {
        yield return new WaitForSeconds(Random.Range(0.07f,0.4f));
        anima.SetBool("true", true);
        speed = 0;
        Destroy(gameObject, 2.25f);
        StartCoroutine(FireTime());

    }
}
