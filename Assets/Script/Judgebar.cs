using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Judgebar : MonoBehaviour
{
    Sync sync;
    HitLine MusicSpeed;
    void Start()
    {
        sync = GameObject.Find("Sync").GetComponent<Sync>();
        MusicSpeed = GameObject.Find("JudgeMentManager").GetComponent<HitLine>();
    }

    void Update()
    {
        transform.position += Vector3.down * Time.smoothDeltaTime * MusicSpeed.Speed;
        if (transform.position.y < -4.5f)
            this.gameObject.SetActive(false);
    }

}
