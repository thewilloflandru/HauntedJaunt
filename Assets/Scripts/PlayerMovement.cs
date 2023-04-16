using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float turnSpeed = 20f; // angle in rad/sec * deltaTime for amount should turn each frame
    
    // Tut advises that non-public member variables begin with m_ then PascalCase; m_ for member
    Vector3 m_Movement;
    Quaternion m_Rotation = Quaternion.identity; // essentially setting to 0 for a quaternion
    Animator m_Animator;
    Rigidbody m_Rigidbody;  // for physics
    AudioSource m_AudioSource; // for audio

    // Start is called before the first frame update
    void Start()
    {
        m_Animator = GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_AudioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // Set player vector --------------------------------------------------
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        m_Movement.Set(horizontal, 0f, vertical);
        m_Movement.Normalize(); // don't want diagonal movement to be faster than straight

        // Set up animator component ------------------------------------------
        // this function returns true if both passed floats are approximately equal
        bool hasHorizontalInput = !Mathf.Approximately(horizontal, 0f);
        bool hasVerticalInput = !Mathf.Approximately(vertical, 0f);
        bool isWalking = hasHorizontalInput || hasVerticalInput;

        // to set "IsWalking" param in Assets > Animation > Animators > JohnLennon
        m_Animator.SetBool("IsWalking", isWalking);
        // set up aduio to play on movement logic gate
        if (isWalking)
        {
            if (!m_AudioSource.isPlaying)
            {
                m_AudioSource.Play();
            }
        }
        else
        {
            m_AudioSource.Stop();
        }


        // Create rotation for character --------------------------------------
        Vector3 desiredForward = Vector3.RotateTowards(transform.forward, m_Movement, turnSpeed * Time.deltaTime, 0f);
        m_Rotation = Quaternion.LookRotation(desiredForward); // creates rot looking in direction of argument
    }

    // Allows to apply root motion as you want, which means mov and rot can be applied separately
    void OnAnimatorMove()
    {
        // deltaPosition is change in pos due to root motion that would have been applied to this frame
        m_Rigidbody.MovePosition(m_Rigidbody.position + m_Movement * m_Animator.deltaPosition.magnitude);
        m_Rigidbody.MoveRotation(m_Rotation);
    }
}
