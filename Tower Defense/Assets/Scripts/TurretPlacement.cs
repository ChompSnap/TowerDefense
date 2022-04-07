using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class TurretPlacement : MonoBehaviour
{
    public TMP_Text purse;
    public GameObject turretPrefab;
    public Transform placement;
    public Transform enviormentRoot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1))
        {
            Debug.Log("Test!!!");
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if (Physics.Raycast(ray, out hitInfo, 200f) && Input.GetMouseButtonDown(0))
            {
                if (hitInfo.collider.gameObject.tag == "Station")
                {
                    int money = Int32.Parse(purse.text);
                    if (money >= 3)
                    {
                        GameObject turretGO = Instantiate(turretPrefab, placement.position, placement.rotation);
                        turretGO.transform.parent = enviormentRoot;
                        Turrets turret = turretGO.GetComponent<Turrets>();
                        money -= 3;
                        purse.text = money.ToString();
                    }
                }
            }
        }
    }
}
