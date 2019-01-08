using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ConvertScenes : MonoBehaviour {
    public GameObject HighScore;
    public Text Top1;
    public Text Top2;
    public Text Top3;
    public int best_socer;
    
    void Start() {
        HighScore.SetActive(false);   
    }
    void Update() {

        //PlayerPrefs.SetInt("sp", 0);
        //PlayerPrefs.SetInt("sp1", 0);
        //PlayerPrefs.SetInt("sp2", 0);
        Top1.text = PlayerPrefs.GetInt("sp").ToString();
        Top2.text = PlayerPrefs.GetInt("sp1").ToString();
        Top3.text = PlayerPrefs.GetInt("sp2").ToString();
        PlayerPrefs.Save();
    }
    public void ConvertSrceen()
    {
        Application.LoadLevel("SampleScene");
        Time.timeScale = 1;
    }
    public void TopScore()
    {
        HighScore.SetActive(true);
    }
    public void BackMenu()
    {
        HighScore.SetActive(false);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
