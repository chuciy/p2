using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    // Start is called before the first frame update
    public enum MoveState
    { 
        Idle,
        Attack,
        Return
    }

    public MoveState cur_state;
    public GameObject player;
    public GameObject retrun_point;
    private Animator anim;
    void Start()
    {
        cur_state = MoveState.Idle;
        anim = GetComponent<Animator>();

        StartCoroutine("FSM");
        StartCoroutine("Moving");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "cat")
        { 
            Debug.Log("123"); 
        }
    }

    IEnumerator FSM() 
    {
        while (true) 
        {
            yield return new WaitForSeconds(0.50f);
            float distance = Vector3.Distance(transform.position, player.transform.position);
            float d2origin = Vector3.Distance(transform.position, retrun_point.transform.position);
            switch (cur_state) 
            {
                case MoveState.Idle:
                    if (distance <= 3.0f) 
                    {
                        Debug.Log("Attack");
                        cur_state = MoveState.Attack;
                    }
                    break;
                case MoveState.Attack:
                    if (distance >= 5.0f)
                    {
                        Debug.Log("Return");
                        cur_state = MoveState.Return;
                    }
                    break;
                case MoveState.Return:
                    if (d2origin <= 2.0f)
                    {
                        Debug.Log("Idle");
                        cur_state = MoveState.Idle;
                    }
                    break;
                default:
                    break;
            }
        }
    }

    IEnumerator Moving() 
    {
        while (true) 
        {
            yield return null;
            switch (cur_state)
            {
                case MoveState.Idle:
                    anim.SetInteger("Walk", 0);
                    break;
                case MoveState.Attack:
                    anim.SetInteger("Walk", 1);
                    break;
                case MoveState.Return:

                    break;
                default:
                    break;
            }
        }
    
    }
}
