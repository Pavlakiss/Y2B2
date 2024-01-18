using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public float speed = 1.0f; // Speed at which the object moves upwards
    public float targetHeight = 5.0f; // The height at which the object should stop moving

    private void Update()
    {
        // Check if the object has not yet reached the target height
        if (transform.position.y < targetHeight)
        {
            // Move the object upwards
            transform.position += Vector3.up * speed * Time.deltaTime;

            // Clamp the position to ensure it doesn't go past the target height
            if (transform.position.y > targetHeight)
            {
                transform.position = new Vector3(transform.position.x, targetHeight, transform.position.z);
            }
        }
    }
}
