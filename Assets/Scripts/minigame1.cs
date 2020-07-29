using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;
using UnityEngine.UI;

public class minigame1 : MonoBehaviour
{
    public Text startbutton;
    public Text timeText;
    public Text Result1;
    public Text Result2;
    public Text Result3;
    public GameObject minigame1_end;
    private float time;
    private bool start = false;
    private int pm = 0;
    private int luv = 30;

    private void Awake()
    {
        time = 10f;
    }

    private void Start()
    {
        startbutton.text = " 현재 호감도 : " + luv.ToString();
    }
    private void Update()
    {
        if (start == true)
        {
            if (time > 0)
                time -= Time.deltaTime;

            timeText.text = Mathf.Ceil(time).ToString();

            if (time <=0)
            {
                minigame1_end.SetActive(true);
                start = false;
                Result1.text = "책을 고르지 못했습니다.";
                pm = 5;
                Result2.text = "호감도가 " + pm + "만큼 감소합니다...";
                luv -= pm;
                Result3.text = "현재 호감도 : " + luv.ToString();
            }
        }

    }

    public void Gamestart()
    {
        start = true;
    }

    public void Best()
    {
        start = false;
        Result1.text = "정확한 책을 골랐습니다!";
        pm = 10;
        Result2.text = "호감도가 " + pm + "만큼 증가합니다!";
        luv += pm;
        Result3.text = "현재 호감도 : " + luv.ToString();
    }

    public void Good()
    {
        start = false;
        Result1.text = "정확하지는 않지만, 그래도 비슷한 책을 골랐네요.";
        pm = 0;
        Result2.text = "호감도가 변하지 않습니다.";
        luv += pm;
        Result3.text = "현재 호감도 : " + luv.ToString();
    }

    public void Fail()
    {
        start = false;
        Result1.text = "다른 책을 골랐습니다.";
        pm = 5;
        Result2.text = "호감도가 " + pm + "만큼 감소합니다...";
        luv -= pm;
        Result3.text = "현재 호감도 : " + luv.ToString();
    }
}
