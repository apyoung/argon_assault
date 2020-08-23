using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour
{
    [Header("General")]
    [Tooltip("m/s")][SerializeField] float controlSpeed = 16f;
    [Tooltip("m")] [SerializeField] float xRange = 8f;
    [Tooltip("m")] [SerializeField] float yRange = 5f;

    [Header("Screen-Position Based")]
    [SerializeField] float positionPitchFactor = -2.5f;
    [SerializeField] float positionYawFactor = 3f;

    [Header("Control-Throw Based")]
    [SerializeField] float controlPitchFactor = -20f;
    [SerializeField] float controlRollFactor = -20f;

    float xThrow, yThrow;
    float clampedXPosition;
    float clampedYPosition;
    bool isControlEnabled = true;

    // Update is called once per frame
    void Update()
    {
        if (isControlEnabled)
        {
            ProcessTranslation();
            ProcessRotation();
        }
    }

    void OnPlayerDeath() //called by string reference
    {
        isControlEnabled = false;
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
        float xOffset = xThrow * controlSpeed * Time.deltaTime;
        float rawXPosition = transform.localPosition.x + xOffset;
        clampedXPosition = Mathf.Clamp(rawXPosition, -xRange, xRange);
    }

    private void calculateYPosition()
    {
        yThrow = CrossPlatformInputManager.GetAxis("Vertical");

        //in meters,  m = % * m/s * s
        float yOffset = yThrow * controlSpeed * Time.deltaTime;
        float rawYPosition = transform.localPosition.y + yOffset;
        clampedYPosition = Mathf.Clamp(rawYPosition, -yRange, yRange);
    }

    private void moveShip()
    {
        transform.localPosition = new Vector3(clampedXPosition,clampedYPosition,transform.localPosition.z);
    }
}
