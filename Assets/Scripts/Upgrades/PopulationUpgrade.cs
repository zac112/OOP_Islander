using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopulationUpgrade : Upgrade
{
    // Start is called before the first frame update
    public void Start()
    {
        maxLevelModifier = 5;
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
        
        /*
        // Change music based on population level
        switch (currentLevel)
        {
            case 3:
                EventSystem.EventHappened(EventType.CityBig);
                break;
            case 4:
                EventSystem.EventHappened(EventType.HuntingSmall);
                break;
            case 5:
                EventSystem.EventHappened(EventType.HuntingBig);
                break;
            default:
                break;
        }
        */
        if (currentLevel <= maxLevelModifier)
        {
            city.UseResources(GetPrices(currentLevel + 1));
            city.populationLevel++;
            city.AddPopulation(currentLevel * 10);
            Debug.Log("population upgraded");
        }
    }
}
