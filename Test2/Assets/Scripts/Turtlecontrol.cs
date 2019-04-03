using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turtlecontrol : MonoBehaviour
{
    Rigidbody rb;
    Transform t;
    public float speed = 25.0f;
    public float rotationSpeed = 90;
    public float force = 700f;
    public Transform splash;
    public AudioClip sound;
    public AudioSource source;
    //private int counter = 0;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();
        splash.GetComponent<ParticleSystem>().enableEmission = false;
        rb.useGravity = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        //if (counter % 2 == 0) rb.useGravity = false;
        //else rb.useGravity = true;
        //++counter;
        source.PlayOneShot(sound);
        splash.GetComponent<ParticleSystem>().enableEmission = true;
        StartCoroutine(stop());
    }

    IEnumerator stop()
    {
        yield return new WaitForSeconds(1.0f);
        splash.GetComponent<ParticleSystem>().enableEmission = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKey(KeyCode.W))
            rb.velocity += this.transform.forward * speed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.S))
            rb.velocity -= this.transform.forward * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
            t.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
        else if (Input.GetKey(KeyCode.A))
            t.rotation *= Quaternion.Euler(0, -rotationSpeed * Time.deltaTime, 0);

        if (Input.GetKeyDown(KeyCode.Space))
            rb.AddForce(t.up * force);


    }
}
