using UnityEngine;

public class WASD : MonoBehaviour
{
    public float speed = 10f;
    public Rigidbody2D myth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        Vector2 velocity = Vector2.zero;

        if{Input.GetKey(KeyCode.W)}
        {
            velocity.y = speed;
        }
        if{ Input.GetKey(KeyCode.S)}
        {
            velocity.y = speed;
        }
        if{ Input.GetKey(KeyCode.D)}
        {
            velocity.x = speed;
        }
        if{ Input.GetKey(KeyCode.A)}
        {
            velocity.x = speed;
        }

    }
}
