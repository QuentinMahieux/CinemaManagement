using UnityEngine;

public class FirstPersonCamera : MonoBehaviour //Se script doit être placer sur la camera du Player
{
    [Tooltip("Ratacher la camera au player")]
    public Transform player;
    public float mouseSensitivity = 2;
    private float cameraVerticalRotation = 0f;

    [Header("Cursor Settings")] 
    public bool isVisibleCursor;
    
    
    void Start()
    {
        Cursor.visible = isVisibleCursor;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        float inputX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float inputY = Input.GetAxis("Mouse Y") * mouseSensitivity;
        
        cameraVerticalRotation -= inputY;
        cameraVerticalRotation = Mathf.Clamp(cameraVerticalRotation, -90f, 90f);
        transform.localEulerAngles = Vector3.right * cameraVerticalRotation;
        
        player.Rotate(Vector3.up * inputX);
    }
}