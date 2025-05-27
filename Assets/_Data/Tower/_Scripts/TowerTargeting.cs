using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class TowerTargeting : LiemMonoBehaviour
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody rigid;

    [SerializeField] protected EnemyCtrl nearest;
    public EnemyCtrl Nearest => nearest;
    [SerializeField] protected LayerMask obstacleLayerMask;

    [SerializeField] protected List<EnemyCtrl> enemies = new();

    protected virtual void FixedUpdate()
    {
        this.FindNearest();
        this.RemoveDeadEnemy();
    }

    protected virtual void OnTriggerEnter(Collider collider)
    {
        this.AddEnemy(collider);
    }

    protected virtual void OnTriggerExit(Collider collider)
    {
        this.RemoveEnemy(collider);
    }

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
        this.LoadRigidbody();
    }

    protected virtual void LoadSphereCollider()
    {
        if (this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.radius = 15f;
        this.sphereCollider.isTrigger = true;
        Debug.Log(transform.name + ": LoadSphereCollider", gameObject);
    }

    protected virtual void LoadRigidbody()
    {
        if (this.rigid != null) return;
        this.rigid = GetComponent<Rigidbody>();
        this.rigid.useGravity = false;
        Debug.Log(transform.name + ": LoadRigidbody", gameObject);
    }

    protected virtual void AddEnemy(Collider collider)
    {
        if (collider.name != Const.TOWER_TARGETABLE) return;
        EnemyCtrl enemyCtrl = collider.transform.parent.GetComponent<EnemyCtrl>();

        if (enemyCtrl.EnemyDamageReceiver.IsDead()) return;

        this.enemies.Add(enemyCtrl);
    }


    protected virtual void RemoveEnemy(Collider collider)
    {
        foreach (EnemyCtrl enemyCtrl in this.enemies)
        {
            if (collider.transform.parent.name == enemyCtrl.name)
            {
                if (enemyCtrl == this.nearest) this.nearest = null;

                this.enemies.Remove(enemyCtrl);
                return;
            }
        }
    }

    protected virtual void FindNearest()
    {
        float nearestDistance = Mathf.Infinity;
        float enemyDistance;
        this.nearest = null;

        foreach (EnemyCtrl enemyCtrl in this.enemies)
        {
            if (!this.CanSeeTarget(enemyCtrl)) continue;

            enemyDistance = Vector3.Distance(transform.position, enemyCtrl.transform.position);
            if (enemyDistance < nearestDistance)
            {
                nearestDistance = enemyDistance;
                this.nearest = enemyCtrl;
            }
        }
    }


    protected virtual bool CanSeeTarget(EnemyCtrl target)
    {
        Vector3 origin = transform.position + Vector3.up * 1f;
        Vector3 targetPos = target.transform.position + Vector3.up * 1f;
        Vector3 directionToTarget = targetPos - origin;
        float distanceToTarget = directionToTarget.magnitude;

        if (Physics.SphereCast(origin, 0.3f, directionToTarget.normalized, out RaycastHit hitInfo, distanceToTarget, obstacleLayerMask))
        {
            Vector3 directionToCollider = hitInfo.point - origin;
            float distanceToCollider = directionToCollider.magnitude;
            //Debug.Log("Raycast hit: " + hitInfo.collider.name + " on layer: " + LayerMask.LayerToName(hitInfo.collider.gameObject.layer));
            Debug.DrawRay(origin, directionToCollider.normalized * distanceToCollider, Color.red);
            return false;
        }

        Debug.DrawRay(origin, directionToTarget.normalized * distanceToTarget, Color.green);
        return true;
    }

    protected virtual void RemoveDeadEnemy()
    {
        foreach (EnemyCtrl enemyCtrl in this.enemies)
        {
            if (enemyCtrl.EnemyDamageReceiver.IsDead())
            {
                if (enemyCtrl == this.nearest) this.nearest = null;
                this.enemies.Remove(enemyCtrl);
                return;
            }
        }
    }
}
