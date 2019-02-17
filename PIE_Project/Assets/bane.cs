using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bane : MonoBehaviour
{

    public Transform TR;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {

        if (col.gameObject.CompareTag("Player") && !Input.GetKey(KeyCode.Space))
        {
            TR.transform.position = new Vector2(-12, -14);


        }

    }
}
