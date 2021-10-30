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

    public int mobCount = 0, mobMaxCount = 0;//몹의 수,최대 몹의수

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
        if(!pause && Input.GetButtonDown("Cancel"))//메뉴 열기 및 정지
        {
            Time.timeScale = 0;
            pauseMenu.gameObject.SetActive(true);
            pause = true;
        }
        else if(pause && Input.GetButtonDown("Cancel"))//메뉴 닫기 및 계속
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

    public void GameOver() //사망시 화면
    {
        isGameOver = true;
        for(int i=0; i < 1; i++)
        {
            overUI.transform.GetChild(i).gameObject.SetActive(true);
        }
        Time.timeScale = 0;
    }
    public void Resume() //계속하기
    {
        Time.timeScale = 1;
        pauseMenu.gameObject.SetActive(false);
        pause = false;
    }
    public void ReStart() //재시작
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1;
    }

    public void GameExit() //게임종료
    {
        Application.Quit();
    }

    public void MainMenu() //메인메뉴로
    {
        SceneManager.LoadScene("000_MainMenu");
        Time.timeScale = 1;
    }
}
