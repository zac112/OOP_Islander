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
        int currentLevel = city.GetLevel(target);
        city.UseResources(GetPrices(currentLevel));
        city.AddCollector();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
