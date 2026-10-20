using UnityEngine;
using UnityEngine.InputSystem;


public class PlayerMove : MonoBehaviour
{
    public Rigidbody myRigidBody;
    public float walkSpeed;
    public Transform cameraTransform;
    void Start()
    {

    }

    void Update()
    {
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0;
        right.y = 0;

        forward.Normalize();
        right.Normalize();

        // Store the current value of the keys pressed in vector3
        // a + d -> 1 - 1 = 0 -> Vector3(0, 0, 0)
        // w + d -> Vector3(1, 0, 1)
        Vector3 move = Vector3.zero;

        if (Keyboard.current.wKey.isPressed)
        {
            move.z += 1;
        }
        if (Keyboard.current.sKey.isPressed)
        {
            move.z -= 1;
        }
        if (Keyboard.current.aKey.isPressed)
        {
            move.x -= 1;
        }
        if (Keyboard.current.dKey.isPressed)
        {
            move.x += 1;
        }

        // Accord for the 41% speedboost while moving diagonally
        // √(1 + 1) = √2 ≈ 1.41
        // √(1 + 0) = √1 = 1
        move.Normalize();

        Vector3 moveDirection = forward * move.z + right * move.x;

        moveDirection *= walkSpeed;

        myRigidBody.linearVelocity = new Vector3(moveDirection.x, myRigidBody.linearVelocity.y, moveDirection.z);
    }
}
