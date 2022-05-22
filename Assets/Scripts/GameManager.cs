using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static bool IsGameStarted=false;
    public GameObject StartingText;
    public GameObject GameOverPanel;

    public static bool IsGameOver=false;
    private bool _levelFailTimerStart = false;
    private float _levelFailTimer = 5f;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)){
            IsGameStarted=true;
            Destroy(StartingText);
        }
        if(IsGameOver){
            GameOverPanel.SetActive(true);
            IsGameStarted=false;
        }
        if(IsGameOver==false){
            GameOverPanel.SetActive(false);
        }
    }
    private void FixedUpdate()
    {
        if (_levelFailTimerStart)
        {
            if (_levelFailTimer > 0)
            {
                _levelFailTimer -=  Time.fixedDeltaTime;
            }
            else
            {
                _levelFailTimerStart = false;
                IsGameOver = true;
                Debug.Log("LevelFailed!");
            }
        }
    }
    
    public void toggleFailTimer(bool state)

    {
        if (state)
        {
            Debug.Log("Timera girdi");
            _levelFailTimer = 3f;
            _levelFailTimerStart = true;
        }
        else
        {
            _levelFailTimerStart = false;
        }
    }

    public void Retry()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        IsGameOver=false;
    }


}
