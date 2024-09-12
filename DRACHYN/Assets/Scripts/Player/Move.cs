using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float vx;
    public float vy;
    public float speed;
    public float lookspeed;
    Rigidbody rb;
    [SerializeField] private Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void FixedUpdate()
    {
        Moving();
        LookOnCursor();

        if(vx != 0 || vy != 0) anim.SetBool("IsMoving", true);
        else anim.SetBool("IsMoving", false);
    }

    void Moving()
    {
        vx = Input.GetAxis("Horizontal");
        vy = Input.GetAxis("Vertical");

        transform.position = transform.position + new Vector3(vx, 0, vy) * speed * Time.deltaTime;
    }

    void LookOnCursor()
    {       
        //заставляет персонажа следить за курсором мышки
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
        float hitdist = 0;  		
        if (playerPlane.Raycast (ray, out hitdist))
        { 			
            Vector3 targetPoint = ray.GetPoint (hitdist);
            Quaternion targetRotation = Quaternion.LookRotation (targetPoint - transform.position);
            transform.rotation = Quaternion.Slerp (transform.rotation, targetRotation, lookspeed * Time.deltaTime);
        } 	
    }
}
