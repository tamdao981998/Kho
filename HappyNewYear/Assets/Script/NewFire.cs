using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NewFire : MonoBehaviour {
    public GameObject gam;
    public AudioClip audio;
    public AudioSource sound;
    public Text text;
    public Text txtHPNY;
    public GameObject panel;


    void Start() {
        panel.SetActive(true);
        sound = GetComponent<AudioSource>();
        StartCoroutine(Wait());
        
    }
    public void Shoot()
    {
        Vector3 temp = gam.transform.position;
        temp.x = Random.Range(-2.6f, 2.6f);
        Instantiate(gam, temp, Quaternion.identity);
    }
    IEnumerator Music()
    {
        sound.PlayOneShot(audio);
        yield return new WaitForSeconds(audio.length);
        StartCoroutine(Music());
    }
    IEnumerator Wait()
    {
        int a = int.Parse(text.text);
        yield return new WaitForSeconds(1);
        --a;
        text.text = a.ToString();
        if (a > 0)
        {
            StartCoroutine(Wait());
        }
        if(a==0)
        {
            txtHPNY.text = "Happy New Year";
            panel.SetActive(false);
            text.text = "";
            StartCoroutine(Music());
            Instantiate(gam, new Vector3(0, -3.98f, 0), Quaternion.identity);
        }
    }
}
