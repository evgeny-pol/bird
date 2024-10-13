using System;
using UnityEngine;

public class PlayerShipCollisionHandler : ShipCollisionHandler
{
    public event Action ObstacleCollision;
    public event Action ShipCollision;
    public event Action<ScoreArea> ScoreAreaVisited;

    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        base.OnTriggerEnter2D(collision);

        if (collision.TryGetComponent(out Obstacle _))
            ObstacleCollision?.Invoke();
        else if (collision.TryGetComponent(out EnemyShip _))
            ShipCollision?.Invoke();
        else if (collision.TryGetComponent(out ScoreArea scoreArea))
            ScoreAreaVisited?.Invoke(scoreArea);
    }
}
