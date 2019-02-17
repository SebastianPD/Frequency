using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moveplatform : MonoBehaviour
{
    Vector3 Position;
    bool touch;

    // Start is called before the first frame update
    void Start()
    {
        Position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (touch)
        {

            transform.position = transform.position + 2.5f*Vector3.right * Time.deltaTime;

        }
        else if (!touch){
           
           if (transform.position.x < Position.x)
            {

                transform.position = Position;
            } else if (transform.position != Position)
            {

                transform.position = transform.position + .7f * Vector3.left * Time.deltaTime;


            }



        }
    }

    void OnCollisionStay2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Player"))
        {

            touch = true;

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
