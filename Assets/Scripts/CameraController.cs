using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        float cameraRot = 0;
        transform.Translate(Input.GetAxis("Horizontal") * Time.deltaTime * 3, 0, Input.GetAxis("Vertical") * Time.deltaTime * 3);

        if (Input.GetKey(KeyCode.Q))
        {
            cameraRot -= 1;
        }

        if (Input.GetKey(KeyCode.E))
        {
            cameraRot += 1;
        }

        transform.Rotate(0, cameraRot, 0);

    }
}