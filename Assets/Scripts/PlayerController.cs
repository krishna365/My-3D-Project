using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float speed = 2f;
    [SerializeField] float gravity = 10f;
    [SerializeField] float jumpHeight = 10f;
    [SerializeField] CharacterController controller;

    Vector3 velocity;

    public static PlayerController instance;

    private void Awake()
    {
        instance = this;
        controller = GetComponent<CharacterController>();
    }

    public bool isGrounded = true;

    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
