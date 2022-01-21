using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBase<T> : MonoBehaviour where T : MonoBehaviour
{

    static T self;

    public static T Self
    {

        get
        {

            if (self != null) return self;

            if (self == null) Debug.LogError(typeof(T) + " is nothing ");

            return self;
        }
    }


    protected virtual void Awake()
    {

        if (self != null && self != this)
        {

            Debug.LogError(typeof(T) + " is crerated again! ", this);
            return;
        }

        self = this as T;
    }

    protected virtual void OnDestroy()
    {

        if (self == this)
            self = null;
    }


}
