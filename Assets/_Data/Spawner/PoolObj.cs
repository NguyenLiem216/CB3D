using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PoolObj : LiemMonoBehaviour
{
    [SerializeField] protected DespawnBase despawnBase;
    public DespawnBase DespawnBase => despawnBase;

    public abstract string GetName();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadDespawnBase();
    }
    protected virtual void LoadDespawnBase()
    {
        if (this.despawnBase != null) return;
        this.despawnBase = transform.GetComponentInChildren<DespawnBase>();
        Debug.LogWarning(transform.name + ": LoadDespawnBase", gameObject);
    }
}
