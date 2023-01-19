using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Physics.Raycast(ray, out hit);

            if(hit.collider != null)
            {
                GameObject touchedObject = hit.transform.gameObject;
                touchedObject.transform.parent.transform.GetChild(0).gameObject.SetActive(true);
            }
        }
    }
}
