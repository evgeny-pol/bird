using UnityEngine;

[CreateAssetMenu(menuName = ScriptableObjectUtil.DefaultFolder + nameof(EnemyShipConfig))]
public class EnemyShipConfig : ScriptableObject
{
    [SerializeField, Min(0f)] private float _minShootDelay = 2f;
    [SerializeField, Min(0f)] private float _maxShootDelay = 5f;
    [SerializeField, Min(0)] private int _scoreValue = 5;

    public float MinShootDelay => _minShootDelay;

    public float MaxShootDelay => _maxShootDelay;

    public int ScoreValue => _scoreValue;

    private void OnValidate()
    {
        _minShootDelay = Mathf.Min(_minShootDelay, _maxShootDelay);
    }
}
