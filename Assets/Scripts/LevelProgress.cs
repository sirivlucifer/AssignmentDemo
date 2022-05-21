using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class LevelProgress : MonoBehaviour
{
    [Header ("UI references:")]
    [SerializeField] private Image _uiFillImage;
    [SerializeField] private Text _uiStartText;
    [SerializeField] private Text _uiEndText;
    [Header("Player & Endline References:")]
    [SerializeField] private Transform _playerTransform;
    [SerializeField] private Transform _endLineTransform;
    private Vector3 _endLinePosition;
    private float _fullDistance;
    private void Start(){
        _endLinePosition = _endLineTransform.position;
        _fullDistance = GetDistance();
    }
    public void SetLevelTexts(int level){
        _uiStartText.text = level.ToString();
        _uiEndText.text = (level+1).ToString();
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
