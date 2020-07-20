using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class TalkManager : MonoBehaviour
{
    public Text text;

    private bool talking = true;

    private List<string> scenario;
    private int Count = 0;

    public int day = 0;

    string FilePath;
    string FileName;

    private void Start()
    {
        FileName = "day" + day + ".txt";
        FilePath = @"C:\Users\ohsei\Desktop\ㅇㅅㅇ\문서들\대학\여름_학기\동아리\lovely_small_happiness\Assets\texts\" + FileName;

        scenario = new List<string>();

        ReadFile();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            text.text = scenario[Count];
            Count++;
        }
    }

    public void ReadFile()
    {
        scenario = File.ReadAllLines(FilePath);
        foreach (string line in scenario)
        {
            scenario.Add(line.ToString());
        }
    }
}
