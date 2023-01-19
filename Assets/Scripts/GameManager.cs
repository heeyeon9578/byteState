using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;

public class GameManager : MonoBehaviour
{
    public List<byte> list = new List<byte>();
    private void Awake()
    {

        foreach (States state in Enum.GetValues(typeof(States)))
        {
            list.Add((byte)state);
        }
    }
    private void Start()
    {
        for(int i=0; i < list.Count; i++)
        {
            Debug.Log(list[i]); 
        }
    }
    public void StateToEnemy(int num)
    {
        switch (num)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
        }
    }

    public void StateToMe(int num)
    {
        switch (num)
        {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
        }
    }

}
