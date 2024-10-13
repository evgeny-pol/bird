using UnityEngine;

public class GameCycle : MonoBehaviour
{
    [SerializeField] private PlayerShip _playerShip;
    [SerializeField] private PlayerShipMover _playerMover;
    [SerializeField] private PlayerMissleShooter _playerMissleShooter;
    [SerializeField] private EnemyShipSpawner _enemyShipSpawner;
    [SerializeField] private MissleSpawner _enemyMissleSpawner;
    [SerializeField] private ScoreCounter _scoreCounter;
    [SerializeField] private Button _startGameButton;
    [SerializeField] private GameObject _gameOverPanel;

    private void OnEnable()
    {
        _playerShip.Destroyed += OnPlayerShipDestroyed;
        _startGameButton.Clicked += OnGameStarted;
    }

    private void OnDisable()
    {
        _playerShip.Destroyed -= OnPlayerShipDestroyed;
        _startGameButton.Clicked -= OnGameStarted;
    }

    private void OnPlayerShipDestroyed()
    {
        Time.timeScale = 0;
        _playerMover.enabled = false;
        _playerMissleShooter.enabled = false;
        _gameOverPanel.SetActive(true);
        _startGameButton.gameObject.SetActive(true);
    }

    private void OnGameStarted()
    {
        Time.timeScale = 1;
        _gameOverPanel.SetActive(false);
        _scoreCounter.ResetScore();
        _playerMover.ResetMover();
        _playerMissleShooter.DeactivateActiveObjects();
        _playerMissleShooter.enabled = true;
        _enemyMissleSpawner.DeactivateActiveObjects();
        _enemyShipSpawner.DeactivateActiveObjects();
        _enemyShipSpawner.enabled = true;
        _startGameButton.gameObject.SetActive(false);
    }
}
