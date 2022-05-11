using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{

    public void SetStart()
    {
        SceneManager.LoadScene("PlayScene");
    }
    public void SetMain()
    {
        SceneManager.LoadScene("MainScene");
    }
    public void GameExit()
    {
        Application.Quit();
    }
}
