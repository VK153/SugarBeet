using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject Option;
    public static bool optionOn;
    void Start()
    {
        //Option = gameObject.GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Gameexit()
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
        optionOn = true;
    }
    public void OptionOff()
    {
        Option.SetActive(false);
        optionOn = false;
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
