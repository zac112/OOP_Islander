using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadUpgrade : Upgrade
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
        UpgradeTargets target = UpgradeTargets.speed;
        Road road = gameObject.GetComponent<Road>();
        City city = gameObject.GetComponent<City>();
        float currentLevel = road.getLevel(target);
        city.useResources(getPrices(currentLevel));
        road.increaseSpeed(1 / currentLevel);
        Debug.Log("Road upgraded");
    }

}
