using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Punch : MonoBehaviour
{
    public Animator anim;
    public float damage = 0.05f;
    BoxCollider BoxCollWeapon;

    void Start()
    {
        BoxCollWeapon = gameObject.GetComponent<BoxCollider>();
        BoxCollWeapon.enabled = false;
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            BoxCollWeapon.enabled = true;
            anim.SetBool("IsAttack", true);
        }
        else
        {
            BoxCollWeapon.enabled = false;
            anim.SetBool("IsAttack", false);
        }
    }
}

