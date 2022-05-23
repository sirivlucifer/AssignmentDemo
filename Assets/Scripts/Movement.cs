using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Movement : MonoBehaviour
{
    [SerializeField] public float forwardSpeed = 10f;
    Vector3 firstPos,endPos;
    public float PlayerSpeed; //horizontal speed
    private Rigidbody _rigidBody;
    public bool IsMoving;
    public GameManager GameManager;
    public bool StageEnd;
    [Header("Turner Controls")]
    [SerializeField] private GameObject _rightTurner;
    [SerializeField] private GameObject _leftTurner;
    private bool _isTurnerActivated;
    private float zMin = -3.53f, zMax = 3.53f; //limit.
    private bool _isOnRamp;

    private float a=0;
    private bool _isExitRamp;
    private bool _isHitTheGround;
    private float _forwardSpeedDecraseTimer = 0.1f;

       private void Awake() {
           _rigidBody = GetComponent<Rigidbody>();
 
            
    }
    private void Update() {
       if(_isOnRamp){      //rampa hız arttırma. 
              if(_isHitTheGround==false){
                     if(50>forwardSpeed){
              transform.Translate(-Vector3.up * Time.deltaTime * forwardSpeed); // uçabilmek için translate kullandım.
                     if(Input.GetMouseButtonDown(0)){
                            forwardSpeed+=5;         
            }
            }
              }
       
       }
    }

    void FixedUpdate()
    {
           if(_isOnRamp){ //rampa hız düşürücüsü.
                     if(_isHitTheGround==false){
                     if(_forwardSpeedDecraseTimer >0){
                 _forwardSpeedDecraseTimer -= Time.fixedDeltaTime;
            }else{
                   if(.2f<forwardSpeed){
                 forwardSpeed-=1;
                 _forwardSpeedDecraseTimer = 0.1f;
                 Debug.Log("forwardSpeed: "+forwardSpeed);
              }
            }
           }
           }
           
       if(transform.position.z>zMax){
       transform.position = new Vector3(transform.position.x,transform.position.y,zMax);
       }
       if(transform.position.z<zMin){
       transform.position = new Vector3(transform.position.x,transform.position.y,zMin);
       }


       if(_isTurnerActivated){

        _leftTurner.transform.rotation = Quaternion.Euler(0f,a ,-90f);
        _rightTurner.transform.rotation = Quaternion.Euler(0f,-a ,-90f);

        a+=3;
        if (a>360)
        {
            a = 0;
        }
       }
       if(IsMoving&&GameManager.IsGameStarted&&GameManager.IsGameOver==false&&_isExitRamp==false){
           
        _rigidBody.velocity = new Vector3(forwardSpeed,0,0); //topların yavaşlatmaması için translate kullanmadım.
        //transform.Translate(-Vector3.up * Time.deltaTime * forwardSpeed);
       if(Input.GetMouseButtonDown(0)){
              firstPos = Input.mousePosition;
       }
       else if(Input.GetMouseButton(0)){
              endPos = Input.mousePosition;
              float distance = endPos.x - firstPos.x;
              transform.Translate(distance * Time.deltaTime * PlayerSpeed/100,0,0);
       }
       if(Input.GetMouseButtonUp(0)){
              firstPos = Vector3.zero;
              endPos = Vector3.zero;
       }
       } 

       if(IsMoving==false&&_isOnRamp==false){
       Debug.Log("zero trigger");
       _rigidBody.velocity = Vector3.zero;
       }            
       }//fixed update.
       private void TurnerActivate(){
              _leftTurner.SetActive(true);
              _rightTurner.SetActive(true);
              transform.Find("RightTurnerHolder").gameObject.SetActive(true);
              transform.Find("LeftTurnerHolder").gameObject.SetActive(true);
              _isTurnerActivated=true;
       }
       private void TurnerDeActivate(){
              _leftTurner.SetActive(false);
              _rightTurner.SetActive(false);
              transform.Find("RightTurnerHolder").gameObject.SetActive(false);
              transform.Find("LeftTurnerHolder").gameObject.SetActive(false);
              _isTurnerActivated=false;
       }
       private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="LevelEnd"){
            Debug.Log("LevelEnd--LevelStage.");
            IsMoving=false;
           // _rigidBody.constraints = RigidbodyConstraints.None | RigidbodyConstraints.FreezeRotation;
            other.gameObject.SetActive(false);
            StageEnd=true;
            FindObjectOfType<GameManager>().toggleFailTimer(true);
            TurnerDeActivate();
               
        }
        if(other.gameObject.tag=="FinishLevel"){
               IsMoving=false;
               Debug.Log("FinishLevel-- level up");
               GameManager.IsLevelUp=true;
               //TODO: Level Up Screen

        }
        if(other.gameObject.tag=="TurnerTrigger"){
               Destroy(other.gameObject);
               Debug.Log("Turner Trigger Enter");
               TurnerActivate();
        }
        if(other.CompareTag("RampTrigger")){
              Debug.Log("Ramp Trigger Enter");
              _rigidBody.constraints = RigidbodyConstraints.FreezeRotationZ;
              other.gameObject.SetActive(false);
              IsMoving=false;
             // transform.DOMoveZ(0,1f);
              _isOnRamp=true;
        }
       if(other.CompareTag("RampEndTrigger")){
              //buga girdiği için z posizyonunu bilerek açmadım.
              other.gameObject.SetActive(false);
              _isExitRamp=true;
              Debug.Log("_isExitRamp is "+_isExitRamp);
        }
        if(other.CompareTag("AfterRamp")){
               _isHitTheGround = true;
               Debug.Log("is hit the ground"+_isHitTheGround);
               _rigidBody.drag = 1;
               Debug.Log("rigidbody drag"+_rigidBody.drag);
        }
       }

}//mono behaviour
       
