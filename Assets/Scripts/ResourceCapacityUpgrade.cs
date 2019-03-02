using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCapacityUpgrade : Upgrade
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void upgrade()
    {
        UpgradeTargets target = UpgradeTargets.capacity;
        City city = gameObject.GetComponent<City>();
        float currentLevel = city.getLevel(target);
        city.useResources(getPrices(currentLevel));
        city.increaseCapacity(currentLevel * 100);
        Debug.Log("Capacity upgraded");
    }

}
