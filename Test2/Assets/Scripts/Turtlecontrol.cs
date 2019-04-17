using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
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
    public Slider healthBar;
    private float x;
    private float y;
    private Vector3 rotateX;
    private Vector3 rotateY;
    private float health;
    


    //private int counter = 0;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();
        splash.GetComponent<ParticleSystem>().enableEmission = false;
        rb.useGravity = true;
        health = 100;
        healthBar.value = 1;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Shark")
            health -= (Random.Range(15, 30));
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
        //Basic WASD movement
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

        //Basic rotation using mouse axis
        y = Input.GetAxis("Mouse X");
        x = Input.GetAxis("Mouse Y");
        Debug.Log(x + ":" + y);
        rotateX = new Vector3(x, 0, 0);
        rotateY = new Vector3(0, y * -1, 0);

        if(!(x > 180 || x < -180) && !(y > 270 || y < -270)) {
          transform.eulerAngles -= rotateX + rotateY;
        }
        else if(x > 180 || x < -180)
          transform.eulerAngles -= rotateY;
        else if(y > 270 || y < -270)
          transform.eulerAngles -= rotateX;

        if (health < 10)
            health += (Time.deltaTime / 10);
        else if (health < 30)
            health += (Time.deltaTime / 8);
        else if (health < 50)
            health += (Time.deltaTime / 6);
        else if (health < 70)
            health += (Time.deltaTime / 4);
        else if (health < 100)
            health += (Time.deltaTime / 2);
        healthBar.value = (health / 100);




    }
}
