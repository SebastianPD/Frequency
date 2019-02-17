using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleJump : MonoBehaviour
{
    public CharacterController2D player;

    // Start is called before the first frame update
    void Start()
    {
        //controller = GetComponent<CharacterController2D>;
    }

    // Update is called once per frame
    void Update()
    {
        // wall jumping

       // Physics2D.queriesStartInColliders = false;
       // RaycastHit2D hit = Physics2D.Raycast(transfrom.position, Vector2.right * transform.localScale.x, distance);

     //   if (Input.GetButtonDown("Crouch") && !controller.m_Grounded && hit.collider != null)
        {
          //  GetComponent<Rigidbody2D>().velocity = new Vector2();

         
        }

    }
}
