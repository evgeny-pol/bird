using System;
using UnityEngine;

public class ShipCollisionHandler : MonoBehaviour
{
    public event Action<Missle> MissleCollision;
    public event Action LeftGameArea;

    protected virtual void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Missle missle))
            MissleCollision?.Invoke(missle);
    }

    protected virtual void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out GameArea _))
            LeftGameArea?.Invoke();
    }
}
