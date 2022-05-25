using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggers : MonoBehaviour
{

       private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("LevelEnd")){
            Debug.Log("LevelEnd--LevelStage.");
            FindObjectOfType<Movement>().IsMoving=false;
           // _rigidBody.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotation;
            other.gameObject.SetActive(false);
            Movement.StageEnd=true;
            FindObjectOfType<GameManager>().FailTimerCalculate(true);
            FindObjectOfType<Movement>().TurnerDeActivate();                         
        }
        if(other.CompareTag("FinishLevel")){
                 FindObjectOfType<Movement>().IsMoving=false;
               Debug.Log("FinishLevel-- level up");
               GameManager.IsLevelUp=true;
              SoundManager.PlaySound("LevelFinish");

        }
        if(other.CompareTag("TurnerTrigger")){
               Destroy(other.gameObject);
               Debug.Log("Turner Trigger Enter");
               FindObjectOfType<Movement>().TurnerActivate();   
        }
        if(other.CompareTag("RampTrigger")){
              Debug.Log("Ramp Trigger Enter");
              Movement.RigidBody.constraints = RigidbodyConstraints.FreezeRotationZ;
              other.gameObject.SetActive(false);
            FindObjectOfType<Movement>().IsMoving=false;
             // transform.DOMoveZ(0,1f);
              Movement.IsOnRamp=true;
              FindObjectOfType<Ramp>().FillBarSliderPanel.SetActive(true);
        }
       if(other.CompareTag("RampEndTrigger")){
              //buga girdiği için z posizyonunu bilerek açmadım.
              other.gameObject.SetActive(false);
              FindObjectOfType<Movement>().IsExitRamp=true;
        }
        if(other.CompareTag("AfterRamp")){
               Movement.IsHitTheGround = true;
               Movement.RigidBody.drag = 5;
                //TODO: LEVEL UP TİMER
              GameManager.IsLevelUp=true;
              SoundManager.PlaySound("LevelFinish");
        }
       }

}
