using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyEfficiency : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Debug.Log("Ostit Tehokkuutta");
            ResourceEfficiencyUpgrade reu = gameObject.GetComponent<ResourceEfficiencyUpgrade>();
            reu.UpgradeEfficiency();
        }
    }
}
