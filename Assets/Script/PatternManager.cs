using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PatternManager : MonoBehaviour
{
    public GameObject[] ListLine;
    public GameObject PrefabPinkNote;
    public GameObject PrefabBlueNote;
    public GameObject PrefabJudgebar;
    public GameObject Note;
    HitLine hit;
    Sync sync;
    public List<int> NoteList = new List<int>();
    public List<float> NoteTime = new List<float>();
    public int NoteSum;
    public float NodeTime = 0f;
    public int Idx = 0;
    public float NowTime;
    public float StartTime;
    public float JudgeTime;

    private void Start()
    {
        sync = GameObject.Find("Sync").GetComponent<Sync>();
        hit = GameObject.Find("JudgeMentManager").GetComponent<HitLine>();
        StartTime = sync.StartTime;
        NowTime -= StartTime;
        
        List<Dictionary<string, object>> Notedata = CSVReader.Read("NoteLog");
        NoteSum = Convert.ToInt32(Notedata[0]["NoteSum"]);
        for (int i = 0; i < NoteSum; i++)
        {
            int note = Convert.ToInt32(Notedata[i]["Note"]);
            float time = Convert.ToInt32(Notedata[i]["Time"]);
            NoteList.Add(note);
            NoteTime.Add(time);
            
        }
    }
    void Update()
    {        
        NowTime += Time.smoothDeltaTime;
        
        JudgeTime = sync.frequency * sync.TikTime;

        if (NodeTime <= NowTime)
        {                       
            if (Idx < NoteSum)
            {
                NodeTime = NoteTime[Idx] / 1000;
                CreatNode();
                hit.NoteList.Add(Note);
                Idx++;             
            }           
        }
        if(sync.TimeSamples  >= 6067571)
        {
            SceneManager.LoadScene("ResultScene");
        }
        
    }
    void CreatNode()
    {
        if (0 == NoteList[Idx] || 3 == NoteList[Idx])
        {
            Note = Instantiate(PrefabPinkNote);
            if(NoteList[Idx] == 0)
            {
                Note.transform.position = new Vector3(-2.25f, 5.54f, 0);
            }
            else
            {
                Note.transform.position = new Vector3(2.25f, 5.54f, 0);
            }
        }
        else if (1 == NoteList[Idx] || 2 == NoteList[Idx])
        {
            Note = Instantiate(PrefabBlueNote);
            if (NoteList[Idx] == 1)
            {
                Note.transform.position = new Vector3(-0.75f, 5.54f, 0);
            }
            else
            {
                Note.transform.position = new Vector3(0.75f, 5.54f, 0);
            }
        }
    }
    void CreatJudge()
    {
        GameObject Judgebar = Instantiate(PrefabJudgebar);
        Judgebar.transform.position = new Vector3(0, 5.54f, 0);
    }

    IEnumerator JudgeCreat(float nextTime)
    {
        yield return new WaitForSeconds(nextTime);
        CreatJudge();
    }
}


