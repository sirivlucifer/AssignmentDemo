using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class LevelProgress : MonoBehaviour
{

    [Header ("UI references:")]
    [SerializeField] private Image _uiFillImage;
    [SerializeField] private TextMeshProUGUI _uiStartText;
    [SerializeField] private TextMeshProUGUI _uiEndText;
    [Header("Player & Endline References:")]
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _endLineTransform;
    private Vector3 _endLinePosition;
    private float _fullDistance;
    private void Start(){
        _endLinePosition = _endLineTransform.position;
        _fullDistance = GetDistance();
        
    }
    private void Awake() {
        _uiStartText.text = MyGameManager.LevelCounter.ToString();
         _uiEndText.text = MyGameManager.LevelCounterPlusOne.ToString();
    }

    private float GetDistance(){
        return Vector3.Distance(_playerTransform.position,_endLineTransform.position);
    }
    private void UpdateProgressFill(float value){
        _uiFillImage.fillAmount = value;
    }
    private void Update() {
        float newDistance = GetDistance();
        float progressValue = Mathf.InverseLerp(_fullDistance,0f,newDistance);
        UpdateProgressFill(progressValue);
    }

    

}
