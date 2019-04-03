using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniCameraFollow : MonoBehaviour {
  public Transform followTarget;
  Vector3 offset;
  public void Setup() {
    offset = transform.position - followTarget.position;
    transform.SetParent(null);
  }

  void LateUpdate() {
    if(followTarget != null) {
      transform.position = followTarget.position + offset;
      transform.rotation = Quaternion.LookRotation(-followTarget.up, followTarget.forward);
    }
  }
}
