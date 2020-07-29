using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class TalkManager : MonoBehaviour
{
    public Text nameUI; //name을 출력하는 텍스트(talk_nametext)를 담는 공간
    public Text talkUI; //talk를 출력하는 텍스트(talk_scripttext)를 담는 공간
    public SpriteRenderer ctrRender; //캐릭터 스트라이트 렌더
    private Sprite ctrUI; //캐릭터 스트라이트를 담는 이미지를 담는 공간

    private int day = 2; //텍스트 파일을 구분하기 위한 날짜 변수
    private bool IsTalk = false; //대화 상태를 나타내는 변수

    List<string> TextFile = new List<string>(); //텍스트 파일을 한줄 씩 저장할 리스트
    string TextRead; //출력할 대사를 담는 변수
    int num = 0; //한줄씩 읽는 변수

    public List<Talk> TextData; //Talk클래스 리스트 호출
    Talk npcdata = new Talk(); //Talk클래스를 사용하는 목록

    void Start()
    {
        ctrRender.GetComponent<SpriteRenderer>(); //스프라이트 렌더 선언
        ctrRender.sprite = ctrUI; //스프라이트와 연결
        ctrRender.color = new Color(npcdata.col, npcdata.col, npcdata.col, npcdata.alp); //캐릭터 스프라이트 투명화
        IsTalk = true; //대화 시작을 알림
        TextFile.Clear(); //리스트 클리어
    }

    void Update()
    {
        ReadFile(); //파일을 읽고 불러와서 출력하는 함수
    }

    private void ReadFile()
    {
        TextAsset scenario = Resources.Load("day" + day.ToString()) as TextAsset; //파일을 불러오고 텍스트를 시나리오 텍스트 에셋에 넣기

        StringReader TextReader = new StringReader(scenario.text); //StringReader 선언

        while (TextRead != null) //비어있는 줄이 나올 때 까지
        {
            TextReader.ReadLine(); //파일 한줄 읽기
            Debug.Log("읽음");
            TextFile.Add(TextReader.ToString());
            Debug.Log("리스트에 넣음");

            npcdata.name = TextRead.Split(':')[0]; //대사하는 사람의 이름
            npcdata.talk = TextRead.Split(':')[1]; //대사
            npcdata.ctr = int.Parse(TextRead.Split(':')[2]); //대사하는 사람의 스프라이트
            npcdata.col = float.Parse(TextRead.Split(':')[3]); //대사하는 사람의 컬러 값
            npcdata.alp = int.Parse(TextRead.Split(':')[4]); //대사하는 사람의 투명도값

            Debug.Log(npcdata.name);
            Debug.Log(npcdata.talk);
            Debug.Log(npcdata.ctr);
            Debug.Log(npcdata.col);
            Debug.Log(npcdata.alp);

            if (TextReader == null) //비어있는 줄이 나온다면
            {
                TextReader.Close(); //사용 후 닫기
                break; //브레이크좀 잡아라 노빠꾸로 다시가네
            }
        }

        nameUI.text = npcdata.name; //이름 표시
        talkUI.text = npcdata.talk; //대사 표시

        ctrRender.sprite = Resources.Load("ctr" + npcdata.ctr.ToString(), typeof(Sprite)) as Sprite; //스프라이트 변경
        ctrRender.color = new Color(npcdata.col, npcdata.col, npcdata.col, npcdata.alp); //색상, 투명도 설정




        if (Input.GetKeyDown(KeyCode.Space)) //스페이스바를 눌렀을 때
        {
            print(TextFile[num]);
            print(num);
            num++;
            if (num>TextFile.Count())
            {
                IsTalk = false; //대화 종료를 알림
                Debug.Log("대화종료");
            }
        }
    }
}

