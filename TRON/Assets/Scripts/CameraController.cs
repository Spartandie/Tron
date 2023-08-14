using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    [SerializeField] float sensitivity = 5.0f;
    [SerializeField] GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        //transform.eulerAngles += new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
      

        // Rotate the camera based on the mouse movement
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");
        transform.eulerAngles += new Vector3(-mouseY * sensitivity, mouseX * sensitivity, 0);

        Vector3 rotationAmount = new Vector3(mouseX, 0, 0) * sensitivity;
        // Debug.Log("mouseX: " + mouseX);
        //Debug.Log("rotationAmount: "+ rotationAmount.x);
        player.transform.Rotate(rotationAmount);
    }
}
