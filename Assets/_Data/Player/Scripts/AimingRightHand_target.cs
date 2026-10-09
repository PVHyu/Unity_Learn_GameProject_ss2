using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingRightHand_target : BaseMonoBehaviour
{
    protected override void ResetValue()
    {
        base.ResetValue();
        transform.localPosition = new Vector3(-0.366f, 0.219f, 0.036f);
        transform.localRotation = Quaternion.Euler(27f, 16f, 113.5f);
    }
}
