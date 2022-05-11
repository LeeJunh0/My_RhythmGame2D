using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public Text scoreText;
    public Text JudgeText;
    public Text Combo;

    public int ComboIdx = 0;
    public int MaxCombo = 0;
    public int Score_ = 0;
    string JudgeName;
    
    public int Perfect = 0;
    public int Good = 0;
    public int Fail = 0;
    public int Miss = 0;
    
    void Start()
    {
        DontDestroyOnLoad(this);
    }

    void Update()
    {
        if (ComboIdx == 0)
            Combo.text = "";
    }
    public void Processing(int idx)
    {
        if(idx == 0)
        {
            Score_ += 500;
            JudgeName = "Perfect";
            JudgeText.color = Color.blue;
            Perfect++;
            ComboIdx++;            
        }
                  
        else if(idx == 1)
        {
            Score_ += 250;
            JudgeName = "Good";
            JudgeText.color = Color.green;
            Good++;
            ComboIdx++;            
        }
        else if(idx == 2)
        {
            Score_ += 50;
            JudgeName = "Fail";
            JudgeText.color = Color.magenta;
            Fail++;
            ComboIdx++;            
        }
        else if(idx == 3)
        {
            JudgeName = "Miss";
            JudgeText.color = Color.red;
            Miss++;
            ComboIdx = 0;            
        }
        SetCombo();
        SetText();
    }

    public void SetCombo()
    {
        if(ComboIdx > MaxCombo)
        {
            MaxCombo = ComboIdx;
        }
    }
    public void SetText()
    {
        scoreText.text = Score_.ToString();
        JudgeText.text = JudgeName;        
        Combo.text = ComboIdx.ToString();
    }
    
}
