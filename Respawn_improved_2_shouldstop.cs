using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    Vector3 startPos;
    Quaternion startRotation;
    public float threshold;

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
        startRotation = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < threshold)
        {
            transform.position = startPos;
            transform.rotation = startRotation;
            ResetPhysics(); // Reset physics components
        }
    }

    void ResetPhysics()
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        Collider collider = GetComponent<Collider>();

        // Stop any ongoing movement and rotation
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        if (!gameObject.CompareTag("Player"))
        {
            // Reset kinematic state and trigger status
            rb.isKinematic = true;
            //collider.isTrigger = false;
        }
    }
}