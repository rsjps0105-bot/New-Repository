using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Transform playerBody;
    [SerializeField] float mouseSensitivity = 100f;
    private float xRotation = 0f;

    void Update()
    {
        if (Time.timeScale == 0f) return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime; // Time.deltaTime 1ƒtƒŒ[ƒ€‚É‚©‚©‚Á‚½•b”
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // ã‰º‚X‚O“x‚Ì”ÍˆÍ
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);
    }
}