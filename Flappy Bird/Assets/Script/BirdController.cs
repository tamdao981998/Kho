using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BirdController : MonoBehaviour
{
    public static BirdController intance;
    public static BirdController instance;
    public GameObject HightScoceWhite, HightScoceYellow, HightScoceOrange;
    public GameObject GAMAI;

    public AudioSource audio;
    public AudioClip dead, ping, fly;
    public Text text;
    public Text hightscore;
    public float flag;
    public float speed = 0;
    public float time = 0.5f;
    public int result;
    public int a;

    private Rigidbody2D rig;
    private Animator Anima;
    private bool iss;
    private bool ssi;
    private GameObject newpipe;
    //void Start()
    //{
    //    rig.velocity = new Vector2(rig.velocity.x, speed);
    //    StartCoroutine(AI());
    //}
    IEnumerator AI()
    {
        yield return new WaitForSeconds(time);
        rig.velocity = new Vector2(rig.velocity.x, speed);    
        StartCoroutine(AI());
        audio.PlayOneShot(fly);
    }
    void Awake()
    {
        HightScoceOrange.SetActive(false);
        HightScoceYellow.SetActive(false);
        HightScoceWhite.SetActive(false);
        iss = true;
        rig = GetComponent<Rigidbody2D>();
        Anima = GetComponent<Animator>();
        Instance();
        newpipe = GameObject.Find("NewPipe");
    }
    private void Intance()
    {
        if (intance == null)
        {
            intance = this;
        }
    }
    private void Instance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
   
    void FixedUpdate()// lấy trục y của bird gán cho GAMAI 
    {
        Vector3 temp = transform.position;
        temp.y = transform.position.y;
        temp.x =1.3f;
        GAMAI.transform.position = temp;
        Bird();
    }
    public void Bird()
    {
        if (iss)
        {
            if (ssi)
            {
                ssi = false;
                rig.velocity = new Vector2(rig.velocity.x, speed);
                audio.PlayOneShot(fly);
            }
        }
        if (rig.velocity.y > 0)
        {
            float a = 0;
            a = Mathf.Lerp(0, 70, rig.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, a);
        }
        else if (rig.velocity.y == 0)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
        }
        else if (rig.velocity.y < 0)
        {
            float a = 0;
            a = Mathf.Lerp(0, -70, -rig.velocity.y / 7);
            transform.rotation = Quaternion.Euler(0, 0, a);
        }
    }
    private void OnCollisionEnter2D(Collision2D target)
    {
        if (target.gameObject.tag == "pipe" || target.gameObject.tag == "pipe2" || target.gameObject.tag == "background")
        {
            flag = 1;
            Destroy(newpipe.gameObject);
            iss = false;
            audio.PlayOneShot(dead);
            Gameplay.instance.ManagementScore.SetActive(true);
            hightscore.text = text.text;
            result = int.Parse(hightscore.text);
            int a = PlayerPrefs.GetInt("sp");
            int b = PlayerPrefs.GetInt("sp1");
            int c = PlayerPrefs.GetInt("sp2");
            if (result > a)
            {
                PlayerPrefs.SetInt("sp", result);
            }
            if (result < a && result > b)
            {
                PlayerPrefs.SetInt("sp1", result);
            }
            if (result < b && result > 0)
            {
                PlayerPrefs.SetInt("sp2", result);
            }
            if (result > 10)
            {
                HightScoceWhite.SetActive(true);
            }
            if (result > 50)
            {
                HightScoceYellow.SetActive(true);
            }
            if (result > 100)
            {
                HightScoceOrange.SetActive(true);
            }
            Time.timeScale = 0;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);//Tự động load lại game khi chết
        }
    }

    private void OnTriggerEnter2D(Collider2D target)
    {
        if (target.tag == "Ping")
        {
            audio.PlayOneShot(ping);
            a++;
            text.text = a.ToString();
        }
    }
    public void flappy()
    {
        ssi = true;
    }
}
