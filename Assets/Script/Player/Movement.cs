using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed = 4.0f;
    public float jumpHeight = 5.0f;
    private float gravityValue = -9.81f;
    public Vector3 inputKey;
    public float rotSpeed = 10f;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        
        inputKey = new Vector3(0, 0, Input.GetAxis("Vertical"));

        groundedPlayer = controller.isGrounded;
        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        if (Input.GetButtonDown("Jump") && groundedPlayer)
        {
            //playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            playerVelocity.y = jumpHeight;
        }

        playerVelocity.y += gravityValue * Time.deltaTime;

        //SimpleMove aplica la gravedad de Unity
        //Vector3 move = new Vector3(inputKey.x, 0, inputKey.z);
        //controller.SimpleMove(move * playerSpeed);


        Vector3 move = new Vector3(inputKey.x, playerVelocity.y, inputKey.z);
        controller.Move(transform.TransformDirection(move * playerSpeed * Time.deltaTime));
        controller.transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * rotSpeed, 0f));
    }
}
