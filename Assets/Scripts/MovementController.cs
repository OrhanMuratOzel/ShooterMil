using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] Transform puppetPlayer;
     Rigidbody rb;

    private float xRotation;
    private float sensitivity = 50f;
    private float sensMultiplier = 1f;

    [SerializeField] float moveSpeed = 4500;
    [SerializeField] float maxSlopeAngle = 35f;

    void Awake() => rb = GetComponent<Rigidbody>();

    #region Updates
    private void FixedUpdate()
    {
        Movement();
    }
    private void Update()
    {
        Look();
    }
    #endregion

    #region Camera Rot,Mov Functions
    float desiredX;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    private void Look()
    {
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.fixedDeltaTime * sensMultiplier;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.fixedDeltaTime * sensMultiplier;

        Vector3 rot = puppetPlayer.transform.localRotation.eulerAngles;
        desiredX = rot.y + mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        puppetPlayer.transform.localRotation = Quaternion.Euler(xRotation, desiredX, 0);
    }
    #endregion

    #region Movement Function
    private void Movement()
    {
        float multiplier = 1f, multiplierV = 1f;
        rb.AddForce(puppetPlayer.forward * InputController.instance.GetYAxisRaw() * moveSpeed * Time.deltaTime * multiplier * multiplierV);
        rb.AddForce(puppetPlayer.right * InputController.instance.GetXAxisRaw() * moveSpeed * Time.deltaTime * multiplier);
    }
    #endregion
}

