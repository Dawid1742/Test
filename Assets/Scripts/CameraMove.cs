using UnityEngine;
using UnityEngine.InputSystem;

public class cameraMove : MonoBehaviour
{
    public GameObject player;
    public Transform cameraTransform;
    public float cameraOffsetX;
    public float cameraOffsetY;
    public float cameraOffsetZ;
    public float sensitivity = 0.1f;

    private float rotationX;
    private float rotationY;

    void Start()
    {

    }

    void Update()
    {
        // Read mouse postion
        Vector2 mousePos = Mouse.current.delta.ReadValue();

        rotationX += mousePos.x * sensitivity;
        rotationY -= mousePos.y * sensitivity;
        rotationY = Mathf.Clamp(rotationY, -90f, 90f);

        Quaternion rotation = Quaternion.Euler(rotationY, rotationX, 0);

        // Update the camera position according to the player position and mouse position
        transform.position = new Vector3(player.transform.position.x + cameraOffsetX, player.transform.position.y + cameraOffsetY, player.transform.position.z + cameraOffsetZ);
        transform.rotation = rotation;

    }
}

