using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder;

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
    public LayerMask layer;
    Vector3 move;

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
        if (ComprobacionTecho()) 
        {
            Debug.Log("techo");
            playerVelocity.y += gravityValue * Time.deltaTime;
        }
        playerVelocity.y += gravityValue * Time.deltaTime;

        //SimpleMove aplica la gravedad de Unity
        //Vector3 move = new Vector3(inputKey.x, 0, inputKey.z);
        //controller.SimpleMove(move * playerSpeed);


       move = new Vector3(inputKey.x, playerVelocity.y, inputKey.z);
        
    }

    public void FixedUpdate()
    {
        controller.Move(transform.TransformDirection(move * playerSpeed * Time.fixedDeltaTime));
        controller.transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal") * rotSpeed, 0f));
    }

    bool ComprobacionTecho()
    {
        RaycastHit Datos;
        // Cogemos la altura del personaje
        float tama = GetComponent<Transform>().localScale.y;
        // posicion inicial, radio de la pelota, direcci�n, datos, distancia
        return Physics.SphereCast(transform.position + new Vector3(0,4,0), tama / 4, Vector3.up, out Datos, 0.2f);
    }
}
