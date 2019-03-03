using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceEfficiencyUpgrade : Upgrade
{
    // Start is called before the first frame update
    void Start()
    {
        maxLevelModifier = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpgradeEfficiency()
    {
        City city = gameObject.GetComponent<City>();
        if (GetEfficiencyLevel() <= maxLevelModifier)
        {
            IncreaseEfficiencyLevel();
            city.UseResources(GetPrices(GetEfficiencyLevel() * GetEfficiencyLevel()));
            Debug.Log("Efficienfy upgraded to: " + GetEfficiencyLevel());
        }
    }
}
