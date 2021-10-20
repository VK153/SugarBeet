using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public bool isGameStart = true;
    public bool isGameOver = false;
    private string NowScene;


    public GameObject startUI, overUI, pauseMenu;
    public bool pause = false;

    // Start is called before the first frame update
    void Start()
    {
        gm = this;
        //startUI = GameObject.Find("GameStartUI").gameObject;
        overUI = GameObject.Find("GameOverUI").gameObject;
        //Time.timeScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!pause && Input.GetButtonDown("Cancel"))
        {
            Time.timeScale = 0;
            pauseMenu.gameObject.SetActive(true);
            pause = true;
        }
        else if(pause && Input.GetButtonDown("Cancel"))
        {
            Time.timeScale = 1;
            pauseMenu.gameObject.SetActive(false);
            pause = false;
        }
    }

    //public void GameStart()
    //{
    //    isGameStart = true;
    //    startUI.gameObject.SetActive(false);
    //    Time.timeScale = 1;
    //}

    public void GameOver()
    {
        isGameOver = true;
        for(int i=0; i < 1; i++)
        {
            overUI.transform.GetChild(i).gameObject.SetActive(true);
        }
        Time.timeScale = 0;
    }
    public void Resume()
    {
        Time.timeScale = 1;
        pauseMenu.gameObject.SetActive(false);
        pause = false;
    }
    public void ReStart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void GameExit()
    {
        Application.Quit();
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("000_MainMenu");
        Time.timeScale = 1;
    }
}
