using UnityEngine;

namespace Platformer2D
{
    public class PlayerVisual : MonoBehaviour
    {
        private const string _animatorDieTrigger = "Die";
        private const string _animatorMoveSpeedXFloat = "MoveSpeedX";
    
        private SpriteRenderer _renderer;
        private Animator _animator;

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _animator = GetComponent<Animator>();
        }

        public void SetMoveSpeedX(float moveSpeedX)
        {
            if (moveSpeedX < 0f)
            {
                _renderer.flipX = true;
                _animator.SetFloat(_animatorMoveSpeedXFloat, -moveSpeedX);
            }
            else
            {
                _renderer.flipX = false;
                _animator.SetFloat(_animatorMoveSpeedXFloat, moveSpeedX);
            }
        
        }

        public void Die()
        {
            _animator.SetTrigger(_animatorDieTrigger);
        }
    
    
    }
}

