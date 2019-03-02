﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorUpgrade : Upgrade
{

    // Start is called before the first frame update
    void Start()
    {

        UpgradeTargets target = UpgradeTargets.collector;
        City city = gameObject.GetComponent<City>();
        float currentLevel = city.GetLevel(target);
        city.UseResources(getPrices(currentLevel));
        city.AddCollector();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
