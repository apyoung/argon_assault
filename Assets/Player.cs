using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("m/s")][SerializeField] float xSpeed = 10f;
    [Tooltip("m")] [SerializeField] float xBound = 8f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");

        //in meters,  m = % * m/s * s
        float xOffset = xThrow * xSpeed * Time.deltaTime;
        float rawXPosition = transform.localPosition.x + xOffset;
        float clampedXPosition = Mathf.Clamp(rawXPosition, -xBound, xBound);

        transform.localPosition = new Vector3(
            clampedXPosition, 
            transform.localPosition.y, 
            transform.localPosition.z);
    }
}
