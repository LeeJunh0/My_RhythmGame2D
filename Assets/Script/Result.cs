using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Result : MonoBehaviour
{
    UIManager uIManager;
    Score score;
    public Text SongScore;
    public Text PerfectScore;
    public Text GoodScore;
    public Text FailScore;
    public Text MissScore;
    public Text MaxComboScore;

    void Start()
    {
        score = GameObject.Find("Score").GetComponent<Score>();        
    }

    // Update is called once per frame
    void Update()
    {
        MaxComboScore.text = score.MaxCombo.ToString();
        SongScore.text = score.Score_.ToString();
        PerfectScore.text = score.Perfect.ToString();
        GoodScore.text = score.Good.ToString();
        FailScore.text = score.Fail.ToString();
        MissScore.text = score.Miss.ToString();
    }
}
