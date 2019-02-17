using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sight2 : MonoBehaviour
{
    public Transform Tr;
    bool touch;
    Vector3 Position;
    // Start is called before the first frame update
    void Start()
    {
        Position = Tr.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (touch)
        {
            Tr.transform.position = Tr.transform.position + 2.5f * Vector3.right * Time.deltaTime;
        }

        if (!touch)
        {
            if (Tr.transform.position.x > Position.x)
            {
                Tr.transform.position = Tr.transform.position + 2.5f * Vector3.left * Time.deltaTime;
            }

        }
    }


    void OnTriggerStay2D(Collider2D col)
    {

        if (col.gameObject.CompareTag("Player"))
        {
            touch = true;
        }

    }

    void OnTriggerExit2D(Collider2D col)
    {

        if (col.gameObject.CompareTag("Player"))
        {

            touch = false;

        }

    }

   
}
