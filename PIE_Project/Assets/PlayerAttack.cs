using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool attack = false;

    public float attackTimer = 0;
    private float attackCd = .3f;

    public Collider2D attackTrigger;
    public NEWCC cc;

    public Rigidbody2D rb;


    public Animator animator;

    public bool coolDown = true;
    public float coolTimer = 0;

    void Awake() {
        // this does animations
         //anim = gameObject.GetComponent<>(Animator);
        attackTrigger.enabled = false;
    }

    void FixedUpdate() {

        if (Input.GetKeyDown(KeyCode.E) && !attack && coolDown) {

            
            if (cc.left) { rb.velocity = (new Vector2(-15, 0)); }
            else if (cc.right) { rb.velocity = (new Vector2(15, 0)); }
            attack = true;
            attackTimer = attackCd;
            animator.SetBool("attack", true);
            attackTrigger.enabled = true;
           

        }

        if (attack) {



            if (attackTimer > 0)
            {
                attackTimer -= Time.deltaTime;

                //rb.velocity = (new Vector2(0, 0));
            }
            else {
                attack = false;
                attackTrigger.enabled = false;
                animator.SetBool("attack", false);
                rb.velocity = (new Vector2(0, 0));
                coolDown = false;
                //attackTimer = 
            }
        }

        if (!coolDown)
        {
            coolTimer -= Time.deltaTime;
            if (coolTimer < 0) {
                coolTimer = 1;
                coolDown = true;
            }
        }


    }
}
