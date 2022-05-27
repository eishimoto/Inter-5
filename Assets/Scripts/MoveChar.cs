using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveChar : MonoBehaviour
{
    [SerializeField] private Camera m_Camera;
    [SerializeField] private float speed = 4f;
    [SerializeField] private float sprintSpeed = 6f;
    [SerializeField] private float jumpForce;
    [SerializeField] private float rotationSpeed;
    
    [SerializeField] private bool backwardsLevel;

    private CharacterController controller;
    private AudioSource audioSource;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioClip jump;

    private Animator animator;

    float myDesiredRotation = 0f;

    bool mySprint = false;
    bool myJumping = false;

    float mySpeedY = 0f;
    float myGravity = -9.81f;

    private void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        audioSource = gameObject.GetComponent<AudioSource>();
        animator = gameObject.GetComponent<Animator>();
        myJumping = false;
    }

    void Update()
    {
        Movement();
        WalkSound();
        AnimationHandler();
    }

    private void Movement()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float z = Input.GetAxisRaw("Vertical");

        if (Input.GetButtonDown("Jump") && !myJumping)
        {
            jumpSound.PlayOneShot(jump);
            animator.SetTrigger("Jump");
            animator.SetBool("isJumping", true);
            myJumping = true;
            mySpeedY = 0;
            mySpeedY += Mathf.Sqrt(jumpForce * -2 * myGravity);
            audioSource.Stop();
        }

        if (!controller.isGrounded)
        {
            mySpeedY += myGravity * Time.deltaTime;
        }
        else if (mySpeedY < 0)
        {
            mySpeedY = 0;
        }
        
        if (myJumping && mySpeedY <= 0)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, Vector3.down, out hit, 2f, LayerMask.GetMask("Ground")))
            {
                Debug.DrawRay(transform.position, Vector3.down * 3f, Color.blue);
                myJumping = false;
                animator.SetBool("isJumping", false);
            }
        }

        mySprint = Input.GetKey(KeyCode.LeftShift);
        Vector3 movement = new Vector3(x, 0, z).normalized;

        Vector3 rotateMovement = Quaternion.Euler(0, m_Camera.transform.rotation.eulerAngles.y, 0) * movement;
        Vector3 verticalMovement = Vector3.up * mySpeedY;

        controller.Move((verticalMovement + (rotateMovement * (mySprint ? sprintSpeed : speed))) * Time.deltaTime);

        if (rotateMovement.magnitude > 0)
        {
            myDesiredRotation = Mathf.Atan2(rotateMovement.x, rotateMovement.z) * Mathf.Rad2Deg;
        }
        Quaternion currentRotation = transform.rotation;
        Quaternion targetRotation = Quaternion.Euler(0, myDesiredRotation, 0);
        transform.rotation = Quaternion.Lerp(currentRotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    private void WalkSound()
    {
       if(controller.isGrounded)
        {
            if (controller.velocity.magnitude > 1f && !audioSource.isPlaying)
            {
                audioSource.Play();
            }
            else if (controller.velocity.magnitude < 1f && audioSource.isPlaying)
            {
                audioSource.Stop();
            }
        }
    }
    
    private void AnimationHandler()
    {
        animator.SetFloat("Speed", controller.velocity.magnitude);
    }
}
