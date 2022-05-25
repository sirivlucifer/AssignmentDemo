using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ramp : MonoBehaviour
{
    [Header("Ramp UI Settings")]
    public Slider FillBarSlider;
    public GameObject FillBarSliderPanel;
    public Gradient Gradient;
    public Image Fill;
    [Header("Ramp Settings")]

    private  float _forwardSpeedDecraseTimer = 0.1f;

    private void Update() {
       if(Movement.IsOnRamp){      //rampa hız arttırma. 
            if(Movement.IsHitTheGround==false){
                if(50>Movement.forwardSpeed){
                    transform.Translate(-Vector3.up * Time.deltaTime * Movement.forwardSpeed); // uçabilmek için translate kullandım.
                    if(Input.GetMouseButtonDown(0)){
                        Movement.forwardSpeed+=5;
                        OnSliderChanged();     
                    }
                }   
            }
       }
    }
    private void FixedUpdate() {
        if(Movement.IsOnRamp){ //rampa hız düşürücüsü.
            if(Movement.IsHitTheGround==false){
                if(_forwardSpeedDecraseTimer >0){
                    _forwardSpeedDecraseTimer -= Time.fixedDeltaTime;
        }else{
              if(2f<Movement.forwardSpeed&&Movement.IsExitRamp==false){
                Movement.forwardSpeed-=1;
                _forwardSpeedDecraseTimer = 0.1f;
                Debug.Log("forwardSpeed: "+Movement.forwardSpeed);
                }
            }
            }
       }
    }

    public void OnSliderChanged(){
        FillBarSlider.value = Movement.forwardSpeed;
        //FillBarSliderPanel.SetActive(true);
        Fill.color = Gradient.Evaluate(1f);
        Fill.color = Gradient.Evaluate(FillBarSlider.value / FillBarSlider.maxValue);   
    }
    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="Coin"){          
            FindObjectOfType<GameManager>().ChangeScore(other.gameObject.transform.GetSiblingIndex());
            Debug.Log("Coin Collected"+other.gameObject.transform.GetSiblingIndex());       
        }
    }     
}
