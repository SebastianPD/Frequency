using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoonAI : MonoBehaviour
{
    int initialMove;

    public Transform TR;
    public PlayerAttack At;
    public float refresh = 2;
    public float rere = 2;

    int option;
    
    // Start is called before the first frame update
    void Start()
    {
        option = (int)(3 * Random.value + 1);
    }

    // Update is called once per frame
    void Update()
    {
        refresh = refresh - Time.deltaTime;
        //Debug.Log(refresh);
        if (refresh < 0)
        {
            option = (int)(3 * Random.value + 1);
            
            refresh = rere;
            
        }

        if (option ==1 ) {
            transform.position = transform.position + Vector3.left * Time.deltaTime;
        }
        if (option == 2)
        {
            transform.position = transform.position + Vector3.right * Time.deltaTime;
        }
        if (option == 3)
        {
            //transform.position = transform.position + Vector3.left * Time.deltaTime;
        }

    }

    void OnCollisionEnter2D(Collision2D col)
    {


        if (col.gameObject.CompareTag("Attack"))
        {



            


        }

        if (col.gameObject.CompareTag("Player"))
        {

            if (At.attack)
            {
                Destroy(this);
                transform.position = new Vector2(-12, -14);
            } else
            {
                TR.transform.position = new Vector2(-12, -14);

            }

            


        }
    }
}
