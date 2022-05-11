using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitLine : MonoBehaviour
{
    public List<GameObject> NoteList = new List<GameObject>();
    public List<GameObject> inNote = new List<GameObject>();
    Score score;
    
    public float Speed;


    float Center;
    public GameObject[] JudgeScale;
    public GameObject CenterObject;
    Vector2[] Judgedir;
    private void Start()
    {
        Center = CenterObject.transform.position.y;
        Judgedir = new Vector2[JudgeScale.Length];
        score = GameObject.Find("Score").GetComponent<Score>();
        for (int i = 0; i < Judgedir.Length; i++)
        {
            Judgedir[i] = new Vector2( Center + JudgeScale[i].transform.localScale.y/2 ,
                                       Center - JudgeScale[i].transform.localScale.y/2 );
        }
    }
    private void Update()
    {
        

        if (NoteList.Count != 0)
        {
            if (Judgedir[2].x >= NoteList[0].transform.position.y && Judgedir[2].y <= NoteList[0].transform.position.y)
            {
                inNote.Add(NoteList[0]);
                NoteList.RemoveAt(0);
            }
        }

        if (inNote.Count != 0)
        {            
            if (Input.GetKeyDown(KeyCode.D))
            {              
                if (Search(-2.25f) != -1)
                {
                    CheckNote(Search(-2.25f));
                    //Combo.text = string.Format(ComboIdx);
                }                   
            }
            if (Input.GetKeyDown(KeyCode.F))
            {
                if(Search(-0.75f)!= -1)
                    CheckNote(Search(-0.75f));
            }              
            if (Input.GetKeyDown(KeyCode.J))
            {
                if(Search(0.75f) != -1)
                    CheckNote(Search(0.75f));
            }              
            if (Input.GetKeyDown(KeyCode.K))
            {
                if (Search(2.25f) != -1)
                    CheckNote(Search(2.25f));
            }
            
        }
    }
    void CheckNote(int idx)
    {        
        if(inNote[0] != null)
        {
            for (int j = 0; j < Judgedir.Length; j++)
            {
                if (Judgedir[j].x >= inNote[idx].transform.position.y && Judgedir[j].y <= inNote[idx].transform.position.y)
                {
                    if (inNote[idx].activeSelf != false)
                    {
                        inNote[idx].SetActive(false);
                        inNote[idx].transform.position = new Vector3(inNote[idx].transform.position.x, 5.54f, 0f);
                        inNote.RemoveAt(idx);
                        score.Processing(j);
                        break;
                    }
                }  
            }
            
        }       
    }
    int Search(float NotedirX)
    {
        int Idx;
        for(Idx = 0; Idx < inNote.Count; Idx++)
        {
            if (NotedirX == inNote[Idx].transform.position.x)
                return Idx;    
        }
        return -1;
    }
}

 //    if (NoteList[0].transform.position.x == -2.245f && Input.GetKeyDown(KeyCode.D))
 //    {
 //        Debug.Log("Hit : " + JudgeScale[JudgeIdx].name);
 //        NoteList[0].SetActive(false);
 //    }

//    if (NoteList[0].transform.position.x == -0.75f && Input.GetKeyDown(KeyCode.F))
//        Debug.Log("Hit : " + JudgeScale[JudgeIdx].name);
//    if (NoteList[0].transform.position.x == 0.75f && Input.GetKeyDown(KeyCode.J))
//        Debug.Log("Hit : " + JudgeScale[JudgeIdx].name);
//    if (NoteList[0].transform.position.x == 2.245f && Input.GetKeyDown(KeyCode.K))
//        Debug.Log("Hit : " + JudgeScale[JudgeIdx].name);
//    if (NoteList[0].transform.position.y < -4.5f)
//    {
//        NoteList[0].SetActive(false);
//    }
//}
//else
//    continue;


