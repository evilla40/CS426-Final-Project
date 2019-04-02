using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchDisplays : MonoBehaviour
{
    public Camera firstPersonCam;
    public Camera miniMapCam;
    void Start()
    {
        firstPersonCam.enabled = true;
        miniMapCam.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Return)) {
          Debug.Log("Changing views");
          if(firstPersonCam.enabled) {
            firstPersonCam.enabled = false;
            miniMapCam.enabled = true;
          }
          else { //means firstPersonCam is disabled
            firstPersonCam.enabled = true;
            miniMapCam.enabled = false;
          }
        }
    }
}
