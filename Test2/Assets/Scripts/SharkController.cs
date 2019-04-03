using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkController : MonoBehaviour
{
    float speed = 5.0f;
    float origX;

    // Use this for initialization
    void Start()
    {
        origX = transform.position.x;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Time.deltaTime, 0, 0);

        if (Mathf.Abs(origX - transform.position.x) > 22.0f)
        {
            speed *= -1.0f; //change direction
        }
    }

}