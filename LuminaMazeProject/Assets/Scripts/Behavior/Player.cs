using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Rigidbody playerRig;
    [SerializeField] private GameObject cameraObj;

    public float moveSpeed = 5.0f;
    public Vector2 mouseSensivity = new Vector2(1.0f, 1.0f);

    private void Update()
    {
        Rotate();
        Move();
    }

    private void Rotate()
    {
        float x = Input.GetAxisRaw("Mouse X") * mouseSensivity.x * Time.deltaTime * 180.0f;
        float y = Input.GetAxisRaw("Mouse Y") * mouseSensivity.y * Time.deltaTime * 180.0f;
        Quaternion q = Quaternion.AngleAxis(x, Vector3.up);
        Vector3 camAng = cameraObj.transform.localEulerAngles;

        camAng -= Vector3.right * y;
        if (camAng.x > 180 && camAng.x <= 275) camAng.x = 275;
        if (camAng.x < 180 && camAng.x >= 85) camAng.x = 85;

        playerRig.MoveRotation(gameObject.transform.rotation * q);
        cameraObj.transform.localEulerAngles = camAng;
    }

    private void Move()
    {
        Vector3 move = transform.forward * Input.GetAxisRaw("Vertical") + transform.right * Input.GetAxisRaw("Horizontal");
        move.Normalize();
        move *= moveSpeed * Time.deltaTime;
        playerRig.velocity = move;
    }
}
