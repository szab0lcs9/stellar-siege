using System;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    internal Rigidbody rigidbody;
    PlayerVFX playerVFX;

    [SerializeField] internal float movementSpeed;
    [SerializeField] internal float rotationSpeed;
    [SerializeField] internal float strafeSpeed;

    void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
        playerVFX = GetComponent<PlayerVFX>();
    }

    void FixedUpdate()
    {
        float verticalInput = Input.GetAxis("Vertical");
        float horizontalInput = Input.GetAxis("Horizontal");

        MovePlayerForwardOrBackward(verticalInput);
        if (playerVFX != null)
            PlayMovementVFX(verticalInput);

        RotatePlayer(horizontalInput);
        if (playerVFX != null)
            PlayRotatingVFX(horizontalInput);

        StrafeLeft();
        StrafeRight();
    }

    internal void MovePlayerForwardOrBackward(float input)
    {
        Vector3 movement = transform.forward * input * movementSpeed * Time.deltaTime;
        rigidbody.AddForce(movement);
    }

    internal void RotatePlayer(float input)
    {
        Vector3 rotation = new Vector3(0.0f, input * rotationSpeed, 0.0f);
        rigidbody.AddTorque(rotation);
    }

    internal void StrafeLeft()
    {
        if (Input.GetKey("q"))
        {
            Vector3 strafe = new Vector3(-strafeSpeed * Time.deltaTime, 0.0f, 0.0f);
            rigidbody.AddRelativeForce(strafe);
        }
    }

    internal void StrafeRight()
    {
        if (Input.GetKey("e"))
        {
            Vector3 strafe = new Vector3(strafeSpeed * Time.deltaTime, 0.0f, 0.0f);
            rigidbody.AddRelativeForce(strafe);
        }
    }

    internal void StopMovement()
    {
        Vector3 actualVelocity = rigidbody.velocity;
        rigidbody.AddForce(-actualVelocity);
        rigidbody.velocity = Vector3.zero;
    }

    internal void PlayMovementVFX(float input)
    {
        playerVFX.PlayExhaustParticlesWhenMoving(input);
    }

    internal void PlayRotatingVFX(float input)
    {
        playerVFX.PlayExhaustParticlesWhenRotating(input);
    }
}
