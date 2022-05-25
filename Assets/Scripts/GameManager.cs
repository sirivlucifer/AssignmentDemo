using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public bool IsGameStarted=false;
    public GameObject StartingText;
    public GameObject GameOverPanel;
    public GameObject LevelUpPanel;

    public bool IsGameOver=false;
    private bool _levelFailTimerStart = false;
    private float _levelFailTimer = 5f;
    public bool IsLevelUp=false;
    public static GameManager Instance;
    public TextMeshProUGUI CoinText;
    public int score;


    private void Start() {
        if(Instance==null){
            Instance = this;
        }
        score = PlayerPrefs.GetInt("score"); //SAVE SYSTEM
        CoinText.text = score.ToString();
        Debug.Log(PlayerPrefs.GetInt("score"));
    }
    public void ChangeScore(int coinValue){
        PlayerPrefs.SetInt("score",score);
        score += coinValue*10 ;
        Debug.Log("aaaaaa");
        Debug.Log(PlayerPrefs.GetInt("score"));
        PlayerPrefs.SetInt("score",score); //SAVE SYSTEM
        CoinText.text = score.ToString();
    }
    private void Awake() {
          LevelUpPanel.SetActive(false);
          if (instance == null) instance = this;
    }
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
        if(IsLevelUp==true){
            LevelUpPanel.SetActive(true);
        }
        if(IsLevelUp==false){
            LevelUpPanel.SetActive(false);
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
            }
        }
    }
    
    public void FailTimerCalculate(bool state)

    {
        if (state)
        {
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
