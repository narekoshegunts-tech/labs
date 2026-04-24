using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class EnemyVisual : MonoBehaviour
{
    SpriteRenderer _renderer;

    private void Awake()
    {
        _renderer = GetComponent<SpriteRenderer>();
    }

    public void FlipX()
    {
        _renderer.flipX = !_renderer.flipX;
    }
}
