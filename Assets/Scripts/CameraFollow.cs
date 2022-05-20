using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;
    public Vector3 distance;
    void LateUpdate()
    {
        this.transform.position=Vector3.Lerp(this.transform.position,player.transform.position+distance,Time.deltaTime);
    }
}
