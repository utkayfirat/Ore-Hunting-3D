using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    //Variables
    [SerializeField] private float moveSpeed;
    [SerializeField] private float walkSpeed;

    public bool isMining = false;
    public bool isOreHave = false;

    //Vectors
    private Vector3 moveDirection;
    private Vector3 velocity;

    [SerializeField] private bool isGrounded;
    [SerializeField] private float groundCheckDistance;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravity;

    //REF
    private CharacterController controller;
    private Animator anim;
    public bool canMovement = true;

    private float mineSpeed;
    private bool coldDown;

    public JoystickMovement joystickMovement;

    void Start(){
        walkSpeed = PlayerPrefs.GetFloat("Character Speed",2);
        mineSpeed = PlayerPrefs.GetFloat("Pickaxe Speed", 0.9f);
        controller = GetComponent<CharacterController>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update(){
        walkSpeed = PlayerPrefs.GetFloat("Character Speed",2);
        mineSpeed = PlayerPrefs.GetFloat("Pickaxe Speed", 0.9f);
        
        if(isMining)
            anim.speed = mineSpeed;
        else
            anim.speed = 1;

        if(canMovement){
            if(anim.GetCurrentAnimatorStateInfo(0).IsName("player_mine")){
                isMining = true;
            }else{
                isMining = false;
            }
            
            if(!isMining)
                Move();
        }
    }

    private void Move(){

        isGrounded = Physics.CheckSphere(transform.position, groundCheckDistance, groundMask);

        if(isGrounded && velocity.y < 0){
            velocity.y = -2f;
        }

        float moveZ = joystickMovement.inputVertical(); //Input.GetAxis("Vertical");
        float moveY = joystickMovement.inputHorizontal(); //Input.GetAxis("Horizontal");

        moveDirection = new Vector3(moveY,0,moveZ);
        if(moveDirection != Vector3.zero){
            Quaternion toRotation = Quaternion.LookRotation(moveDirection, Vector3.up);
            transform.rotation = Quaternion.RotateTowards(transform.rotation, toRotation, 800f * Time.deltaTime);
        }
 
        if(isGrounded){
            if(moveDirection != Vector3.zero){
                Walk();
            }else if(moveDirection == Vector3.zero){
                Idle();
            }

            if(isOreHave && moveDirection == Vector3.zero){
                Mine();
            }
           

            moveDirection *= moveSpeed;

        }

        controller.Move(moveDirection*Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);

        
    }

    private void Idle(){
        anim.SetFloat("Speed", 0, 0.1f, Time.deltaTime);
    }

    private void Walk(){
        moveSpeed = walkSpeed;
        if(walkSpeed <= 2)
            anim.SetFloat("Speed", 0.5f, 0.1f, Time.deltaTime);
        else
            anim.SetFloat("Speed", 1f, 0.1f, Time.deltaTime);
    }

    private void Mine(){
        if(!isMining){
            if(isOreHave && !coldDown){
                StartCoroutine(mienlast());
            }
        }

    }

    IEnumerator mienlast(){
        anim.SetTrigger("Mine");
        coldDown = true;
        yield return new WaitForSeconds(1f);
        coldDown = false;
    }


}
