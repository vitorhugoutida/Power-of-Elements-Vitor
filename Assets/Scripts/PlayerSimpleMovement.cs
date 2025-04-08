using UnityEngine;

public class PlayerSimpleMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float mouseSensitivity = 100f;

    public Transform playerBody;
    public Transform playerCamera;

    float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked; // Isso trava o cursor no meio da tela
        Cursor.visible = false;
    }

    void Update()
    {
        // Movimento do mouse (câmera)
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        // Movimento do jogador
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 move = playerBody.forward * v + playerBody.right * h;
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);
    }
}
