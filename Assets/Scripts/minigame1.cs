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
    private void Update() //타이머를 만들기 위해 Update함수에 넣음
    {
        if (start == true) //게임을 시작 했다면
        {
            if (time > 0) //시간이 0이 아니라면
            {
                time -= Time.deltaTime; //시간을 감소시킴
            }

            timeText.text = Mathf.Ceil(time).ToString(); //시간을 정수로 올림하여 변환함

            if (time <= 0) //시간이 다 되었다면
            {
                minigame1_end.SetActive(true); //게임 종료 창 활성화
                start = false; //게임 종료
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

    public void Best() //미니게임을 성공적으로 완료하였을 경우
    {
        minigame1_end.SetActive(true); //게임 종료 창 활성화
        start = false; //게임 종료
        Result1.text = "정확한 책을 골랐습니다!";
        pm = 10; 
        Result2.text = "호감도가 " + pm + "만큼 증가합니다!";
        luv += pm; 
        Result3.text = "현재 호감도 : " + luv.ToString();
    }

    public void Good() //미니게임을 적당히 완료한 경우
    {
        minigame1_end.SetActive(true); //게임 종료 창 활성화
        start = false; //게임 종료
        Result1.text = "정확하지는 않지만, 그래도 비슷한 책을 골랐네요.";
        pm = 0;
        Result2.text = "호감도가 변하지 않습니다.";
        luv += pm;
        Result3.text = "현재 호감도 : " + luv.ToString();
    }

    public void Fail() //미니게임을 실패하였을 경우
    {
        minigame1_end.SetActive(true); //게임 종료 창 활성화
        start = false; //게임 종료
        Result1.text = "다른 책을 골랐습니다.";
        pm = 5;
        Result2.text = "호감도가 " + pm + "만큼 감소합니다...";
        luv -= pm;
        Result3.text = "현재 호감도 : " + luv.ToString();
    }
}