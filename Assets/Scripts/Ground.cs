using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ground : MonoBehaviour
{
    [SerializeField] public Rigidbody rb;
    [SerializeField] public MeshCollider patrolArea;
    Vector3 patrolAreaSize;

    // Start is called before the first frame update
    public float walkSpeed = 2f;
    public float walkDistance = 5f; // Adjust the distance as needed

    private float initialPosition;

    void Start()
    {
        // Record the initial position
        initialPosition = transform.position.x;
    }

    void Update()
    {
        // Move forward
        transform.Translate(Vector3.forward * walkSpeed * Time.deltaTime);

        // Check if the object has walked the desired distance
        if (Mathf.Abs(transform.position.x - initialPosition) >= walkDistance)
        {
            // Turn around
            Flip();
        }
    }

    void Flip()
    {
        // Change the direction by rotating 180 degrees around the Y-axis
        transform.Rotate(0f, 180f, 0f);

        // Update the initial position for the next walk cycle
        initialPosition = transform.position.x;
    }
}
