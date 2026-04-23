using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Movement : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private float _moveSpeed = 3f;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        _rigidBody.linearVelocity = GetDirection() * _moveSpeed;
        
    }

    private Vector2 GetDirection()
    {
        int x = 0;
        int y = 0;
        if (Input.GetKey(KeyCode.A))
        {
            x = -1;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            x = 1;
        }

        if (Input.GetKey(KeyCode.W))
        {
            y = 1;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            y = -1;
        }
        Vector2 direction = new Vector2(x, y).normalized;
        return direction;
    }
}
