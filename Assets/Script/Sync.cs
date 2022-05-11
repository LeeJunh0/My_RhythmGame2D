using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sync : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip NowMusic;
    public GameObject Judgebar;

    public int Judgebartime = 4;
    public float MusicBPM = 195f;
    public float stdBPM = 60f;
    public float Musicbeat = 4f;
    public float frequency;
    public float stdBeat = 4f;
    public float TimeSamples;
    public float beatPerSample = 0f;
    public float nextSample = 0f;
    public float offset = 0.12f;
    public float offsetForSample;
    public float TikTime = 0f;
    public float StartTime = 3.0f;
    
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        frequency = audioSource.clip.frequency;
        TikTime = (stdBPM / MusicBPM) * (Musicbeat / stdBeat);
        offsetForSample = frequency * offset;
        audioSource.PlayDelayed(StartTime);
    }
    void Update()
    {
        TimeSamples = audioSource.timeSamples;
        if (audioSource.timeSamples >= nextSample)
        {
            Judgebartime++;
            StartCoroutine(PlayMusic());            
        }
        if(Judgebartime >= 4)
        {
            GameObject JudgeBarObject = Instantiate(Judgebar);
            JudgeBarObject.transform.position = new Vector3(0, 5.54f, 0);
            Judgebartime = 0;
        }
    }
    IEnumerator PlayMusic()
    {        
        audioSource.PlayOneShot(NowMusic);
        beatPerSample = TikTime * frequency;
        nextSample += beatPerSample;

        yield return null;
    }

}
