using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TalkManager : MonoBehaviour
{
    Dictionary<int, string[]> talkData;

    private void Awake()
    {
        talkData = new Dictionary<int, string[]>();
        GenerateData();
    }

    void GenerateData()
    {
        talkData.Add(1000, new string[] { "�ȳ�?", "???���ϳ�?" });
    }

    public string GetTalk(int id, int talkIndex)
    {
        return talkData[id][talkIndex];
    }
}
