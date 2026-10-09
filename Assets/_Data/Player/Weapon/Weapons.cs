using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapons : BaseMonoBehaviour
{
    [SerializeField] protected List<WeaponAbstract> weapons = new();

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadWeapons();
    }

    protected virtual void LoadWeapons()
    {
        if (this.weapons.Count > 0) return;
        foreach (Transform child in transform)
        {
            WeaponAbstract weaponAbtract = child.GetComponent<WeaponAbstract>();
            if (weaponAbtract == null) continue;
            this.weapons.Add(weaponAbtract);
        }
        Debug.Log(transform.name + ": LoadWeapons", gameObject);
    }

    public virtual WeaponAbstract GetCurrentWeapon()
    {
        Debug.Log("GetPositionAttack: " + this.weapons[0].AttackPoint.transform.position, gameObject);

        return this.weapons[0];
    }
}