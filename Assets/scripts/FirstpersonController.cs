using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class FirstpersonController : MonoBehaviour
{
    public float moveSpeed = 3.0f;
    public float mouseSensitivity = 2.0f;
    public Transform playerCamera;
    public AudioSource walkAudioSource;

    private float verticalLookRotation;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        if (walkAudioSource != null)
        {
            walkAudioSource.loop = true;
            walkAudioSource.playOnAwake = false;
        }
        else
        {
            Debug.LogWarning("No walking AudioSource assigned!");
        }

        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        transform.Rotate(0, mouseX, 0);
        verticalLookRotation -= mouseY;
        verticalLookRotation = Mathf.Clamp(verticalLookRotation, -90, 90);
        playerCamera.localEulerAngles = new Vector3(verticalLookRotation, 0, 0);

        
        float moveForward = Input.GetAxisRaw("Vertical");
        float moveSide = Input.GetAxisRaw("Horizontal");

        Vector3 move = transform.forward * moveForward + transform.right * moveSide;
        controller.Move(move * moveSpeed * Time.deltaTime);

        
        bool isMoving = Mathf.Abs(moveForward) > 0.1f || Mathf.Abs(moveSide) > 0.1f;

        if (isMoving)
        {
            if (walkAudioSource != null && !walkAudioSource.isPlaying)
                walkAudioSource.Play();
        }
        else
        {
            if (walkAudioSource != null && walkAudioSource.isPlaying)
                walkAudioSource.Stop();
        }
    }
}
