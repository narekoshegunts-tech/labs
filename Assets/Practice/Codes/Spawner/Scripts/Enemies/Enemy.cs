using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Enemy : MonoBehaviour
{
    private Rigidbody2D _rigidBody;
    private EnemyVisual _visual;
    
    private float _moveSpeed = 1f;

    private void Awake()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _visual = GetComponentInChildren<EnemyVisual>();
    }
    
    public void SetDirection(Vector2 direction)
    {
        _rigidBody.linearVelocity = direction.normalized * _moveSpeed;

        if (direction.x < 0) 
            if (_visual)
                _visual.FlipX();
        
    }
    
}
