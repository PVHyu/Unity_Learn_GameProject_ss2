using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;

public class BaseMonoBehaviour : MonoBehaviour
{
    protected virtual void Start()
    {
        
    } 

    protected virtual void Awake()
    {
        this.LoadComponents();
    }

    protected virtual void Reset()
    {
        this.LoadComponents();
        this.ResetValue();
    }

    protected virtual void LoadComponents()
    {
        
    }

    protected virtual void ResetValue()
    {
        //For override
    }
}
