using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    //Movement
    public float speed = 5.0f;
    Vector3 velocity;
    Vector3 moveDirection;
    CharacterController controller;

    //Gravity
    public float jumpHeight = 1.0f;
    float gravity = -9.8f;
    public bool grounded;


    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        grounded = controller.isGrounded;

        if (grounded && velocity.y < 0)
        {
            velocity.y = 0;

        }

        //Move on plane
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        float verticalMove = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector3(horizontalMove, 0, verticalMove).normalized;

        controller.Move(moveDirection * speed * Time.deltaTime);

        //Jump
        if (grounded && Input.GetKeyDown(KeyCode.Space))
        {
            velocity.y += Mathf.Sqrt(jumpHeight * -2.0f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
