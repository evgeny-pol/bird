using System;
using UnityEngine;

public class ScoreCounter : MonoBehaviour
{
    [SerializeField] private PlayerShip _playerShip;
    [SerializeField] private EnemyShipSpawner _enemyShipSpawner;

    private int _score;

    public event Action ScoreChanged;

    public int Score => _score;

    private void OnEnable()
    {
        _playerShip.ScoreAreaVisited += OnScoreAreaVisited;
        _enemyShipSpawner.ShipDestroyed += OnEnemyShipDestroyed;
    }

    private void OnDisable()
    {
        _playerShip.ScoreAreaVisited -= OnScoreAreaVisited;
        _enemyShipSpawner.ShipDestroyed -= OnEnemyShipDestroyed;
    }

    public void ResetScore() => SetScore(0);

    private void OnScoreAreaVisited(ScoreArea scoreArea) => AddScore(scoreArea.Value);

    private void OnEnemyShipDestroyed(EnemyShip ship) => AddScore(ship.ScoreValue);

    private void AddScore(int score) => SetScore(_score + score);

    private void SetScore(int score)
    {
        _score = score;
        ScoreChanged?.Invoke();
    }
}
