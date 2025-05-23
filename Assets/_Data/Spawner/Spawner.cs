using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner<T> : LiemMonoBehaviour where T : PoolObj
{
    [SerializeField] protected int spawnCount = 0;
    [SerializeField] protected List<T> inPoolObjs;

    public virtual Transform Spawn(Transform prefab)
    {
        Transform newObject = Instantiate(prefab);
        return newObject;
    }

    public virtual T Spawn(T prefab)
    {
        T newObj = this.GetObjectFromPool(prefab);
        if (newObj == null)
        {
            newObj = Instantiate(prefab);
            this.spawnCount++;
            this.UpdateName(prefab.transform, newObj.transform);
        }
        return newObj;
    }

    public virtual T Spawn(T prefab, Vector3 position)
    {
        T newBullet = this.Spawn(prefab);
        newBullet.transform.position = position;
        return newBullet;
    }


    public virtual void Despawn(Transform obj)
    {
        Destroy(obj.gameObject);
    }

    public virtual void Despawn(T obj)
    {
        if (obj is MonoBehaviour monoBehaviour)
        {
            monoBehaviour.gameObject.SetActive(false);
            this.AddObjectToPool(obj);
        }
    }

    protected virtual void AddObjectToPool(T obj)
    {
        this.inPoolObjs.Add(obj);
    }

    protected virtual void UpdateName(Transform prefab, Transform newObj)
    {
        newObj.name = prefab.name + "_" + this.spawnCount;
    }

    protected virtual T GetObjectFromPool(T prefab)
    {
        foreach(T inPoolObj in this.inPoolObjs)
        {
            if(prefab.GetName() == inPoolObj.GetName())
            {
                this.RemoveObjFromPool(inPoolObj);
                return inPoolObj;
            }
        }
        return null;
    }

    protected virtual void RemoveObjFromPool(T obj)
    {
        this.inPoolObjs.Remove(obj);
    }
}
