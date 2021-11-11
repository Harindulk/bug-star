using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed = 6f;

    public float movementMultipiler = 10f;
    float rbDrag = 6f;

    float horizontalMovement;
    float verticalMovement;

    Vector3 moveDirection;

    Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        myInput();
        controlDrag();
    }

    void myInput()
    {
        horizontalMovement = Input.GetAxisRaw("Horizontal");
        verticalMovement = Input.GetAxisRaw("Vertical");

        moveDirection = transform.forward * verticalMovement + transform.right * horizontalMovement;
    }

    void controlDrag()
    {
        rb.drag = rbDrag;
    }

    private void FixedUpdate()
    {
        movePlayer();
    }
    void movePlayer()
    {
        rb.AddForce(moveDirection.normalized * moveSpeed * movementMultipiler, ForceMode.Acceleration);
    }

}
