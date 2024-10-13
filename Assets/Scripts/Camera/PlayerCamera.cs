using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PlayerCamera : MonoBehaviour
{
    [SerializeField] private PlayerShip _playerShip;
    [SerializeField, Min(0f)] private float _normalizedEdgeOffset = 0.1f;

    private Vector3 _edgeOffsetVector;
    private Camera _camera;

    private void Awake()
    {
        _camera = GetComponent<Camera>();
        _edgeOffsetVector = new Vector3(_normalizedEdgeOffset, 0, 0);
    }

    private void Update()
    {
        Vector3 expectedPlayerShipPosition = _camera.ViewportToWorldPoint(_edgeOffsetVector);
        Vector3 cameraPositionDiff = _playerShip.transform.position - expectedPlayerShipPosition;
        transform.Translate(cameraPositionDiff.x, 0, 0);
    }
}
