using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class GameArea : MonoBehaviour
{
    private BoxCollider2D _areaCollider;
    private Vector3 _obstacleLoop;

    private void Awake()
    {
        _areaCollider = GetComponent<BoxCollider2D>();
        _obstacleLoop = new Vector3(_areaCollider.size.x, 0, 0);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Obstacle _))
            collision.transform.position += _obstacleLoop;
        else if (collision.TryGetComponent(out Missle missle))
            missle.Deactivate();
    }
}
