using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Note : MonoBehaviour
{
    HitLine MusicSpeed;
    Vector2 lerpPos;
    void Start()
    {
        MusicSpeed = GameObject.Find("JudgeMentManager").GetComponent<HitLine>();
    }

    
    void Update()
    {
        Vector2 NotePosition = new Vector2(transform.position.x,transform.position.y - Time.smoothDeltaTime * MusicSpeed.Speed);       
        transform.position = NotePosition;
    }

}
