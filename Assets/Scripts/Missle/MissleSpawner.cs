using UnityEngine;

public class MissleSpawner : Spawner<Missle>
{
    public void SpawnMissle(Vector3 position, Quaternion rotation)
    {
        Missle missle = Spawn();
        missle.transform.SetPositionAndRotation(position, rotation);
    }
}
