using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // The player to follow
    public Transform player;

    // Offset distance between the camera and the player
    public Vector3 offset;

    // Smoothing factor for the camera movement
    public float smoothSpeed = 0.125f;

    // To make the camera Y position fixed while following player
    private float fixedYPosition;

    void Start()
    {
        // Initialize the offset if it's not set manually
        if (offset == Vector3.zero)
        {
            offset = transform.position - player.position;
        }

        // Save the fixed Y position to keep the camera from drifting
        fixedYPosition = transform.position.y;
    }

    void LateUpdate()
    {
        // Calculate the desired position based on the player's X and Z position + offset
        Vector3 desiredPosition = new Vector3(player.position.x + offset.x, fixedYPosition + offset.y, player.position.z + offset.z);

        // Smoothly move the camera to the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Update camera's position, but don't change rotation
        transform.position = smoothedPosition;

        // Ensure the camera's rotation stays fixed (no rotation)
        transform.rotation = Quaternion.identity; // Set to no rotation (0, 0, 0)
    }
}
