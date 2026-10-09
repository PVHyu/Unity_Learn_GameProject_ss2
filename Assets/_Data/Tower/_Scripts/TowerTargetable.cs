using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(SphereCollider))]

public class TowerTargetable : BaseMonoBehaviour
{
    [SerializeField] protected SphereCollider sphereCollider;
    public SphereCollider SphereCollider => sphereCollider;
    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadSphereCollider();
    }

    protected virtual void LoadSphereCollider()
    {
        if(this.sphereCollider != null) return;
        this.sphereCollider = GetComponent<SphereCollider>();
        this.sphereCollider.radius = 1f;
        this.sphereCollider.isTrigger = true;
        this.sphereCollider.center = new Vector3(0, 1, 0);
        Debug.Log(transform.name + ": LoadSphereCollider", gameObject);
    }
}