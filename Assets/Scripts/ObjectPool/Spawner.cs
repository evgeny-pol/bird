using System.Collections.Generic;
using UnityEngine;

public class Spawner<T> : MonoBehaviour where T : PoolableObject
{
    [SerializeField] private T _objectToSpawn;

    private readonly List<T> _activeObjects = new();
    private readonly Stack<T> _inactiveObjects = new();

    protected virtual void Awake()
    {
    }

    public void DeactivateActiveObjects()
    {
        while (_activeObjects.Count > 0)
            _activeObjects[0].Deactivate();
    }

    protected T Spawn()
    {
        T obj = _inactiveObjects.Count == 0 ? CreateNew() : _inactiveObjects.Pop();
        ActionOnGet(obj);
        obj.Spawned();
        _activeObjects.Add(obj);
        return obj;
    }

    protected virtual void ActionOnGet(T obj)
    {
        obj.Deactivated += OnObjectDeactivated;
        obj.ResetInternalState();
        obj.gameObject.SetActive(true);
    }

    protected virtual T CreateNew() => Instantiate(_objectToSpawn);

    private void OnObjectDeactivated(PoolableObject poolableObject)
    {
        T obj = poolableObject as T;
        poolableObject.Deactivated -= OnObjectDeactivated;
        OnObjectDeactivated(obj);
        _activeObjects.Remove(obj);
        _inactiveObjects.Push(obj);
        poolableObject.gameObject.SetActive(false);
    }

    protected virtual void OnObjectDeactivated(T obj)
    {
    }
}
