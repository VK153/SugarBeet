﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;

    public bool isGameStart = true, isGameOver = false ,isGameClear = false;
    public float time = 0f;


    public GameObject startUI, overUI, pauseMenu, listenerO, clearText;
    Text ClearText;
    AudioListener listener;
    public bool pause = false;

    public int mobCount = 0, mobMaxCount = 0, spawnerCount = 0;//몹의 수,최대 몹의수,스포너의 수
    void Start()
    {
        listener = listenerO.GetComponent<AudioListener>();
        gm = this;
        overUI = GameObject.Find("GameOverUI").gameObject;
        ClearText = clearText.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update() 
    {
        if(!isGameClear)
        time += Time.deltaTime;
        else
        time -= Time.deltaTime;
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
        if (pause)
        {
            Time.timeScale = 0f;
        }
        else if (!pause)
        {
            Time.timeScale = 1;
        }
        if(time > 10 && spawnerCount <= 0)
        {
            isGameClear = true;
            PlayerPrefs.SetInt("Story", 1);
            time = 6f;
            clearText.SetActive(true);
        }
        ClearText.text = "StageClear!!\nMove To Main\n\n" + (int)time;
        if(time <= 0 && isGameClear)
        {
            SceneManager.LoadScene("000_MainMenu");
        }
    }
    public void GameOver() //사망시 화면
    {
        isGameOver = true;
        for(int i=0; i < 1; i++)
        {
            overUI.transform.GetChild(i).gameObject.SetActive(true);
        }
    }
    public void Resume() //계속하기
    {
        Time.timeScale = 1;
        pauseMenu.gameObject.SetActive(false);
        pause = false;
    }
    public void ReStart() //재시작
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
