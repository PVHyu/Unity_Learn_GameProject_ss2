using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackPoint : BaseMonoBehaviour
{
    protected override void Reset()
    {
        base.Reset();
        transform.localPosition = new Vector3(0, 0, 0.5f);
    }
}