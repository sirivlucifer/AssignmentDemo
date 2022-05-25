using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static AudioClip PassLevel, LevelFinish;
    static AudioSource audioSrc;
    void Start()
    {
        PassLevel = Resources.Load<AudioClip>("PassLevel");
        LevelFinish = Resources.Load<AudioClip>("LevelFinish");
        audioSrc = GetComponent<AudioSource>();
    }
    public static void PlaySound(string clip){
        switch(clip){
            case "PassLevel":
                audioSrc.PlayOneShot(PassLevel);
                break;
            case "LevelFinish":
                audioSrc.PlayOneShot(LevelFinish);
                break;
        }
    }
}
