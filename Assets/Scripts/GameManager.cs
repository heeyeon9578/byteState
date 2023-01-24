using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    private static GameManager instance = null;
    GameObject stateObj;
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }

        instance = this;
    }
    public static GameManager Instance
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

    public void StateToEnemy(int num)
    {
        byte byteVal = (byte)num;
        foreach (States state1 in Enum.GetValues(typeof(States)))
        {
            if (byteVal == (byte)state1)
            {
                Player.Instance.FindStateObj("StateToEnemy", byteVal).SetActive(true);
            }
        }
    }

    public void StateToMe(int num)
    {
        byte byteVal = (byte)num;
        foreach (States state1 in Enum.GetValues(typeof(States)))
        {
            if (byteVal == (byte)state1)
            {
                Player.Instance.FindStateObj("StateToMe", byteVal).SetActive(false);
            }
        }
    }

}
