using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    [SerializeField] private Scriptable _scriptable;

    private void Start() {
        GetComponent<Renderer>().material.color = _scriptable.ThisColor;
    }
}
