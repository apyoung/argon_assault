using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Player : MonoBehaviour
{
    [Tooltip("m/s")][SerializeField] float xSpeed = 10f;

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
        float rawNewXPosition = transform.localPosition.x + xOffset;

        transform.localPosition = new Vector3(rawNewXPosition, transform.localPosition.y, transform.localPosition.z);
    }
}
