using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerShipMover : MonoBehaviour
{
    [SerializeField, Min(0f)] private float _jumpForce = 1f;
    [SerializeField, Min(0f)] private float _gravityScale = 1f;
    [SerializeField, Min(0f)] private float _rotationRange = 60f;
    [SerializeField, Min(0f)] private float _rotationSpeed = 1f;

    private Quaternion _minRotation;
    private Quaternion _maxRotation;
    private Rigidbody2D _rigidbody;
    private Vector3 _initialPosition;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _minRotation = Quaternion.Euler(0, 0, -_rotationRange / 2);
        _maxRotation = Quaternion.Euler(0, 0, _rotationRange / 2);
        _initialPosition = transform.position;
    }

    private void Update()
    {
        if (Input.GetButtonDown(InputAxis.Jump))
        {
            _rigidbody.velocity = new Vector2(0, _jumpForce);
            transform.rotation = _maxRotation;
        }

        transform.rotation = Quaternion.Lerp(transform.rotation, _minRotation, _rotationSpeed * Time.deltaTime);
    }

    public void ResetMover()
    {
        transform.SetPositionAndRotation(_initialPosition, Quaternion.identity);
        _rigidbody.gravityScale = _gravityScale;
        _rigidbody.velocity = Vector2.zero;
        enabled = true;
    }
}
