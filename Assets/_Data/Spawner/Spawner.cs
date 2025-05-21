using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Spawner : LiemMonoBehaviour
{   
    public virtual Transform Spawn(Transform prefab)
    {
        Transform newObject = Instantiate(prefab);
        return newObject;
    }
}
