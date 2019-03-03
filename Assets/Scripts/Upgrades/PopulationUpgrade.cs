using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationUpgrade : Upgrade
{
    // Start is called before the first frame update
    public void Start()
    {
        maxLevelModifier = 10;
    }

    // Update is called once per frame
    public void Update()
    {
        
    }

    public void UpgradePopulation()
    {
        UpgradeTargets target = UpgradeTargets.population;
        City city = gameObject.GetComponent<City>();
        int currentLevel = city.GetLevel(target);
        city.UseResources(GetPrices(currentLevel));
        city.AddPopulation(currentLevel * 10);
        Debug.Log("population upgraded");
    }
}
