using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // Reference to the car object
    public float sensitivity = 15f;

    private float rotationX = 0f;
    private float rotationY = 0f;

    void LateUpdate()
    {
        if (target == null)
            return;

        // Rotate the camera based on mouse input
        rotationY += Input.GetAxis("Mouse X") * sensitivity;
        rotationX += Input.GetAxis("Mouse Y") * -1 * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f); // Clamp vertical rotation

        // Calculate the desired rotation based on the car's position
        Quaternion targetRotation = Quaternion.Euler(rotationX, rotationY, 0);
        Vector3 targetPosition = target.position - (targetRotation * Vector3.forward * 10f);

        // Update the camera's position and rotation
        transform.position = targetPosition;
        transform.rotation = targetRotation;
    }
}