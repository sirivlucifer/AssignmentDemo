using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static bool IsGameStarted=false;
    public GameObject StartingText;
    public GameObject GameOverPanel;

    public static bool IsGameOver=false;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            IsGameStarted=true;
            Destroy(StartingText);
        }
        if(IsGameOver){
            GameOverPanel.SetActive(true);
        }
    }
}
