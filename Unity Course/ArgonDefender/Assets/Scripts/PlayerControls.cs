using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    [SerializeField] float angularSpeed = 20f;
    [SerializeField] private float xPosRange = 11f;
    [SerializeField] private float yPosRange = 7f;

    [SerializeField] private float pitchFactor = -2f;
    [SerializeField] private float yawFactor = 2f;
    [SerializeField] private float rollFactor = -20f;
    [SerializeField] private float verticalPitchFactor = -10f;
    [SerializeField] private float rotationFactor = 1f;
    
    private float horizontal, vertical;
    
    // Update is called once per frame
    void Update()
    {
        TranslatePosition();
        RotatePosition();
    }

    private void RotatePosition()
    {
        float pitchToPosition = transform.localPosition.y * pitchFactor;
        float pitchToVertical =  vertical * verticalPitchFactor;
        float pitch = pitchToPosition + pitchToVertical;
        
        float yawToPosition = transform.localPosition.x * yawFactor;
        float yaw = yawToPosition;
        float roll = horizontal * rollFactor;
        Quaternion targetRotation = Quaternion.Euler(pitch, yaw, roll);
        transform.localRotation = Quaternion.RotateTowards(transform.localRotation, targetRotation, rotationFactor);
        // transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void TranslatePosition()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");


        float xOffset = horizontal * Time.deltaTime * angularSpeed;
        float yOffset = vertical * Time.deltaTime * angularSpeed;

        float newXOffset = transform.localPosition.x + xOffset;
        float clampedXPos = Mathf.Clamp(newXOffset, -xPosRange, xPosRange);

        float newYOffset = transform.localPosition.y + yOffset;
        float clampedYPos = Mathf.Clamp(newYOffset, -yPosRange, yPosRange);

        transform.localPosition = new Vector3(clampedXPos, clampedYPos, transform.localPosition.z);
    }
}
