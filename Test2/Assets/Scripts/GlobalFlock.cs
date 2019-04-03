using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFlock : MonoBehaviour {

  public GameObject prefab;
  public GameObject goalPrefab;
  public static int terrainSize = 50;

  static int numOfObj = 10;
  public static GameObject[] allObj = new GameObject[numOfObj];

  public static Vector3 goalPos = Vector3.zero;

  // Start is called before the first frame update
  void Start() {
    for(int i = 0; i < numOfObj; i++) {
      Vector3 pos = this.transform.position + new Vector3(Random.Range(-terrainSize, terrainSize), Random.Range(-terrainSize, terrainSize), Random.Range(-terrainSize, terrainSize));
      allObj[i] = (GameObject) Instantiate(prefab, pos, Quaternion.identity);
    }
  }

  // Update is called once per frame
  void Update() {
    if(Random.Range(0, 10000) < 50) {
      goalPos = new Vector3(Random.Range(-terrainSize, terrainSize), Random.Range(-terrainSize, terrainSize), Random.Range(-terrainSize, terrainSize));
      goalPrefab.transform.position = goalPos;
    }
  }
}
