using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [Range(50,500)]
    public float sens;
    public Transform body;
    float xRot = 0f;
    public Transform leaner;
    public float zRot;
    bool isRotating;
    public PlayerController playerscript;
    private void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }
    private void Update()
    {
        #region camera
        float rotX = Input.GetAxisRaw("Mouse X") * sens * Time.deltaTime;
        float rotY = Input.GetAxisRaw("Mouse Y") * sens * Time.deltaTime;
        xRot -= rotY;
        xRot = Mathf.Clamp(xRot, -80f, 80f);
        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        body.Rotate(Vector3.up * rotX);
        #endregion
        #region camera lean
        if (Input.GetKey(KeyCode.E))
        {
            isRotating = true;
            zRot = Mathf.Lerp(zRot, -20.0f, 5f * Time.deltaTime);
            playerscript.canMove = false;
        }

        if (Input.GetKey(KeyCode.Q))
        {
            playerscript.canMove = false;
            isRotating = true;
            zRot = Mathf.Lerp(zRot, 20.0f, 5f * Time.deltaTime);
        }
        if(Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.E))
        {
            isRotating = false;
            playerscript.canMove = true;
        }
        if(!isRotating)
            zRot = Mathf.Lerp(zRot, 0.0f, 5f * Time.deltaTime);

       
        leaner.localRotation = Quaternion.Euler(0, 0, zRot);
        #endregion
    }
}
