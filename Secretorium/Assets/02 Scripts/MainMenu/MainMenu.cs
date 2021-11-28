using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public GameObject Option,Story, story1, story2;
    public Button storyButton1, storyButton2;
    public static bool uiOn;
    public int Story2 = 0;
    void Start()
    {
        Story2 = PlayerPrefs.GetInt("Story", 0);
        Debug.Log(Story2);
    }

    // Update is called once per frame
    void Update()
    {
        if(SceneManager.GetActiveScene().name == "000_MainMenu")
        { 
            if (Story2 == 1)
            {
                storyButton2.interactable = true;
            }
            else
            {
                storyButton2.interactable = false;
            }
        }
        
    }
    public void GameExit()
    {
        Application.Quit();
    }
    public void Gamestart()
    {
        SceneManager.LoadScene("101_StageScene");
    }
    public void OptionOn()
    {
        Option.SetActive(true);
        uiOn = true;
    }
    public void OptionOff()
    {
        Option.SetActive(false);
        uiOn = false;
    }
    public void StoryOn()
    {
        Story.SetActive(true);
        uiOn = true;
    }
    public void Story_1()
    {
        story1.SetActive(true);
        story2.SetActive(false);
    }
    public void Story_2()
    {
        story1.SetActive(false);
        story2.SetActive(true);
    }
    public void StoryOff()
    {
        Story.SetActive(false);
        uiOn = false;
    }
    public void ResetGame()
    {
        PlayerPrefs.DeleteAll();
        uiOn = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void StoryOpen()
    {
        PlayerPrefs.SetInt("Story", 1);
        uiOn = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void Screen1280W()
    {
        Screen.SetResolution(1280, 720, false);
    }
    public void Screen1280F()
    {
        Screen.SetResolution(1280, 720, true);
    }
    public void Screen1366W()
    {
        Screen.SetResolution(1366, 768, false);
    }
    public void Screen1366F()
    {
        Screen.SetResolution(1366, 768, true);
    }
    public void Screen1920W()
    {
        Screen.SetResolution(1920, 1080, false);
    }
    public void Screen1920F()
    {
        Screen.SetResolution(1920, 1080, true);
    }
}
