using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindState : MonoBehaviour
{
    private static FindState instance = null;
    [SerializeField] Transform parent;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }

        instance = this;
    }
    public static FindState Instance
    {
        get
        {
            if (null == instance)
            {
                return null;
            }
            return instance;
        }
    }
    public GameObject FindStateObj(byte val)
    {
        GameObject obj;
        obj = parent.GetChild(val).gameObject;

        return obj;
    }
}
