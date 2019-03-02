using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorUpgrade : Upgrade
{

    // Start is called before the first frame update
    void Start()
    {

        UpgradeTargets target = UpgradeTargets.collector;
        City city = gameObject.GetComponent<City>();
        float currentLevel = city.getLevel(target);
        city.useResources(getPrices(currentLevel));
        city.addCollector();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
