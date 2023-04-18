using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationSpeed;
    public float waitTime;
    public float rotateAngle;

    private Quaternion targetRotation;
    private float elapsedTime;

    void Start()
    {
        targetRotation = transform.rotation * Quaternion.Euler(0, rotateAngle, 0);
    }

    void Update()
    {
        elapsedTime += Time.deltaTime;

        if (elapsedTime >= waitTime)
        {
            elapsedTime = 0f;
            rotateAngle *= -1;
            targetRotation = transform.rotation * Quaternion.Euler(0, rotateAngle, 0);
        }

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }
}
