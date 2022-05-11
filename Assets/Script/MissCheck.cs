using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissCheck : MonoBehaviour
{
    HitLine Note;
    Score score;
    void Start()
    {
        Note = GameObject.Find("JudgeMentManager").GetComponent<HitLine>();
        score = GameObject.Find("Score").GetComponent<Score>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.gameObject.SetActive(false);       
        Note.inNote.Remove(collision.gameObject);
        collision.gameObject.transform.position = new Vector3(collision.gameObject.transform.position.x, 5.54f, 0f);
        score.Processing(3);
        
    }
}
