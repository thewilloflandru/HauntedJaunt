using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationSpeed;
    public float waitTime;
    public float rotateAngle; // Rotate by x degrees

    private Quaternion targetRotation;
    private float elapsedTime;

    void Start()
    {
        // Set the first target rotation to begin rotating immediately
        targetRotation = transform.rotation * Quaternion.Euler(0, rotateAngle, 0);
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= waitTime) // Wait for waitTime seconds, then set target angle to opposite direction
        {
            elapsedTime = 0f;
            rotateAngle *= -1;
            targetRotation = transform.rotation * Quaternion.Euler(0, rotateAngle, 0);
        }
        // Do the smooth rotation over time, slowing down as it gets close to target
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
