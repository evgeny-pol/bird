using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] private MoverConfig _moverConfig;

    private void Update()
    {
        transform.Translate(_moverConfig.MoveSpeed * Time.deltaTime, _moverConfig.RelativeTo);
    }
}
