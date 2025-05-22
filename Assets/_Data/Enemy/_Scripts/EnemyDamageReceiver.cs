using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CapsuleCollider))]
public class EnemyDamageReceiver : DamageReceiver
{
    [SerializeField] protected CapsuleCollider capsuleCollider;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadCapsuleCollider();
    }

    protected virtual void LoadCapsuleCollider()
    {
        if (this.capsuleCollider != null) return;
        this.capsuleCollider = GetComponent<CapsuleCollider>();
        this.capsuleCollider.isTrigger = true;
        this.capsuleCollider.center = new Vector3(0f, 1f, 0f);
        this.capsuleCollider.radius = 0.3f;
        this.capsuleCollider.height = 1.5f;
        Debug.LogWarning(transform.name + ": LoadCapsuleCollider", gameObject);
    }
}
