using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    private float movementSpeed = 5;

    void Awake()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate() 
    {
        rigidbody2D.linearVelocity = new Vector2(Input.GetAxis("Horizontal") * movementSpeed, rigidbody2D.linearVelocity.y);
    }
}
