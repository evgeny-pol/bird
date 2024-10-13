using System;
using UnityEngine;

[RequireComponent(typeof(PlayerShipCollisionHandler))]
public class PlayerShip : MonoBehaviour
{
    private PlayerShipCollisionHandler _collisionHandler;

    public event Action Destroyed;
    public event Action<ScoreArea> ScoreAreaVisited;

    private void Awake()
    {
        _collisionHandler = GetComponent<PlayerShipCollisionHandler>();
    }

    private void OnEnable()
    {
        _collisionHandler.ObstacleCollision += DestroySelf;
        _collisionHandler.ShipCollision += DestroySelf;
        _collisionHandler.ScoreAreaVisited += OnScoreAreaVisited;
        _collisionHandler.MissleCollision += OnMissleCollision;
    }

    private void OnDisable()
    {
        _collisionHandler.ObstacleCollision -= DestroySelf;
        _collisionHandler.ShipCollision -= DestroySelf;
        _collisionHandler.ScoreAreaVisited -= OnScoreAreaVisited;
        _collisionHandler.MissleCollision -= OnMissleCollision;
    }

    private void OnMissleCollision(Missle missle) => DestroySelf();

    private void DestroySelf()
    {
        Destroyed?.Invoke();
    }

    private void OnScoreAreaVisited(ScoreArea scoreArea)
    {
        ScoreAreaVisited?.Invoke(scoreArea);
    }
}
