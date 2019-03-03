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
            List<Resource> resources = new List<Resource>(3);
            City c = transform.root.gameObject.GetComponent<City>();
            if (c.IsSufficientResources(resources, 50))
            {
                List<int> cost = new List<int>() { 50, 50, 50 };
                c.UseResources(cost);

                EventSystem.EventHappened(EventType.UpgradeBuilt);
            }
        }
    }
}
