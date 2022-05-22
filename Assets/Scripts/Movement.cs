using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float forwardSpeed = 10f;
    Vector3 firstPos,endPos;
    public float PlayerSpeed;
    private Rigidbody _rigidBody;
    public bool IsMoving;
    public GameManager GameManager;
    public bool StageEnd;
    [Header("Turner Controls")]
    [SerializeField] private GameObject _rightTurner;
    [SerializeField] private GameObject _leftTurner;
    private bool _isTurnerActivated;
    private float zMin = -3.53f, zMax = 3.53f;

    private float a=0;



       private void Awake() {
           _rigidBody = GetComponent<Rigidbody>();
 
            
    }

    void Update()
    {
           //clamp z axis
                 if(transform.position.z>zMax){
                 transform.position = new Vector3(transform.position.x,transform.position.y,zMax);
                 }
                       if(transform.position.z<zMin){
                       transform.position = new Vector3(transform.position.x,transform.position.y,zMin);
                       }


       if(_isTurnerActivated){

        _leftTurner.transform.rotation = Quaternion.Euler(0f,a ,0f);
        _rightTurner.transform.rotation = Quaternion.Euler(0f,-a ,0f);

        a+=3;
        if (a>360)
        {
            a = 0;
        }
       }
       if(IsMoving&&GameManager.IsGameStarted&&GameManager.IsGameOver==false){
           
       //transform.Translate(-Vector3.up * forwardSpeed * Time.deltaTime);
        _rigidBody.velocity = new Vector3(forwardSpeed,0,0);
      // _rigidBody.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotation;
       //_rigidBody.MovePosition(transform.position + new Vector3(forwardSpeed * Time.deltaTime,0,0));
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
       else{
              _rigidBody.velocity = Vector3.zero;
       }            
       }
       private void TurnerActivate(){
              _leftTurner.SetActive(true);
              _rightTurner.SetActive(true);
              _isTurnerActivated=true;
       }
              private void TurnerDeActivate(){
              _leftTurner.SetActive(false);
              _rightTurner.SetActive(false);
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
               //TODO: Level Up Screen

        }
        if(other.gameObject.tag=="TurnerTrigger"){
               Destroy(other.gameObject);
               Debug.Log("Turner Trigger Enter");
               TurnerActivate();
        }

       }

}//mono behaviour
       
