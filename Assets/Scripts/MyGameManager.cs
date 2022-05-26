using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MyGameManager : MonoBehaviour //TEST
{
    public static MyGameManager instance;

    [HideInInspector]
    public bool startGame, failed, successed,tutorialMode;
    public GameObject successPanel;


    public static int LevelCounter=1;
    public static int LevelCounterPlusOne=2;

    private void Awake()
    {
        Application.targetFrameRate = 145; 
        if (instance == null) instance = this;
        //   TinySauce.OnGameStarted(PlayerPrefs.GetInt("CurrentLevel", 1).ToString());

    }

    public void NextLevel()
    {
        // TinySauce.OnGameFinished(true, 1, PlayerPrefs.GetInt("CurrentLevel", 1).ToString());
        //  LoadAsync.GlobalAsync.TriggerManually();
        GameManager.Instance.IsLevelUp=false;
        successPanel.SetActive(false);
        PlayerPrefs.SetInt("CurrentLevel", PlayerPrefs.GetInt("CurrentLevel", 1) + 1);
        SceneManager.LoadScene(0);
        LevelCounter+=1;
        LevelCounterPlusOne+=1;

        
    }


}