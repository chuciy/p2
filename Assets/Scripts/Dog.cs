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

    public float speed;
    public float rs;
    public MoveState cur_state;
    public GameObject player;
    public GameObject retrun_point;
    private Animator anim;
    private Vector3 dir;
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
            Debug.Log("Onhit");
            collision.collider.gameObject.GetComponent<MainPlayerController>().Onhit(transform.position);
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
                    if (distance <= 20.0f) 
                    {
                        Debug.Log("Attack");
                        cur_state = MoveState.Attack;
                    }
                    break;
                case MoveState.Attack:
                    if (distance >= 25.0f)
                    {
                        Debug.Log("Return");
                        cur_state = MoveState.Return;
                    }
                    break;
                case MoveState.Return:
                    if (d2origin <= 5.0f)
                    {
                        Debug.Log("Idle");
                        cur_state = MoveState.Idle;
                    } else if (distance <= 15.0f) 
                    {
                        Debug.Log("Attack");
                        cur_state = MoveState.Attack;
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
                    dir = Vector3.Normalize(player.transform.position - transform.position);
                    transform.position += dir * speed * Time.deltaTime;
                    transform.rotation = Quaternion.Lerp(transform.rotation,
                                                        Quaternion.LookRotation(player.transform.position - transform.position),
                                                         rs * Time.deltaTime);
                    break;
                case MoveState.Return:
                    anim.SetInteger("Walk", 1);
                    dir = Vector3.Normalize(retrun_point.transform.position - transform.position);
                    transform.position += dir * speed * 0.5f * Time.deltaTime;
                    transform.rotation = Quaternion.Lerp(transform.rotation,
                                                        Quaternion.LookRotation(retrun_point.transform.position - transform.position),
                                                         rs * Time.deltaTime);
                    break;
                default:
                    break;
            }
        }
    
    }
}
