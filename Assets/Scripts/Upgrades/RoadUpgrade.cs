using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadUpgrade : Upgrade
{

    // Start is called before the first frame update
    void Start()
    {
        maxLevelModifier = 2;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeRoad()
    {
        UpgradeTargets target = UpgradeTargets.speed;
        Road road = gameObject.GetComponent<Road>();
        City city = gameObject.GetComponent<City>();
        int currentLevel = (int) road.GetLevel(target);

        if (currentLevel <= maxLevelModifier)
        {
            city.UseResources(GetPrices(currentLevel));
            road.IncreaseSpeed(1 / currentLevel);
            Debug.Log("Road upgraded");
        }
    }

}
