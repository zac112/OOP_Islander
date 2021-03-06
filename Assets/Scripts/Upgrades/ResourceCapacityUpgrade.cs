﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCapacityUpgrade : Upgrade
{
    // Start is called before the first frame update
    void Start()
    {
        maxLevelModifier = 4;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeCapacity()
    {
        UpgradeTargets target = UpgradeTargets.capacity;
        City city = gameObject.GetComponent<City>();
        int currentLevel = city.GetLevel(target);

        if (currentLevel <= maxLevelModifier)
        {
            city.UseResources((GetPrices(currentLevel)));
            city.resourcePoolLevel++;
            city.IncreaseCapacity(currentLevel * 100);            
            Debug.Log("Capacity upgraded");
        }
    }

}
