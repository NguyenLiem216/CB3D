using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletCtrl : LiemMonoBehaviour
{
    [SerializeField] protected Bullet bullet;
    public Bullet Bullet => bullet;


    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadBullet();
    }
    protected virtual void LoadBullet()
    {
        if (this.bullet != null) return;
        this.bullet = GetComponent<Bullet>();
        Debug.LogWarning(transform.name + ": LoadBullet", gameObject);
    }
}
