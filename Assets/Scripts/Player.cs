using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    List<byte> states= new List<byte>();
    [SerializeField] Transform parent;//Panel
    GameObject obj;
    GameObject myStatePanel;
    GameObject enemyStatePanel;

    private void Start()
    {
        myStatePanel = parent.GetChild(2).gameObject; //내상태판
        enemyStatePanel = parent.GetChild(3).gameObject; //적상태판

        foreach (States state1 in Enum.GetValues(typeof(States)))
        {
            states.Add((byte)state1); 
        }
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);

            if (hit.collider != null)
            {
                GameObject gobj = hit.collider.gameObject;
                if (gobj.CompareTag("Player"))
                {
                    obj = myStatePanel;
                }
                else if (gobj.CompareTag("Enemy"))
                {
                    obj = enemyStatePanel;
                }
                else
                {
                    return;
                }
                obj.SetActive(true);
            }
        }
    }

    //상태 부여
    public void StateToEnemy(int num)
    {
        string ButtonName = EventSystem.current.currentSelectedGameObject.tag;
        byte byteVal = (byte)num;
        for(int i=0; i<states.Count; i++)
        {
            if (byteVal == states[i])
            {
                GameObject stateobj = FindStateObj(ButtonName, byteVal);
                if (stateobj.activeSelf)
                {
                    stateobj.SetActive(false);
                }
                else
                {
                    stateobj.SetActive(true);
                }
            }
        }

    }

    //상태 오브젝트 찾기
    public GameObject FindStateObj(string who, byte val)
    {
        if (who == "StateToEnemy")
        {
            obj = enemyStatePanel;
        }
        else if (who == "StateToMe")
        {
            obj = myStatePanel;
        }
        else
        {
            return null;
        }
        return obj.transform.GetChild(1).GetChild(val).gameObject;
    }

}
