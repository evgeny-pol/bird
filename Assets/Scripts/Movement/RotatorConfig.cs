using UnityEngine;

[CreateAssetMenu(menuName = ScriptableObjectUtil.DefaultFolder + nameof(RotatorConfig))]
public class RotatorConfig : ScriptableObject
{
    [SerializeField] private float _minSpeed;
    [SerializeField] private float _maxSpeed;
    [SerializeField] private bool _randomizeInitialRotation;

    public float MinSpeed => _minSpeed;

    public float MaxSpeed => _maxSpeed;

    public bool RandomizeInitialRotation => _randomizeInitialRotation;

    private void OnValidate()
    {
        _minSpeed = Mathf.Min(_minSpeed, _maxSpeed);
    }
}
