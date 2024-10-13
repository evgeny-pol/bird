using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(ShipCollisionHandler))]
public class EnemyShip : PoolableObject
{
    [SerializeField] private EnemyShipConfig _shipConfig;
    [SerializeField] private Transform _missleSpawnPoint;

    private MissleSpawner _missleSpawner;
    private Coroutine _shootCoroutine;
    private ShipCollisionHandler _collisionHandler;

    public event Action<EnemyShip> Destroyed;

    public int ScoreValue => _shipConfig.ScoreValue;

    private void Awake()
    {
        _collisionHandler = GetComponent<ShipCollisionHandler>();
    }

    private void OnEnable()
    {
        _collisionHandler.MissleCollision += OnMissleCollision;
        _collisionHandler.LeftGameArea += Deactivate;
    }

    private void OnDisable()
    {
        _collisionHandler.MissleCollision -= OnMissleCollision;
        _collisionHandler.LeftGameArea -= Deactivate;
    }

    public void Initialize(MissleSpawner missleSpawner)
    {
        _missleSpawner = missleSpawner;
    }

    public override void Spawned()
    {
        base.Spawned();
        _shootCoroutine = StartCoroutine(Shoot());
    }

    public override void Deactivate()
    {
        if (_shootCoroutine != null)
            StopCoroutine(_shootCoroutine);

        base.Deactivate();
    }

    public void OnMissleCollision(Missle missle)
    {
        missle.Deactivate();
        Destroyed?.Invoke(this);
        Deactivate();
    }

    private IEnumerator Shoot()
    {
        yield return new WaitForSeconds(Random.Range(_shipConfig.MinShootDelay, _shipConfig.MaxShootDelay));
        _missleSpawner.SpawnMissle(_missleSpawnPoint.position, _missleSpawnPoint.rotation);
    }
}
