using UnityEngine;

namespace Platformer2D
{
    public class Coin : MonoBehaviour
    {

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.TryGetComponent<Player>(out var player))
            {
                Collected();
            }
        }

        private void Collected()
        {
            Destroy(gameObject);
        }
    }

}
