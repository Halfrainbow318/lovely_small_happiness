using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Security.Authentication.ExtendedProtection;

public class TalkManager : MonoBehaviour
{
    public Text text;

    private int day = 2;

    string FilePath;
    string FileName;

    list<string> scene = new List<string>();

    private void Start()
    {
        FileName = "day" + day + ".txt";
        FilePath = @"C:\Users\ohsei\Desktop\ㅇㅅㅇ\문서들\대학\여름_학기\동아리\lovely_small_happiness\Assets\texts\" + FileName;

        ReadFile();
    }

    public void ReadFile()
    {
        TextAsset scenario = texts.Load("day" + day) as TextAsset;
        StringReader stringreader = new Stringreader(scenario.text);
        
        while (stringreader != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                string line = stringreader.ReadLine();
            }

            if (line == null)
            {
                break;
            }

            Talk npcdata = new Talk();
            npcdata.name = line.Split(':')[0];
            npcdata.say = line.Split(':')[1];
            scene.Add(npcdata);
        }
    }
}
