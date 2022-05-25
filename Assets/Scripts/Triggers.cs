using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Triggers : MonoBehaviour
{

       private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("LevelEnd")){
            FindObjectOfType<Movement>().IsMoving=false;
           // _rigidBody.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotation;
            other.gameObject.SetActive(false);
            Movement.StageEnd=true;
            FindObjectOfType<GameManager>().FailTimerCalculate(true);
            FindObjectOfType<Movement>().TurnerDeActivate();                         
        }
        if(other.CompareTag("FinishLevel")){
                 FindObjectOfType<Movement>().IsMoving=false;
               GameManager.Instance.IsLevelUp=true;
              SoundManager.PlaySound("LevelFinish");
        }
        if(other.CompareTag("TurnerTrigger")){
               Destroy(other.gameObject);
               FindObjectOfType<Movement>().TurnerActivate();   
        }
        if(other.CompareTag("RampTrigger")){
              Movement.Instance.RigidBody.constraints = RigidbodyConstraints.FreezeRotationZ;
              other.gameObject.SetActive(false);
            FindObjectOfType<Movement>().IsMoving=false;
             // transform.DOMoveZ(0,1f);
              Movement.Instance.IsOnRamp=true;
              FindObjectOfType<Ramp>().FillBarSliderPanel.SetActive(true);
        }
       if(other.CompareTag("RampEndTrigger")){
              //buga girdiği için z posizyonunu bilerek açmadım.
              other.gameObject.SetActive(false);
              FindObjectOfType<Movement>().IsExitRamp=true;
        }
        if(other.CompareTag("AfterRamp")){
               Movement.Instance.IsHitTheGround = true;
               Movement.Instance.RigidBody.drag = 5;
                //TODO: LEVEL UP TİMER
              GameManager.Instance.IsLevelUp=true;
              SoundManager.PlaySound("LevelFinish");
        }
       }

}
