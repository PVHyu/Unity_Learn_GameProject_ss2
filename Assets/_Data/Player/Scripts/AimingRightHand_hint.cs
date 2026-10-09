using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimingRightHand_hint : BaseMonoBehaviour
{
    protected override void ResetValue()
    {
        base.ResetValue();
        transform.localPosition = new Vector3(0.456f, 0.189f, 0.028f);
        transform.localRotation = Quaternion.Euler(36.552f, -8.843f, 22.764f);
    }
}