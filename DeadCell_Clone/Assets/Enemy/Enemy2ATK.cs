using System.Collections;
using System.Collections.Generic;
using System.Xml.Serialization;
using UnityEngine;



    // Start is called before the first frame updat
   /* public Transform Target;
    public Vector2 Direction;
    public GameObject Arrow;
    public GameObject ArrowEnemy;
    public Transform checkRight;
    public float FireRate;
    public bool isRight;
    float nextTimeToFire = 0;
    public Transform ArrowPoint;
    public float Force;
    public Animator animator;


    // Update is called once per frame
    private void Start()
    {
        Target = FindObjectOfType<PlayerStatus>().transform;
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
       
        CheckRight();
    }
    public void CheckRight()
    {


        Vector2 targetPos = Target.position;
        Direction = targetPos - (Vector2)this.gameObject.transform.position;
        if ((Target.position.x - checkRight.position.x) > 0 && (Target.position.x - checkRight.position.x) < 5 && (checkRight.position.y - Target.position.y) < 25)
        {
            Arrow.transform.forward = Direction;
            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate;
                animator.SetBool("ATK", true);
            }
        }
        else
        {
            animator.SetBool("ATK", false);
        }

    }*/


public class Enemy2ATK : MonoBehaviour
{
    // Start is called before the first frame updat
    public Transform Target;
    public Vector2 Direction;
    public GameObject Arrow;
    public GameObject ArrowEnemy;
    public Transform checkRight;
    public float FireRate;
    public bool isRight;
    float nextTimeToFire = 0;
    public Transform ArrowPoint;
    public float Force;
    public Animator animator;


    // Update is called once per frame
    private void Start()
    {
        Target = FindObjectOfType<PlayerStatus>().transform;
        animator = GetComponent<Animator>();
    }
    void FixedUpdate()
    {
        CheckRight();
    }
    public void CheckRight()
    {


        Vector2 targetPos = Target.position;
        Direction = targetPos - (Vector2)this.gameObject.transform.position;
        if ((Target.position.x - checkRight.position.x) > 0 && (Target.position.x - checkRight.position.x) < 5 && Vector2.Distance(checkRight.position,targetPos) < 10)
        {
            Arrow.transform.forward = Direction;
            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate;
                animator.SetBool("ATK", true);
            }
        }
        else
        {
            animator.SetBool("ATK", false);
        }

    }
}


