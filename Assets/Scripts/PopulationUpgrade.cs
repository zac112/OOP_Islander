using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationUpgrade : Upgrade
{
    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void upgrade()
    {
        UpgradeTargets target = UpgradeTargets.population;
        City city = gameObject.GetComponent<City>();
        float currentLevel = city.getLevel(target);
        city.useResources(getPrices(currentLevel));
        city.addPopulation(currentLevel * 10);
        Debug.Log("population upgraded");
    }
}
