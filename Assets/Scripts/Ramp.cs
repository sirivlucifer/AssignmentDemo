using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ramp : MonoBehaviour
{

    [Header("Ramp UI Settings")]
    public Slider FillBarSlider;
    public GameObject FillBarSliderPanel;

    [Header("Ramp Settings")]
    public float rampSpesssssed = 1f;

    private void Start() {

    }


    public void OnSliderChanged(){
        FillBarSlider.value = FindObjectOfType<Movement>().forwardSpeed;
        FillBarSliderPanel.SetActive(true);
        
    }
 


    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="Coin"){
            
            FindObjectOfType<GameManager>().ChangeScore(other.gameObject.transform.GetSiblingIndex());
            Debug.Log("Coin Collected"+other.gameObject.transform.GetSiblingIndex());

            
        }
    }
    







    
}
