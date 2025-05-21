using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletSpawner : Spawner
{
    public virtual Bullet Spawn(Bullet bulletPrefab)
    {
        Bullet newObj = Instantiate(bulletPrefab);
        return newObj;
    }

    public virtual Bullet Spawn(Bullet bulletPrefab, Vector3 position)
    {
        Bullet newBullet = this.Spawn(bulletPrefab);
        newBullet.transform.position = position;
        return newBullet;
    }

}
