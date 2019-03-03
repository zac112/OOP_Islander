using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyPopulation : MonoBehaviour
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
            City c = transform.root.gameObject.GetComponent<City>();
            List<int> cost = new List<int>() { 50, 50, 50 };
            if (c.IsSufficientResources(createResourceGO(), 50))
            {
                c.UseResources(cost);
                c.AddPopulation(50);

                EventSystem.EventHappened(EventType.UpgradeBuilt);
            } else
            {
                Debug.Log("Not enough resources");
            }
        }
    }

    private List<Resource> createResourceGO()
    {
        GameObject go = new GameObject();
        go.AddComponent<Forest>();
        go.AddComponent<Quarry>();
        go.AddComponent<BerryBush>();
        return new List<Resource>(go.GetComponents<Resource>());
    }
}
