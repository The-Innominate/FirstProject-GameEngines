using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField][Range(1, 20)][Tooltip("Force to move object")] public float force;

    [SerializeField] public Rigidbody rb;

    private void Awake()
    {
        print("Awake");
    }
    // Start is called before the first frame update
    void Start()
    {
        print("Start");
    }

    // Update is called once per frame
    void Update()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 0.5f))
        {
            // Object is touching the ground

           //Turn gravity off
            rb.useGravity = false;
        }
        else
        {
            // Object is not touching the ground
            //Turn gravity on
            rb.useGravity = true;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            //GetComponent<Rigidbody>().AddForce(transform.up * force, ForceMode.VelocityChange);
            rb.AddForce(transform.up * force, ForceMode.VelocityChange);
        }
       if (Input.GetKeyDown(KeyCode.A))
        {
            rb.AddForce(transform.right * -force, ForceMode.VelocityChange);
        }
       if (Input.GetKeyDown(KeyCode.D))
        {
                rb.AddForce(transform.right * force, ForceMode.VelocityChange);
          }
       if (Input.GetKeyDown(KeyCode.W))
        {
            rb.AddForce(transform.forward * force, ForceMode.VelocityChange);
        }
       if (Input.GetKeyDown(KeyCode.S))
        {
            rb.AddForce(transform.forward * -force, ForceMode.VelocityChange);
        }
    }
}
