using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("m/s")][SerializeField] float xSpeed = 16f;
    [Tooltip("m/s")][SerializeField] float ySpeed = 12f;
    [Tooltip("m")] [SerializeField] float xBound = 8f;
    [Tooltip("m")] [SerializeField] float yBound = 5f;
    [SerializeField] float positionPitchFactor = -2.5f;
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float positionYawFactor = 3f;
    [SerializeField] float controlRollFactor = -20f;

    float xThrow, yThrow;
    float clampedXPosition;
    float clampedYPosition;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessRotation()
    {
        float pitch = transform.localPosition.y * positionPitchFactor + yThrow * controlPitchFactor;
        float yaw = transform.localPosition.x * positionYawFactor;
        float roll = xThrow * controlRollFactor;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    private void ProcessTranslation()
    {
        calculateXPosition();
        calculateYPosition();
        moveShip();
    }

    private void calculateXPosition()
    {
        xThrow = CrossPlatformInputManager.GetAxis("Horizontal");

        //in meters,  m = % * m/s * s
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawXPosition = transform.localPosition.x + xOffset;
        clampedXPosition = Mathf.Clamp(rawXPosition, -xBound, xBound);
    }

    private void calculateYPosition()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        //in meters,  m = % * m/s * s
        float yOffset = yThrow * ySpeed * Time.deltaTime;
        float rawYPosition = transform.localPosition.y + yOffset;
        clampedYPosition = Mathf.Clamp(rawYPosition, -yBound, yBound);
    }

    private void moveShip()
    {
        transform.localPosition = new Vector3(clampedXPosition,clampedYPosition,transform.localPosition.z);
    }
}
