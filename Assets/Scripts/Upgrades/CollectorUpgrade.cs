using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorUpgrade : Upgrade
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

    public void UpgradeCollector()
    {
        UpgradeTargets target = UpgradeTargets.collector;
        City city = gameObject.GetComponent<City>();
        int currentLevel = city.GetLevel(target);

        if (currentLevel <= maxLevelModifier)
        {
            Debug.Log("Collector Upgraded");
            city.UseResources(GetPrices(currentLevel));
            city.AddCollector();
        }
    }
}
