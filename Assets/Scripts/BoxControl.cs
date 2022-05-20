using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BoxControl : MonoBehaviour
{
    private bool _isCompleted = false;
    public int RequiredPickups = 3;
    public int CurrentPickups = 0;
    public TextMeshProUGUI CurrentPickupsText;
    public TextMeshProUGUI RequiredPickupsText;

    private void Awake() {
        CurrentPickupsText.text = CurrentPickups.ToString();
        RequiredPickupsText.text = " / " + RequiredPickups.ToString();
    }


    private void OnTriggerEnter(Collider other) { //i have change to use collider script but i dont like. i want to always use ontriggerenter.
        if(other.gameObject.tag=="Collectable"){
            CurrentPickups++;
            CurrentPickupsText.text = CurrentPickups.ToString();
            Debug.Log("CurrentPickups: "+CurrentPickups);
            if(CurrentPickups>=RequiredPickups){
                _isCompleted = true;
                
            }
            //other.gameObject.SetActive(false);
        }else{//TODO: bitirme ekranı ekelenecek.
            Debug.Log("GameOver");
            
        }
    }
}
