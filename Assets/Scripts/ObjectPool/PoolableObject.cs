using System;
using UnityEngine;

[DisallowMultipleComponent]
public abstract class PoolableObject : MonoBehaviour
{
    public event Action<PoolableObject> Deactivated;

    public virtual void Deactivate()
    {
        Deactivated?.Invoke(this);
    }

    public virtual void ResetInternalState()
    {
        foreach (IResetableComponent resetableComponent in GetComponents<IResetableComponent>())
            resetableComponent.ResetComponentState();
    }

    public virtual void Spawned()
    {
    }
}
