using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlockInd : MonoBehaviour {
  public float speed;
  float rotationSpeed = 4.0f;
  Vector3 avgHeading;
  Vector3 avgPos;
  float neighborDistance = 2.0f;

  bool turning = false;
  // Start is called before the first frame update
  void Start() {
    speed = Random.Range(5.0f, 10);
  }

  // Update is called once per frame
  void Update() {
    if(Vector3.Distance(transform.position, Vector3.zero) >= GlobalFlock.terrainSize) {
      turning = true;
    }
    else
      turning = false;
    if(turning) {
      Vector3 direction = Vector3.zero - transform.position;
      transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);

      speed = Random.Range(5.0f, 10);
    }
    else {
      if(Random.Range(0, 5) < 1)
      ApplyRules();
    }

    transform.Translate(0, 0, Time.deltaTime * speed);
  }

  void ApplyRules() {
    GameObject[] gos;
    gos = GlobalFlock.allObj;

    Vector3 vcenter = Vector3.zero;
    Vector3 vavoid = Vector3.zero;
    float gSpeed = 2f;

    Vector3 goalPos = GlobalFlock.goalPos;
    float dist;

    int groupSize = 0;
    foreach(GameObject go in gos) {
      if(go != this.gameObject) {
        dist = Vector3.Distance(go.transform.position, this.transform.position);
        if(dist <= neighborDistance) {
          vcenter += go.transform.position;
          groupSize++;
          if(dist < 0.1f) {
            vavoid += this.transform.position - go.transform.position;

            if(dist < 0.1f) {
              vavoid += this.transform.position - go.transform.position;
            }

            FlockInd anotherFlock = go.GetComponent<FlockInd>();
            gSpeed += anotherFlock.speed;
          }
        }
      }
      if(groupSize > 0) {
        vcenter = vcenter/groupSize + (goalPos - this.transform.position);
        speed = gSpeed/groupSize;
        Vector3 direction = (vcenter + vavoid) - transform.position;
        if(direction != Vector3.zero) {
          transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
        }
      }
    }
  }
}
