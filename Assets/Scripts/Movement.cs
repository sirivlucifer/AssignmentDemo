using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] float forwardSpeed = 10f;
    Vector3 firstPos,endPos;
    public float PlayerSpeed;
    private Rigidbody _rigidBody;
    public bool IsMoving=true;

       private void Awake() {
           _rigidBody = GetComponent<Rigidbody>();
    }
    void Update()
    {
       if(IsMoving){

           //use velocity for movement.
       //transform.Translate(-Vector3.up * forwardSpeed * Time.deltaTime);
       //move forward with new vector3 and rigidbody velocity.
       _rigidBody.velocity = new Vector3(forwardSpeed,0,0);
       
      // _rigidBody.velocity = new Vector3()

        //transform.position += -transform.up * Time.deltaTime * forwardSpeed;
      
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
       private void OnTriggerEnter(Collider other) {
        if(other.gameObject.tag=="LevelEnd"){
            Debug.Log("LevelEnd");
            //other is moving false.
            IsMoving=false;
            //other.gameObject.SetActive(false);
        }

       }
}
