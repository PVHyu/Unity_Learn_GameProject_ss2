using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
public class TowerTargeting : BaseMonoBehaviour
{
    [SerializeField] protected SphereCollider sphereCollider;
    [SerializeField] protected Rigidbody rigid;

    [SerializeField] protected EnemyCtrl nearest;
    public EnemyCtrl Nearest => nearest;
    [SerializeField] protected LayerMask obstacleLayerMask = -1;

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
        this.sphereCollider.radius = 10f;
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
        if (collider.name != Const.TOWER_TARGETTABLE) return;
        EnemyCtrl enemyCtrl = collider.transform.parent.GetComponent<EnemyCtrl>();

        if (enemyCtrl.EnemyDamageReceiver.IsDead()) return;

        this.enemies.Add(enemyCtrl);
    }


    protected virtual void RemoveEnemy(Collider collider)
    {
        if (collider.name != Const.TOWER_TARGETTABLE) return;

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
        foreach (EnemyCtrl enemyCtrl in this.enemies)
        {
            if (!this.CanSeeTarget(enemyCtrl.TowerTargetable.SphereCollider)) continue;

            enemyDistance = Vector3.Distance(transform.position, enemyCtrl.transform.position);
            if (enemyDistance < nearestDistance)
            {
                nearestDistance = enemyDistance;
                this.nearest = enemyCtrl;
            }
        }
    }

    protected virtual bool CanSeeTarget(Collider target)
    {
        Vector3 startPos = transform.position + Vector3.up * 1.0f;
        Vector3 targetPos = target.bounds.center;
        Vector3 directionToTarget = targetPos - startPos;
        float distanceToTarget = directionToTarget.magnitude;
        if (Physics.Raycast(startPos, directionToTarget, out RaycastHit hitInfo, distanceToTarget, obstacleLayerMask))
        {
            if (hitInfo.collider == target)
            {
                Debug.DrawRay(startPos, directionToTarget, Color.green);
                return true;
            }
            // Debug.Log("Raycast bị chặn bởi: " + hitInfo.collider.name, hitInfo.collider.gameObject);
            Debug.DrawRay(startPos, directionToTarget.normalized * hitInfo.distance, Color.red);
            return false;
        }
        Debug.DrawRay(startPos, directionToTarget, Color.green);
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