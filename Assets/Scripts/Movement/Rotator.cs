using UnityEngine;

public class Rotator : MonoBehaviour
{
    [SerializeField] private RotatorConfig _rotatorConfig;

    private float _rotationSpeed;

    private void Awake()
    {
        _rotationSpeed = Random.Range(_rotatorConfig.MinSpeed, _rotatorConfig.MaxSpeed);
    }

    private void Start()
    {
        if (_rotatorConfig.RandomizeInitialRotation)
            transform.Rotate(Vector3.forward, Random.value * Mathf.PI * 2 * Mathf.Rad2Deg);
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward, _rotationSpeed * Time.deltaTime);
    }
}
