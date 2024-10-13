using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(MissleSpawner))]
public class EnemyShipSpawner : Spawner<EnemyShip>
{
    [SerializeField, Min(0.01f)] private float _spawnAreaHeight = 1f;
    [SerializeField, Min(0f)] private float _spawnInterval = 1f;

    private Coroutine _spawnCoroutine;
    private WaitForSeconds _spawnDelay;
    private float _spawnAreaHalfHeight;
    private MissleSpawner _missleSpawner;

    public event Action<EnemyShip> ShipDestroyed;

    protected override void Awake()
    {
        base.Awake();
        _missleSpawner = GetComponent<MissleSpawner>();
        _spawnDelay = new WaitForSeconds(_spawnInterval);
        _spawnAreaHalfHeight = _spawnAreaHeight / 2;
    }

    private void OnEnable()
    {
        _spawnCoroutine = StartCoroutine(SpawnShips());
    }

    private void OnDisable()
    {
        StopCoroutine(_spawnCoroutine);
    }

    protected override void ActionOnGet(EnemyShip ship)
    {
        base.ActionOnGet(ship);
        ship.transform.position = new Vector3(transform.position.x, Random.Range(-_spawnAreaHalfHeight, _spawnAreaHalfHeight));
        ship.Destroyed += OnShipDestroyed;
    }

    protected override void OnObjectDeactivated(EnemyShip ship)
    {
        ship.Destroyed -= OnShipDestroyed;
        base.OnObjectDeactivated(ship);
    }

    protected override EnemyShip CreateNew()
    {
        EnemyShip newShip = base.CreateNew();
        newShip.Initialize(_missleSpawner);
        return newShip;
    }

    private IEnumerator SpawnShips()
    {
        while (enabled)
        {
            Spawn();
            yield return _spawnDelay;
        }
    }

    private void OnShipDestroyed(EnemyShip ship) => ShipDestroyed?.Invoke(ship);
}
