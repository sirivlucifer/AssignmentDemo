using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Scriptable Object", menuName = "Scriptable Object")]

public class Scriptable : ScriptableObject
{
    public Color ThisColor = Color.white;
    public Vector3 ThisVector = Vector3.zero;

}
