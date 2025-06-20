﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerShooting : TowerAbstract
{
    [SerializeField] protected int currentFirePoint = 0;
    [SerializeField] protected float targetLoadSpeed = 1f;
    [SerializeField] protected float shootSpeed = 2f;
    [SerializeField] protected float rotateSpeed = 2f;
    [SerializeField] protected EnemyCtrl target;
    [SerializeField] protected Bullet bullet;

    protected override void Start()
    {
        base.Start();
        Invoke(nameof(this.TargetLoading), this.targetLoadSpeed);
        Invoke(nameof(this.Shooting), this.shootSpeed);
    }

    protected virtual void FixedUpdate()
    {
        this.Looking();
    }

    protected virtual void Looking()
    {
        if (this.target == null) return;
        Vector3 directionToTarget = this.target.TowerTargetable.transform.position - this.towerCtrl.Rotator.position;
        directionToTarget.y = 0;
        Vector3 newDirection = Vector3.RotateTowards(
            this.towerCtrl.Rotator.forward,
            directionToTarget,
            rotateSpeed * Time.fixedDeltaTime,
            0f
        );
        this.towerCtrl.Rotator.rotation = Quaternion.LookRotation(newDirection);



        //this.towerCtrl.Rotator.LookAt(this.target.TowerTargetable.transform.position);
    }

    protected virtual void TargetLoading()
    {
        Invoke(nameof(this.TargetLoading), this.targetLoadSpeed);

        this.target = this.towerCtrl.TowerTargeting.Nearest;
    }
    protected virtual void Shooting()
    {
        Invoke(nameof(this.Shooting), this.shootSpeed);
        if (this.target == null) return;


        FirePoint firePoint = this.GetFirePoint();
        Bullet newBullet = this.towerCtrl.BulletSpawner.Spawn(this.towerCtrl.Bullet,firePoint.transform.position);
        Vector3 rotatorDirection = this.towerCtrl.Rotator.transform.forward;
        newBullet.transform.forward = rotatorDirection;
        newBullet.gameObject.SetActive(true);
    }

    protected virtual FirePoint GetFirePoint()
    {
        FirePoint firePoint = this.towerCtrl.FirePoints[this.currentFirePoint];

        this.currentFirePoint++;
        if (this.currentFirePoint == this.towerCtrl.FirePoints.Count) this.currentFirePoint = 0;

        return firePoint;
    }
}
