using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elevate : MonoBehaviour
{
    public float timelimit = 3f;
    public float Vintensity = 1f;
    bool touch;
    Vector3 direction = Vector3.up;
    float Restart;
    Vector3 Position;

    // Start is called before the first frame update
    void Start()
    {
        Restart = timelimit;
        Position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(touch);
        if (touch == true && timelimit > 0)
        {
 
            timelimit = timelimit - Time.deltaTime;
            transform.position = transform.position + 2.5f * direction * Time.deltaTime;
        }

        else {

            if (transform.position.y < Position.y)
            {

                transform.position = Position;
            }

            if (transform.position != Position)
            {

                transform.position = transform.position + 1.5f * Vector3.down * Time.deltaTime;


            }

        }
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Player"))
        {
            timelimit = Restart;
        }

    }


    void OnCollisionStay2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Player"))
        {

            touch = true;
            //timelimit = Restart;
        }

    }

    void OnCollisionExit2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Player"))
        {

            touch = false;

        }

    }
}
