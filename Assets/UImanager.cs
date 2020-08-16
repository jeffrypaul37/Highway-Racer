using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
    public Button[] buttons;
    public Text scoretext;
    int score;
    bool gameover;
    void Start()
    {
        gameover = false;
        score = 0;
        InvokeRepeating("scoreupdate", 1.0f, 0.5f);
    }
    void Update()
    {
        if(SceneManager.GetActiveScene().name=="level1");
        scoretext.text = "Score: " + score;

    }
    void scoreupdate()
    {
        if (!gameover)
            score += 1;
    }
    public void gameoveractivate()
    {
        gameover = true;
        foreach(Button button in buttons)
        {
            button.gameObject.SetActive(true);
        }
        
    }
    public void Play()
    {
        SceneManager.LoadScene("level1");
    }
    public void Pause()
    {
        if (Time.timeScale == 1)
            Time.timeScale = 0;
        else if (Time.timeScale == 0)
            Time.timeScale = 1;
    }

    public void replay()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
    public void menu()
    {
        Application.LoadLevel("menuscene");
    }
    public void exit()
    {
        Application.Quit();
    }
}