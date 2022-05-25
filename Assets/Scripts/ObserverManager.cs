using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserverManager : MonoBehaviour
{
  
  #region Singleton
  private static ObserverManager _instance =null;
  public static ObserverManager Instance => _instance;

  #endregion

  private void Awake() {
      _instance = this;
  }

}

public enum NotificationType{
    PassLevel,
    LevelFinish
}
