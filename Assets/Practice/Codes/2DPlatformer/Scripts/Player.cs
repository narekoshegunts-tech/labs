using UnityEngine;

namespace Platformer2D
{
    public class Player : MonoBehaviour
    {
        private Rigidbody2D _rigidbody;
        private PlayerVisual _visual;

        private readonly float _moveSpeed = 3f;
        private readonly float _jumpForce = 7f;

        private int _currentHealth = 1;

        public bool IsDead { get; private set; }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _visual = GetComponentInChildren<PlayerVisual>();
        }

        private void Update()
        {
            HandleMovement();
        }

        private void HandleMovement()
        {
            if (IsDead) return;
            _rigidbody.linearVelocity = new Vector2(0, _rigidbody.linearVelocity.y);
            if (Input.GetKey(KeyCode.A))
            {
                _rigidbody.linearVelocity = new Vector2(-_moveSpeed, _rigidbody.linearVelocity.y);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                _rigidbody.linearVelocity = new Vector2(_moveSpeed, _rigidbody.linearVelocity.y);
            }

            if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space))
                if (_rigidbody.linearVelocity.y == 0)
                    _rigidbody.linearVelocity = new Vector2(_rigidbody.linearVelocity.x, _jumpForce);
        
            _visual.SetMoveSpeedX(_rigidbody.linearVelocity.x);
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.TryGetComponent<Enemy>(out var enemy))
            {
                TakeDamage();
            }
        }


        private void TakeDamage()
        {
            _currentHealth--;
            if (_currentHealth <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            _visual.Die();
            IsDead = true;
        }
        
    
    
    }
    
}

