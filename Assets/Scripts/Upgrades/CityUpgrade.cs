using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityUpgrade : Upgrade
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeCity()
    {

        UpgradeTargets target = UpgradeTargets.city;
        City city = gameObject.GetComponent<City>();
        int currentLevel = city.GetLevel(target);

        if (city.GetLevel(UpgradeTargets.population) >= 5) {
            city.UseResources(GetPrices(currentLevel * 10));
        //    city.IncreaseCityLevel();  currently not implemented in City
        }
        
    }
}
