using UnityEngine;

public class Missle : PoolableObject
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Obstacle _))
            Deactivate();
    }
}
