using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public abstract class DamageSender : LiemMonoBehaviour
{
    [SerializeField] protected int damage = 1;
    [SerializeField] protected new Rigidbody rigidbody;

    public virtual void OnTriggerEnter(Collider collider)
    {
        DamageReceiver damageReceiver = collider.GetComponent<DamageReceiver>();
        if (damageReceiver == null) return;
        this.Send(damageReceiver);
        Debug.Log("OnTriggerEnter: " + collider.name);

    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadRigidbody();
    }

    protected virtual void LoadRigidbody()
    {
        if (this.rigidbody != null) return;
        this.rigidbody = GetComponent<Rigidbody>();
        this.rigidbody.useGravity = false;
        Debug.LogWarning(transform.name + ": LoadRigidbody", gameObject);
    }

    protected virtual void Send(DamageReceiver damageReceiver)
    {
        damageReceiver.Deduct(this.damage);
    }
}
