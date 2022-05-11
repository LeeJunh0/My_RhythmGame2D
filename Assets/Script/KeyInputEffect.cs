using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyInputEffect : MonoBehaviour
{
    public GameObject[] KeyEffectLine;

    void Update()
    {        
        if (Input.GetKeyDown(KeyCode.D))
            KeyEffectLine[0].SetActive(true);
        else if(Input.GetKeyUp(KeyCode.D))
            KeyEffectLine[0].SetActive(false);

        if (Input.GetKeyDown(KeyCode.F))
            KeyEffectLine[1].SetActive(true);
        else if (Input.GetKeyUp(KeyCode.F))
            KeyEffectLine[1].SetActive(false);

        if (Input.GetKeyDown(KeyCode.J))
            KeyEffectLine[2].SetActive(true);
        else if (Input.GetKeyUp(KeyCode.J))
            KeyEffectLine[2].SetActive(false);

        if (Input.GetKeyDown(KeyCode.K))
            KeyEffectLine[3].SetActive(true);
        else if (Input.GetKeyUp(KeyCode.K))
            KeyEffectLine[3].SetActive(false);

    }
}
