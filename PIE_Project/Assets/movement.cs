using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {

    public Rigidbody2D m_Rigidbody2D;

    public CharacterController2D controller;
    public Animator animator;

   // [Range(-50, 50)] public float Velocity = 0f;
    [Range(-5, 5)] float acceleration = 0;
    public float MaxV = 50f;
    public float MinV = -50f;
    public float RunSpeed = 0f;
    float Hmove = 0f;
    public int NormJF = 900;
    public float normGv = 2.95f;

    public bool wallSliding = false;

    public float WallSpeed = 3;

    bool decell = true;

    bool jump = false;
    bool crouch = false;

    public float distance = 1f;

    bool touch = false;

    float Old;

    

    // Use this for initialization
    void Start () {

        Old = controller.m_JumpForce;
    }


    public void OnCollisionStay2D(Collision2D thing) {
        if (thing.gameObject.CompareTag("Wall") ) {
            touch = true;
            if (Hmove > .1) {
                Hmove = .1f;
            }
            

        }

    }

    public void OnCollisionExit2D(Collision2D thing)
    {
        if (thing.gameObject.CompareTag("Wall"))
        {
            touch = false;
            
          
        }

    }

    // Update is called once per frame
    void Update () {



        

        

        if (touch && !controller.m_Grounded)
        {
            Old = controller.m_JumpForce;
            Hmove = Hmove;
            wallSliding = true;

            if (wallSliding)
            {
                
                

               controller.m_JumpForce = -10;
                m_Rigidbody2D.gravityScale = .1f;


            }
           

        }
        else {
            controller.m_JumpForce = NormJF;
            m_Rigidbody2D.gravityScale = normGv;
            wallSliding = false;
        }


        if (controller.targetVelocity.y < 0 && !touch)
       {
           controller.m_JumpForce = NormJF;
            m_Rigidbody2D.gravityScale = normGv;
       }

        Debug.Log(Hmove);




        /*var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var y = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        transform.Translate(x, y, 0);
        transform.Rotate(0, 0, 0);*/

        //controller.Move();

        acceleration = Input.GetAxisRaw("Horizontal") * RunSpeed;

        



        if (Input.GetAxisRaw("Horizontal") > 0.1)
        {
            //Debug.Log(Hmove);
            //Debug.Log(acceleration);
            //acceleration = acceleration + RunSpeed * Time.fixedDeltaTime;
            decell = false;
        }
        if (Input.GetAxisRaw("Horizontal") < -0.1)
        {
            //Debug.Log(Hmove);
            //Debug.Log(acceleration);
            //acceleration = acceleration - RunSpeed * Time.fixedDeltaTime;
            decell = false;
        }


        /*  if (Input.GetButtonDown("right"))
          {
              //Debug.Log(Hmove);
              //Debug.Log(acceleration);
              acceleration = acceleration + RunSpeed * Time.fixedDeltaTime;
              decell = false;
          }
          if (Input.GetButtonDown("left"))
          {
              //Debug.Log(Hmove);
              //Debug.Log(acceleration);
              acceleration = acceleration - RunSpeed * Time.fixedDeltaTime;
              decell = false;
          } */


        Hmove = Hmove + acceleration * Time.fixedDeltaTime;

        if (Input.GetButtonDown("Jump")) {
            jump = true;
            animator.SetBool("jump",true);
            Hmove = 0;

        }


        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
            animator.SetBool("crouching", true);
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
            animator.SetBool("crouching", false);
        }

        if (Input.GetButtonUp("Horizontal")) {
           // Hmove = Hmove - acceleration * Time.fixedDeltaTime;
        }

        
        //acceleration = acceleration - 2f * Time.fixedDeltaTime;
      

        if (Hmove > MaxV)
        {
            Hmove = MaxV;
        }

        if (Hmove < MinV)
        {
            Hmove = MinV;
        }

        if (Input.GetAxisRaw("Horizontal") == 0)
        {

            

            if (Hmove < 0)
            {
                Hmove = Hmove + 1.5f*RunSpeed * Time.fixedDeltaTime;
                // Mathf.Ceil(Hmove);
                //Hmove = (int)Hmove;
                
            }

            if (Hmove > 0)
            {
               Hmove = Hmove - 3f*RunSpeed * Time.fixedDeltaTime;
              // Hmove = (int)Hmove;
                
                // Mathf.Floor(Hmove);
            }

            

        }

        if (Mathf.Abs(Hmove) < .15 && Input.GetAxisRaw("Horizontal") == 0)
        {
            Hmove = 0;
        }

        //Debug.Log(Hmove);

        
        //Debug.Log(controller.m_Rigidbody2D.velocity.y);



        animator.SetFloat("speed", Mathf.Abs(Hmove));
        //Debug.Log(Input.GetAxisRaw("Horizontal"));

    }

    public void onLanding()
    {
        animator.SetBool("jump", false);
    }

   /* public void onCrouching(bool iscrouching) { 
        animator.SetBool("crouching", iscrouching);
    }*/

    private void FixedUpdate()

    {
        
        //controller.Move(Hmove* Time.fixedDeltaTime, crouch, jump);
        controller.Move(Hmove, crouch, jump, wallSliding);
        jump = false;
        
    }





}
