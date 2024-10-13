using UnityEngine;

public class BackgroundImage : MonoBehaviour
{
    [SerializeField, Min(0f)] private float _moveSpeed;
    [SerializeField] private Transform _loopStart;
    [SerializeField] private Transform _loopEnd;

    private Vector2 _movementDirection;
    private Vector3 _loop;
    private float _loopDistance;
    private float _loopMoved;

    private void Awake()
    {
        _loop = _loopEnd.position - _loopStart.position;
        _movementDirection = -_loop.normalized;
        _loopDistance = _loop.magnitude;
    }

    private void Update()
    {
        float movementDistance = _moveSpeed * Time.deltaTime;
        transform.Translate(_movementDirection * movementDistance);
        _loopMoved += movementDistance;

        if (_loopMoved > _loopDistance)
        {
            transform.Translate(_loop);
            _loopMoved -= _loopDistance;
        }
    }
}
