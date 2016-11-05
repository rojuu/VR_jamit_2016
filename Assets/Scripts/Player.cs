using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    public float lookSensitivity;
    Rigidbody rigidBody;
    GameObject fp_camera;

    // Use this for initialization
    void Start()
    {
        rigidBody = GetComponent<Rigidbody>();
        fp_camera = Camera.main.gameObject;
        
        if (rigidBody == null || fp_camera == null)
        {
            Destroy(this);
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = Input.GetAxis("Mouse Y");

        Vector3 moveDirection = new Vector3(horizontal, 0, vertical).normalized;

        transform.Translate(moveDirection * Time.deltaTime * moveSpeed);
        transform.Rotate(new Vector3(0, mouseX, 0).normalized * lookSensitivity * Time.deltaTime);

        fp_camera.transform.Rotate(new Vector3(-mouseY, 0, 0).normalized * lookSensitivity * Time.deltaTime);
    }
}
