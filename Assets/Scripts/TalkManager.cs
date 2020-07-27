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
    public Image ctrUI; //캐릭터 스트라이트를 담는 이미지(talk_ctr)를 담는 공간

    private int day = 2; //텍스트 파일을 구분하기 위한 날짜 변수
    private bool IsTalk = false; //대화 상태를 나타내는 변수

    static string ImageFileName; //이미지 이름을 저장하는 변수
    static string ImageFilePath; //이미지 주소를 저장하는 변수

    List<string> TextFile = new List<string>(); //텍스트 파일을 한줄 씩 저장할 리스트
    string TextRead; //출력할 대사를 담는 변수

    public List<Talk> TextData; //Talk클래스 리스트 호출
    Talk npcdata = new Talk(); //Talk클래스를 사용하는 목록

    void Start()
    {
        ctrUI.color = new Color(npcdata.col, npcdata.col, npcdata.col, npcdata.alp); //캐릭터 스프라이트 투명화
        IsTalk = true;
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

        while (TextRead != null)
        {
        TextReader.ReadLine();

        npcdata.name = TextRead.Split(':')[0]; //대사하는 사람의 이름
        npcdata.talk = TextRead.Split(':')[1]; //대사
        npcdata.ctr = TextRead.Split(':')[2]; //대사하는 사람의 스프라이트
        npcdata.col = float.Parse(TextRead.Split(':')[3]);
        npcdata.alp = int.Parse(TextRead.Split(':')[4]); //대사하는 사람의 Alpha값

        Debug.Log(npcdata.name);
        Debug.Log(npcdata.talk);
        Debug.Log(npcdata.ctr);
        Debug.Log(npcdata.col);
        Debug.Log(npcdata.alp);

        nameUI.text = npcdata.name;
        talkUI.text = npcdata.talk;

        ImageFileName = npcdata.ctr.ToString() + ".png"; //이미지 파일 이름
        ImageFilePath = Application.dataPath + @"\Resources\" + ImageFileName; //이미지 파일 주소
        ctrUI = GetComponent<Image>().sprite = ImageFilePath;
        ctrUI.color = new Color(npcdata.col, npcdata.col, npcdata.col, npcdata.alp);

            if (TextReader == null)
            {
                TextReader.Close(); //사용 후 닫기
                break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Space)) //스페이스바를 눌렀을 때
        {

        }
    }
}

