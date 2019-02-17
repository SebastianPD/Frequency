using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NEWCC : MonoBehaviour

{
    //Movement Variables
    public float v = 0;
    public float maxV = 1;
    public float a = 0.1f;
    public float Da = 0.1f;
    //Jump Variables
    public float m_JumpForce = 400f;
    bool Grounded;
    public Rigidbody2D rb;
    // crouching
    bool crouch;
    public Collider2D CrouchCollider;
    float TmaxV;
    float Ta;
    float TDa;
    //For animation
    public Animator animator;
    Vector3 theScale;
    // For wall jumping
   public bool walled;
   public bool left;
    public bool right;
    public bool attack;

    // Start is called before the first frame update
    void Start()
    {
        attack = false;
        Grounded = true;
        crouch = false;
        CrouchCollider.enabled = true;
        TmaxV = maxV;
        Ta = a;
       TDa = Da;
        theScale = transform.localScale;
    }

    // Update is called once per frame
    void Update()
    {


        if (Input.GetKeyDown(KeyCode.E))
        {

            attack = true;

        }
        else {
            attack = false;
        }


            if (Input.GetKeyDown(KeyCode.D) && v < maxV)
        {
            v = 0;
            theScale.x = Mathf.Abs(theScale.x);
            transform.localScale = theScale;
            right = true;
            left = false;
        }
        else if (Input.GetKeyDown(KeyCode.A) && v > -maxV)
        {
            v = 0;
            theScale.x = Mathf.Abs(theScale.x)*-1;
            transform.localScale = theScale;
            right = false;
            left = true;
        }


        if (Input.GetKey(KeyCode.D) && v < maxV)
        {
            v = v + a * Time.deltaTime;
        
            
        }
        else if (Input.GetKey(KeyCode.A) && v > -maxV)
        {
            v = v - a * Time.deltaTime;
          
           
        }
        else
        {
            if (v > Da * Time.deltaTime)
            {
                v = v - Da * Time.deltaTime;


            }
            else if (v < -Da * Time.deltaTime)
            {
                v = v + Da * Time.deltaTime;

            }
            else
            {
                v = 0;
            }
            animator.SetFloat("speed", Mathf.Abs(v));
        }
        animator.SetFloat("speed", Mathf.Abs(v));
        transform.Translate(v, 0, 0);


        if (Input.GetKey(KeyCode.Space) && Grounded) {
            animator.SetBool("jump", true);
            Grounded = false;
            rb.AddForce(new Vector2(0f, m_JumpForce));
        }

        if (Input.GetKey(KeyCode.S))
        {
            crouch = true;
            animator.SetBool("crouching", true);
        }
        else {
            crouch = false;
            animator.SetBool("crouching", false);
        }


        if (crouch)
        {
            CrouchCollider.enabled = false;
              maxV = TmaxV/2;
              a = Ta/2;
              Da = TDa/2;
}
        else {

            maxV = TmaxV;
            a = Ta;
            Da = TDa;

            CrouchCollider.enabled = true;
        }

        // wall jumping

        if (walled)
        {
            
            rb.gravityScale = .1f;
            if (left)
            {
                v = -.001f;

            }
            else{
                v = .001f;
                
            }

        }
        else {
            rb.gravityScale = 2.95f;

        }

        if (Input.GetKeyDown(KeyCode.Space) && walled)
        {
            animator.SetBool("jump", true);
            //Grounded = walled;
     
            if (left) {
                rb.AddForce(new Vector2( 900, 450));
                left = false;
                right = true;
            }
            else if (right) {
                rb.AddForce(new Vector2(-1f*900, 450));
                right = false;
                left = true;
            }

            
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Ground"))
        {
            Grounded = true;
            animator.SetBool("jump", false);
            if(!attack)
            { rb.velocity = new Vector2(0, 0); }
            
        }

        if (col.gameObject.CompareTag("Wall"))
        {
        
            rb.velocity = new Vector2(0, 0);

        }

    }

    private void OnCollisionStay2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Wall"))
        {
            walled = true;

        }
    }

    void OnCollisionExit2D(Collision2D thing)
    {
        if (thing.gameObject.CompareTag("Wall"))
        {
            walled = false;

        }

        if (thing.gameObject.CompareTag("RampR"))
        {
            rb.velocity = new Vector2(0, v * 50 * Mathf.Cos(Mathf.PI / 4));

        }

    }

    private void flip(float speed) {
        if (v < 0)
        {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
        else {
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;

        }
    }
}

