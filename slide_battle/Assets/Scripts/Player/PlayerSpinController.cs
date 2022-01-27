using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpinController : MonoBehaviour
{
    Rigidbody rigidbody;
    float speedLimit;
    float spinSpeedMultiplier;
    float currentSpinSpeed;
    public float spinSpeedLimit;
    private void Start() {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        speedLimit = gameObject.GetComponent<PlayerMovementController>().speedLimit;
    }
    void Update()
    {
        spinSpeedMultiplier = rigidbody.velocity.magnitude/speedLimit;

        currentSpinSpeed = spinSpeedLimit * spinSpeedMultiplier;

        Vector3 rotation = gameObject.transform.eulerAngles;

        rotation.y += currentSpinSpeed;

        gameObject.transform.eulerAngles = rotation;
    }
}
