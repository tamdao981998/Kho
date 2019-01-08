using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Gameplay : MonoBehaviour
{
    // Use this for initialization
    public static Gameplay instance;
    public GameObject panel;
    public GameObject ManagementScore;
    public float flag;
    void Awake()
    {
        panel.SetActive(false);
        ManagementScore.SetActive(false);
        Instance();
    }
    private void Instance()
    {
        if (instance == null)
        {
            instance = this;
        }
    }
    public void Restart1()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
    public void Restart()
    {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            Time.timeScale = 1;
    }
    public void ReturnMenu()
    {
        Application.LoadLevel("StartGame");
    }
}
