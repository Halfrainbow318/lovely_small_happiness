using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;
using UnityEngine.SceneManagement;
using System.Xml.Linq;

public class TalkManager : MonoBehaviour
{
    public static TalkManager instance { get; private set; }

    public Text nameUI; //name을 출력하는 텍스트(talk_nametext)를 담는 공간
    public Text playerName;
    public Text talkUI; //talk를 출력하는 텍스트(talk_scripttext)를 담는 공간
    public SpriteRenderer ctrRender; //캐릭터 스트라이트 렌더
    private Sprite ctrUI; //캐릭터 스트라이트를 담는 이미지를 담는 공간
    public InputField playerInput;

    public GameObject startToMinigame;

    private int day = 4; //텍스트 파일을 구분하기 위한 날짜 변수
    private bool IsTalk = false; //대화 상태를 나타내는 변수

    List<string> TextFile = new List<string>(); //텍스트 파일을 한줄 씩 저장할 리스트
    string TextRead; //출력할 대사를 담는 변수
    int num = 0; //한줄씩 읽는 변수
    int max = 0; //현재 읽고 있는 파일의 줄 갯수

    public List<Talk> TextData; //Talk클래스 리스트 호출
    Talk npcdata = new Talk(); //Talk클래스를 사용하는 목록

    public GameObject Panel;    // 이름 결정 확인 및 게임 스타트 UI

    private string name = "";

    void Start()
    {
        if (instance == null)
        {
            instance = this;
            ctrRender = GameObject.Find("talk_ctrrender").GetComponent<SpriteRenderer>();
            //ctrRender = GetComponent<SpriteRenderer>(); //스프라이트 렌더 선언
            ctrRender.sprite = GetComponent<Sprite>(); //스프라이트와 연결
            ctrRender.color = new Color(npcdata.col, npcdata.col, npcdata.col, npcdata.alp); //캐릭터 스프라이트 투명화
            IsTalk = true; //대화 시작을 알림
            TextFile.Clear(); //리스트 클리어
            ReadFile(); //파일을 읽고 불러와서 출력하는 함수
            max -= 1;
            //startToMinigame = GameObject.Find("MiniGameButton");
            nameUI.text = name;

            Debug.Log(max);

            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        Spacebar();
    }

    private void ReadFile() //파일을 불러와 한줄 씩 저장하는 함수
    {
        TextAsset scenario = Resources.Load("day" + day.ToString()) as TextAsset; //파일을 불러오고 텍스트를 시나리오 텍스트 에셋에 넣기

        StringReader TextReader = new StringReader(scenario.text); //StringReader 선언

        while (TextReader != null) //비어있는 줄이 나올 때 까지 (파일의 맨 끝 줄에 도착할 때 까지)
        {
            TextRead = TextReader.ReadLine(); //파일 한줄 읽기
            max++; //현재 읽고 있는 파일의 마지막 줄 수가 한줄 증가
            TextFile.Add(TextRead); //저장용 리스트에 TextReader로 읽은 문자열 한줄을 추가

            if (string.IsNullOrEmpty(TextRead) == true) //만약 비어있는 줄이 나온다면 (파일의 맨 끝 줄에 도착한다면)
            {
                TextReader.Close(); //사용 후 닫기
                break; //읽기를 그만하고 나오기
            }
        }
    }

    public void Spacebar() //스페이스바를 누를 때 마다 한줄 씩 대사를 출력함
    {
        if (Input.GetKeyDown(KeyCode.Space)) //스페이스바를 눌렀을 때
        {
            TextRead = TextFile[num]; //저장용 리스트의 num번째줄을 불러와 문자형 변수에 저장함

            //TextRead를 ':'을 이용해 나누고 각각의 Talk(라고 이름을 붙인) 클래스의 변수에 저장
            npcdata.name = TextRead.Split(':')[0]; //대사하는 사람의 이름
            npcdata.talk = TextRead.Split(':')[1]; //대사
            npcdata.ctr = int.Parse(TextRead.Split(':')[2]); //대사하는 사람의 스프라이트
            npcdata.col = float.Parse(TextRead.Split(':')[3]); //대사하는 사람의 컬러 값
            npcdata.alp = int.Parse(TextRead.Split(':')[4]); //대사하는 사람의 투명도값

            nameUI.text = npcdata.name; //이름 표시
            talkUI.text = npcdata.talk; //대사 표시

            ctrRender.sprite = Resources.Load("ctr" + npcdata.ctr.ToString(), typeof(Sprite)) as Sprite; //스프라이트 변경
            ctrRender.color = new Color(npcdata.col, npcdata.col, npcdata.col, 100); //색상, 투명도 설정

            num++; //num+1을 해주어 다음 줄을 읽을 수 있게함
            if (num == max) //만약 현재 읽고 있는 줄이 마지막 줄이라면
            {
                startToMinigame.SetActive(true);
                IsTalk = false; //대화를 비활성화함
                Debug.Log("대화종료"); //대화 종료를 알림
            }
        }
    }

    public void SetPlayerName()
    {
        if(playerInput.text != "")
        {
            playerName.text = playerInput.text;
        }
        else
        {
            playerName.text = "김지훈";
        }

        name = playerName.text;

        Panel.SetActive(true);
    }

    public void StartPlay()
    {
        Panel.SetActive(false);
        nameUI.text = name;
        SceneManager.LoadScene("07_Talk");
        ctrRender = GameObject.Find("talk_ctrrender").GetComponent<SpriteRenderer>();
    }
}
