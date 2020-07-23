using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TalkManager : MonoBehaviour
{
    public Text scripts;

    private int day = 2;

    private string FilePath;
    private string FileName;

    private string line;

    public List<Talk> Talklist;

    public StringReader stringreader;

    private void Start()
    {
        FileName = "day" + day.ToString() + ".txt";
        FilePath = Application.dataPath + @"\Resources\" + FileName;
        Talklist = new List<Talk>();
    }

    private void Update()
    {
        ReadFile();
    }

    public void ReadFile()
    {
        TextAsset scenario = Resources.Load("day" + day.ToString()) as TextAsset;
        stringreader = new StringReader(scenario.text);


        while (stringreader != null)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                line = stringreader.ReadLine();
                Debug.Log(line);
            }

            if (line == null)
            {
                break;
            }

            Talk npcdata = new Talk();
            npcdata.name = line.Split(':')[0];
            npcdata.say = line.Split(':')[1];
            Talklist.Add(npcdata);
        }
        stringreader.Close();
    }
}
