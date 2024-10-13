using UnityEngine;

[CreateAssetMenu(menuName = ScriptableObjectUtil.DefaultFolder + nameof(MoverConfig))]
public class MoverConfig : ScriptableObject
{
    [SerializeField] private Vector3 _moveSpeed;
    [SerializeField] private Space _relativeTo = Space.World;

    public Vector3 MoveSpeed => _moveSpeed;

    public Space RelativeTo => _relativeTo;
}
