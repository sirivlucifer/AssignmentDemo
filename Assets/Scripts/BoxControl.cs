using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using DG.Tweening;
public class BoxControl : MonoBehaviour
{
    private bool _isCompleted = false;
    public int RequiredPickups = 3;
    public int CurrentPickups = 0;
    public TextMeshProUGUI CurrentPickupsText;
    public TextMeshProUGUI RequiredPickupsText;
    public GameObject Elevator;
    public GameObject DoorLeft;
    public GameObject DoorRight;
    private float _timer = 2.5f;
    private float _moveTime = 2.5f;
    public ParticleSystem Efect,Efect2,Efect3;


    private void Awake() {
        CurrentPickupsText.text = CurrentPickups.ToString();
        RequiredPickupsText.text = " / " + RequiredPickups.ToString();
    }
    private void FixedUpdate() {
    if(_isCompleted){
        if(CurrentPickups >= RequiredPickups){//this if needed because of other level will be bug if it is not.
        FindObjectOfType<GameManager>().FailTimerCalculate(false);
            if(_timer > 0){//do after 2.5 seconds.
                _timer -= Time.fixedDeltaTime;
            }else{
                //elevator animation.
                Elevator.transform.DOMoveY(0,1f);
                DoorLeft.transform.DOLocalRotate(new Vector3(50,0,0),2.5f);
                DoorRight.transform.DOLocalRotate(new Vector3(-50,0,0),2.5f);
                Efect.Play();
                Efect2.Play();
                Efect3.Play();
                Efect.transform.position = DoorLeft.transform.position ;
                Efect2.transform.position =   DoorRight.transform.position ;
                Efect3.transform.position =   Elevator.transform.position ;
                if(_moveTime >0){
                 _moveTime -= Time.fixedDeltaTime;
            }else{
                FindObjectOfType<Movement>().IsMoving = true;    
                 CurrentPickups=0;
            } 
        }
    }
 }

}
    private void OnTriggerEnter(Collider other) { //i have change to use collider script but i dont like. i want to always use ontriggerenter.
        if(other.gameObject.tag=="Collectable"){
            CurrentPickups++;
            CurrentPickupsText.text = CurrentPickups.ToString();
            other.gameObject.tag = "Untagged";
            if(CurrentPickups>=RequiredPickups){
                _isCompleted = true;
                SoundManager.PlaySound("PassLevel");   
            }
    }
}
}
