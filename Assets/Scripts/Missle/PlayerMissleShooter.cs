using UnityEngine;

public class PlayerMissleShooter : MissleSpawner
{
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private TimeInterval _shootCooldown;

    private void Update()
    {
        if (Input.GetButtonDown(InputAxis.Fire1) && _shootCooldown.IsEnded)
        {
            Missle missle = Spawn();
            missle.transform.SetPositionAndRotation(_spawnPoint.position, _spawnPoint.rotation);
            _shootCooldown.Start();
        }
    }
}
