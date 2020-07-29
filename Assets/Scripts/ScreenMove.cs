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

    public void To10()
    {
        SceneManager.LoadScene("10_Minigames");
    }

    public void To11()
    {
        SceneManager.LoadScene("11_Minigame1");
    }

    public void To12()
    {
        SceneManager.LoadScene("12_Minigame2");
    }

    public void To13()
    {
        SceneManager.LoadScene("13_Minigame3");
    }

    public void To14()
    {
        SceneManager.LoadScene("14_Minigame4");
    }

    public void To15()
    {
        SceneManager.LoadScene("15_Minigame5");
    }

    public void Toexit()
    {
        Application.Quit();
    }
}