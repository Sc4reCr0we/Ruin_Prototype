using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EffectSettings : MonoBehaviour
{
  public float ColliderRadius = 0.2f;
  public float EffectRadius = 0;
  public GameObject Target;
  public float MoveSpeed = 1;
  public float MoveDistance = 20;
  public bool IsHomingMove;
  public bool IsVisible = true;
  public bool DeactivateAfterCollision = true;
  public float DeactivateTimeDelay = 4;
  public LayerMask LayerMask = -1;

  public event EventHandler<CollisionInfo> CollisionEnter;
  public event EventHandler EffectDeactivated;

  private Dictionary<GameObject, float> activeGo = new Dictionary<GameObject, float>();
  private Dictionary<GameObject, float> inactiveGo = new Dictionary<GameObject, float>();
  private int currentActiveGo;
  private int currentInactiveGo;
  private bool deactivatedIsWait;

  public void OnCollisionHandler(CollisionInfo e)
  {
    foreach (var activeElemet in activeGo) {
      Invoke("SetGoActive", activeElemet.Value);
    }
    foreach (var inactiveElemet in inactiveGo) {
      Invoke("SetGoInactive", inactiveElemet.Value);
    }
    var handler = CollisionEnter;
    if (handler!=null)
      handler(this, e);
    if (DeactivateAfterCollision && !deactivatedIsWait) {
      deactivatedIsWait = true;
      Invoke("Deactivate", DeactivateTimeDelay);
    }
  }
  public void OnEffectDeactivatedHandler()
  {
    var handler = EffectDeactivated;
    if (handler!=null)
      handler(this, EventArgs.Empty);
  }

  private void Deactivate()
  {
    OnEffectDeactivatedHandler();
    gameObject.SetActive(false);
  }

  private void SetGoActive()
  {
    activeGo.ElementAt(currentActiveGo).Key.SetActive(false);
    ++currentActiveGo;
    if (currentActiveGo >= activeGo.Count)
      currentActiveGo = 0;
  }

  private void SetGoInactive()
  {
    inactiveGo.ElementAt(currentInactiveGo).Key.SetActive(true);
    ++currentInactiveGo;
    if (currentInactiveGo >= inactiveGo.Count)
      currentInactiveGo = 0;
  }

  public void OnEnable()
  {
    foreach (var activeElemet in activeGo) {
      activeElemet.Key.SetActive(true);
    }
    foreach (var inactiveElemets in inactiveGo) {
      inactiveElemets.Key.SetActive(false);
    }
    deactivatedIsWait = false;
  }

  public void OnDisable()
  {
    CancelInvoke("SetGoActive");
    CancelInvoke("SetGoInactive");
    CancelInvoke("Deactivate");
    currentActiveGo = 0;
    currentInactiveGo = 0;
  }

  public void RegistreActiveElement(GameObject go, float time)
  {
    activeGo.Add(go, time);
    activeGo = activeGo.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
  }

  public void RegistreInactiveElement(GameObject go, float time)
  {
    inactiveGo.Add(go, time);
    inactiveGo = inactiveGo.OrderBy(x => x.Value).ToDictionary(x => x.Key, x => x.Value);
  }
}

public class CollisionInfo : EventArgs
{
  public RaycastHit Hit;
}