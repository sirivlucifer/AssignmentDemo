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


       private void Awake() {
           _rigidBody = GetComponent<Rigidbody>();
            
    }
    private void Start() { //start every game. 
           StartCoroutine(MyIEnumerator());
    }

    
    IEnumerator MyIEnumerator()
{

       yield return new WaitForSeconds(3);
	if(FindObjectOfType<BoxControl>().RequiredPickups>=FindObjectOfType<BoxControl>().CurrentPickups){
                   GameManager.IsGameOver =true;
        }

}
    void Update()
    {
       if(IsMoving&&GameManager.IsGameStarted){
           
       //transform.Translate(-Vector3.up * forwardSpeed * Time.deltaTime);
       _rigidBody.velocity = new Vector3(forwardSpeed,0,0);
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
            Debug.Log("LevelEnd--LevelStage.");
            IsMoving=false;
            other.gameObject.SetActive(false);
          //  MyIEnumerator();
               
        }
        if(other.gameObject.tag=="FinishLevel"){
               IsMoving=false;
               Debug.Log("FinishLevel-- level up");
               //TODO: Level Up Screen
        }

       }
}//mono behaviour
       
