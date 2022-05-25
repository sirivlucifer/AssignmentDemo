using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyGameManager : MonoBehaviour
{
    public static MyGameManager instance;

    [HideInInspector]
    public bool startGame, failed, successed,tutorialMode;
    public GameObject successPanel, failPanel, startGamePanel,tutorialPanel;

    [HideInInspector]
    public float ballSize = 0.29f;
    private void Awake()
    {
        Application.targetFrameRate = 145; 
        if (instance == null) instance = this;
        //   TinySauce.OnGameStarted(PlayerPrefs.GetInt("CurrentLevel", 1).ToString());

    }


    public void StartGame()
    {
        //startGame = true;
        //startGamePanel.SetActive(false);
   

    }

    public void Fail()
    {
        if (!failed)
        {
            failed = true;
            failPanel.SetActive(true);
        }
    }
    public void Success()
    {
        successed = true;
        successPanel.SetActive(true);
        PlayerPrefs.SetInt("CurrentLevel", PlayerPrefs.GetInt("CurrentLevel", 1) + 1);
    }

    public void NextLevel()
    {
        // TinySauce.OnGameFinished(true, 1, PlayerPrefs.GetInt("CurrentLevel", 1).ToString());
        //  LoadAsync.GlobalAsync.TriggerManually();
        GameManager.Instance.IsLevelUp=false;
        successPanel.SetActive(false);
        PlayerPrefs.SetInt("CurrentLevel", PlayerPrefs.GetInt("CurrentLevel", 1) + 1);
        SceneManager.LoadScene(0);
        



    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
        // Destroy(this);
    }


}