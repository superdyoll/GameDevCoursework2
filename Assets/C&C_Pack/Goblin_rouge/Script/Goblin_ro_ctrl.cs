using UnityEngine;
using System.Collections;

public class Goblin_ro_ctrl : MonoBehaviour
{
    private Animator anim;
    private CharacterController controller;
    private bool battle_state;
    public float speed = 6.0f;
    public float runSpeed = 1.7f;
    public float turnSpeed = 60.0f;
    public float gravity = 20.0f;
    private Vector3 moveDirection = Vector3.zero;

    // Use this for initialization
    void Start()
    {
        anim = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("2")) //battle_idle
        {
            anim.SetInteger("battle", 1);
            battle_state = true;
        }
        if (Input.GetKey("1")) //idle
        {
            anim.SetInteger("battle", 0);
            battle_state = false;
        }


        if (Input.GetKeyDown("m")) //defence_start
        {
            anim.SetInteger("moving", 6);
        }


        if (Input.GetKeyDown("p")) // defence_start
        {
            anim.SetInteger("moving", 8);
        }
        if (Input.GetKeyUp("p")) // defence_end
        {
            anim.SetInteger("moving", 9);
        }


        if (Input.GetMouseButtonDown(0)) //attack
        {
            anim.SetInteger("moving", 3);
        }
        if (Input.GetMouseButtonDown(1)) //alt attack1
        {
            anim.SetInteger("moving", 4);
        }
        if (Input.GetMouseButtonDown(2)) //alt attack2
        {
            anim.SetInteger("moving", 5);
        }

        if (Input.GetKeyDown("space")) //jump
        {
            print("SPAAACE");
            anim.SetInteger("jump", 1);
        }


        if (Input.GetKeyDown("o")) //die_1
        {
            anim.SetInteger("moving", 12);
        }
        if (Input.GetKeyDown("i")) //die_2
        {
            anim.SetInteger("moving", 13);
        }

        if (Input.GetKeyDown("u")) //defence
        {
            int n = Random.Range(0, 2);
            if (n == 0)
            {
                anim.SetInteger("moving", 10);
            }
            else
            {
                anim.SetInteger("moving", 11);
            }
        }


        if (controller.isGrounded)
        {
            anim.SetInteger("jump", 0);
            moveDirection = getMoveDirection();
            if (moveDirection != Vector3.zero)
            {
                if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
                {
                    run(moveDirection);
                }
                else
                {
                    walk(moveDirection);
                }
            }
            else
            {
                anim.SetInteger("moving", 0);
            }
        }
        else
        {
            if (moveDirection.y < -1.5f)
            {
                anim.SetInteger("jump", anim.GetInteger("jump") == 0 ? 1 : 2);
            }
        }

        //float turn = Input.GetAxis("Horizontal");
        //transform.Rotate(0, turn * turnSpeed * Time.deltaTime, 0);
        controller.Move(moveDirection * Time.deltaTime);
        moveDirection.y -= gravity * Time.deltaTime;
    }

    private Vector3 getMoveDirection()
    {
        float forward = Input.GetAxis("Vertical");
        float sideways = Input.GetAxis("Horizontal");

        Vector3 moveDirectionForwards = Vector3.forward * forward * speed * runSpeed;
        Vector3 moveDirectionSideways = Vector3.right * sideways * speed * runSpeed;

        if (moveDirectionSideways == Vector3.zero)
        {
            return moveDirectionForwards;
        }
        else if (moveDirectionForwards == Vector3.zero)
        {
            return moveDirectionSideways;
        }
        else
        {
            return (moveDirectionSideways + moveDirectionForwards) * 3 / 4;
        }
    }


    private void run(Vector3 moveDirection)
    {
        anim.SetInteger("moving", 2); //run
        runSpeed = 2.6f;
    }

    private void walk(Vector3 moveDirection)
    {
        if (moveDirection.magnitude > Vector3.zero.magnitude)
        {
            moveDirection.Normalize();
            transform.rotation = Quaternion.LookRotation(moveDirection);
            anim.SetInteger("moving", 1); //walk
            runSpeed = 1.0f;
        }
    }
}