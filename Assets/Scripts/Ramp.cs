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
    public float rampSpesssssed = 1f;
    public void OnSliderChanged(){
        FillBarSlider.value = FindObjectOfType<Movement>().forwardSpeed;
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
