/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;

    private int desiredLane = 1;
    public float laneDistance = 4;

    public bool isGrounded;
    public LayerMask groundLayer;
    public Transform groundCheck;

    public float jumpForce;
    
    public float Gravity = -20;

    public Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!PlayerManager.isGameStarted)
            return;

        animator.SetBool("isGameStarted",true);

        direction.z = forwardSpeed;

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.17f, groundLayer);
        animator.SetBool("isGrounded", isGrounded);

        if (isGrounded)
        {
            direction.y = -2; //P4 4'20
            if(SwipeManager.swipeUp)//Input.GetKeyDown(KeyCode.UpArrow)
            {
                 Jump();
            }
        } else
        {
            animator.SetBool("isGrounded", !isGrounded);//
             direction.y += Gravity * Time.deltaTime;
        }

        

        if(SwipeManager.swipeRight)//Input.GetKeyDown(KeyCode.RightArrow) p9 3'16
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }

         if(SwipeManager.swipeLeft)//Input.GetKeyDown(KeyCode.LeftArrow)
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        transform.position = targetPosition; // p2 7:57
        controller.center = controller.center; // p8 16'
    }

    private void FixedUpdate()
        {
            if(!PlayerManager.isGameStarted)
            return;
            controller.Move(direction * Time.fixedDeltaTime);
        }

    private void Jump()
    {
        direction.y = jumpForce;
    }
    
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag=="Obstacle")
        {
            PlayerManager.gameOver = true;
        }
    }
}*/


using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 direction;
    public float forwardSpeed;

    private int desiredLane = 1;
    public float laneDistance = 4;

    public bool isGrounded;//
    public LayerMask groundLayer;//
    public Transform groundCheck;//

    public float jumpForce;
    
    public float Gravity = -20;

    public Animator animator;//


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!PlayerManager.isGameStarted)//
            return;                     //

        animator.SetBool("isGameStarted",true);//

        direction.z = forwardSpeed;

        isGrounded = Physics.CheckSphere(groundCheck.position, 0.17f, groundLayer);//
        animator.SetBool("isGrounded", isGrounded);//

        if (controller.isGrounded)
        {
            //direction.y = 0; P4 4'20
            if(SwipeManager.swipeUp)//Input.GetKeyDown(KeyCode.UpArrow)
            {
                 Jump();
            }
        } else
        {
            animator.SetBool("isGrounded", !isGrounded);//
             direction.y += Gravity * Time.deltaTime;
        }

        

        if(SwipeManager.swipeRight)//Input.GetKeyDown(KeyCode.RightArrow) p9 3'16
        {
            desiredLane++;
            if (desiredLane == 3)
                desiredLane = 2;
        }

         if(SwipeManager.swipeLeft)//Input.GetKeyDown(KeyCode.LeftArrow)
        {
            desiredLane--;
            if (desiredLane == -1)
                desiredLane = 0;
        }

        Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

        if (desiredLane == 0)
        {
            targetPosition += Vector3.left * laneDistance;
        }else if (desiredLane == 2)
        {
            targetPosition += Vector3.right * laneDistance;
        }

        transform.position = targetPosition; // p2 7:57
        controller.center = controller.center; // p8 16'
    }

    private void FixedUpdate()
        {
            if(!PlayerManager.isGameStarted)
            return;
            controller.Move(direction * Time.fixedDeltaTime);
        }

    private void Jump()
    {
        direction.y = jumpForce;
    }
    
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.transform.tag=="Obstacle")
        {
            PlayerManager.gameOver = true;
            FindObjectOfType<AudioManager>().PlaySound("GameOver");
        }
    }
}
