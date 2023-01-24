using UnityEngine;

public class Player : MonoBehaviour
{
    private static Player instance = null;
    [SerializeField] Transform parent;//Panel
    GameObject obj; //상태표시판
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(instance);
        }

        instance = this;
    }
    public static Player Instance
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
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);

            if(hit.collider != null)
            {
                GameObject gobj = hit.collider.gameObject;
                if (gobj.CompareTag("Player"))
                {
                    obj = parent.GetChild(2).gameObject;
                }
                else if(gobj.CompareTag("Enemy"))
                {
                    obj = parent.GetChild(3).gameObject;
                }
                else
                {
                    return;
                }
                
                obj.SetActive(true);
            }
        }
    }

    public GameObject FindStateObj(string who, byte val)
    {
        GameObject obj2;
        if (who== "StateToEnemy")
        {
            obj2 = parent.GetChild(3).GetChild(1).GetChild(val).gameObject;
            return obj2;

        }
        else if(who== "StateToMe")
        {
            obj2 = parent.GetChild(2).GetChild(1).GetChild(val).gameObject;
            return obj2;

        }
        else
        {
            return null;
        }

        
    }


}
