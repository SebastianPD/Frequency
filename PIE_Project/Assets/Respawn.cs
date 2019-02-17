using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Respawn : MonoBehaviour {

    public Transform TR;
    public Transform Cam;
    Vector3 Nposition;
    public Transform check;
    public NEWCC move;
    public CinemachineVirtualCamera CM;
    public Rigidbody2D rb;
   

    // Use this for initialization
    void Start () {
        //position = new Vector3(0, 0, 0);
        Nposition = TR.transform.position;
    }
	
	// Update is called once per frame
	void Update () {
        
        if (TR.position.y < -12)
        {
            rb.velocity = (new Vector2(0, 0)); 
            TR.transform.position = Nposition;
            move.v = 0;

            CM.transform.position = Nposition;
        }
	}

    void OnTriggerEnter2D(Collider2D other)
    {
       
        if (other.gameObject.CompareTag("CheckPoint"))
        {
            Nposition = other.transform.position;
        }
    }

}
