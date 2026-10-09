using UnityEngine;

public class InputManager : SingletonPattern<InputManager>
{
    protected bool isAiming = false;

    protected float attackHold = 0;
    protected float attackLightLimit = 0.5f;
    protected bool isAttackLight = false;
    protected bool isAttackHeavy = false;

    private void Update()
    {
        this.CheckAiming();
        this.CheckAttacking();
    }

    protected virtual void CheckAiming()
    {
        // this.isAiming = Input.GetMouseButton(1);
        this.isAiming = Input.GetKey(KeyCode.Z);
    }

    protected virtual void CheckAttacking()
    {
        if (!this.IsAiming())
        {
            this.isAttackHeavy = false;
            this.isAttackLight = false;
            return;
        }

        if (Input.GetMouseButton(0) || Input.GetKey(KeyCode.X)) this.attackHold += Time.deltaTime;

        if (Input.GetMouseButtonUp(0) ||  Input.GetKeyUp(KeyCode.X))
        {
            this.isAttackLight = this.attackHold < this.attackLightLimit;
            this.attackHold = 0;
        }
        else
        {
            this.isAttackLight = false;
        }

        if (this.attackHold > this.attackLightLimit) this.isAttackHeavy = true;
        else this.isAttackHeavy = false;
    }

    public virtual bool IsAttackLight()
    {
        return this.isAttackLight;
    }

    public virtual bool IsAttackHeavy()
    {
        return this.isAttackHeavy;
    }

    public virtual bool IsAiming()
    {
        return this.isAiming;
    }
}