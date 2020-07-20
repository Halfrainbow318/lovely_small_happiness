using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenMove : MonoBehaviour
{
    public void To01()
    {
        SceneManager.LoadScene("01_MainTitle");
    }

    public void To02()
    {
        SceneManager.LoadScene("02_Newgame");
    }

    public void To06()
    {
        SceneManager.LoadScene("06_Setting");
    }

    public void To07()
    {
        SceneManager.LoadScene("07_Talk");
    }

    public void Toexit()
    {
        Application.Quit();
    }
}