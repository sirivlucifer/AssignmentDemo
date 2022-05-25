using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Singleton : MonoBehaviour
{
    private static Singleton _instance = null;
    private string  text;

    public static Singleton Instance
    {
        get {
            if (_instance == null)
            {
                _instance = new GameObject("Singleton").AddComponent<Singleton>();//singleton compepent obje eklendi.
            }
            return _instance; 
            }
    }

    private void OnEnable() {
        _instance = this;
        text = "Hello World";
    }
    public string GetText() {
        return text;
    }

}
