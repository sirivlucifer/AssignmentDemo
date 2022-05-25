using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Movement : MonoBehaviour
{
    [SerializeField] public static float forwardSpeed = 10f;
    Vector3 firstPos,endPos;
    public float PlayerSpeed; //horizontal speed
    public static Rigidbody RigidBody;
    public static bool IsMoving=true;
    public GameManager GameManager;
    public static bool StageEnd;
    [Header("Turner Controls")]
    [SerializeField] private GameObject _rightTurner;
    [SerializeField] private GameObject _leftTurner;
    private bool _isTurnerActivated;
    private float zMin = -3.53f, zMax = 3.53f; //limit.
    public static bool IsOnRamp=false;
    private float a=0;
    public static bool IsExitRamp=false;
    public static bool IsHitTheGround=false;
       [Header("SCRIPTABLE SYSTEM")]
       [SerializeField] private Scriptable _scriptable;
       private void Awake() {
           RigidBody = GetComponent<Rigidbody>();
       GetComponent<Renderer>().material.color = _scriptable.ThisColor;
       transform.localScale = _scriptable.ThisVector;
       }
    void FixedUpdate()
    {   
       if(transform.position.z>zMax){
       transform.position = new Vector3(transform.position.x,transform.position.y,zMax);
       }
       if(transform.position.z<zMin){
       transform.position = new Vector3(transform.position.x,transform.position.y,zMin);
       }
       if(_isTurnerActivated){//i founds this function on github.
        _leftTurner.transform.rotation = Quaternion.Euler(0f,a ,-90f);
        _rightTurner.transform.rotation = Quaternion.Euler(0f,-a ,-90f);

        a+=3;
        if (a>360)
        {
            a = 0;
        }
       }
       if(IsMoving&&GameManager.IsGameStarted&&GameManager.IsGameOver==false&&IsExitRamp==false){     
        RigidBody.velocity = new Vector3(forwardSpeed,0,0); //topların yavaşlatmaması için translate kullanmadım.
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
       if(IsMoving==false&&IsOnRamp==false){
       RigidBody.velocity = Vector3.zero;
       }            
       }//fixed update.
       public void TurnerActivate(){
              _leftTurner.SetActive(true);
              _rightTurner.SetActive(true);
              transform.Find("RightTurnerHolder").gameObject.SetActive(true);
              transform.Find("LeftTurnerHolder").gameObject.SetActive(true);
              _isTurnerActivated=true;
       }
       public void TurnerDeActivate(){
              _leftTurner.SetActive(false);
              _rightTurner.SetActive(false);
              transform.Find("RightTurnerHolder").gameObject.SetActive(false);
              transform.Find("LeftTurnerHolder").gameObject.SetActive(false);
              _isTurnerActivated=false;
       }
}//mono behaviour