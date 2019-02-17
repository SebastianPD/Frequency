using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackTrigger : MonoBehaviour
{
    public int dmg = 20;

    void OnCollisionStay2D(Collision2D col) {

        if (col.gameObject.CompareTag("NME")) {

            Destroy(col.gameObject);

        }

    }
}
