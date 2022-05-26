using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{

    public static LevelManager instance;
    int lastLevel;

    public int totalLevelCount;



    private void Awake()
    {
        if (instance == null) instance = this;

        PlayerPrefs.GetInt("LastLevel", 1);
        int currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);
        if (currentLevel > totalLevelCount && PlayerPrefs.GetInt("IsRestart") == 1)
        {

            Instantiate(Resources.Load("Levels/" + "Level" + PlayerPrefs.GetInt("LastLevel")) as GameObject);
        }
        else if (currentLevel <= totalLevelCount)
        {
            Instantiate(Resources.Load("Levels/" + "Level" + currentLevel) as GameObject);
        }
        else
        {
            lastLevel = Random.Range(2, totalLevelCount + 1);
            Debug.Log("last" + lastLevel); // TEST
            PlayerPrefs.SetInt("LastLevel", lastLevel);
            Instantiate(Resources.Load("Levels/" + "Level" + lastLevel) as GameObject);
        }
    }

}