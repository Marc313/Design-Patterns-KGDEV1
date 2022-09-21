using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float camSmoothing;
    public float sensitivityX;
    public Vector3 Offset;
    public Transform EnemyLockOn;

    private float rotationY;
    private Transform Player;
    public Quaternion targetLookRotation { get; private set; }

    // Start is called before the first frame update
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Player = FindObjectOfType<PlayerMovement>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        MoveToPlayer();
        RotateCameraAlongMouse();
    }

    private void MoveToPlayer()
    {
        // Move the camera along with the player
        transform.position = Player.position + Offset;
    }

    public void RotateCameraAlongMouse()
    {
        // Input on the mouse X axis
        float mouseX = Input.GetAxis("Mouse X");
        rotationY += mouseX * sensitivityX * Time.deltaTime;

        transform.localRotation = Quaternion.Euler(transform.rotation.x, rotationY, transform.rotation.z);
    }
}
