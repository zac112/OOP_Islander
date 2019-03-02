using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceEfficiencyUpgrade : Upgrade
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
        City city = gameObject.GetComponent<City>();
        increaseEfficiencyLevel();
        city.useResources(getPrices(getEfficiencyLevel() * getEfficiencyLevel()));
        Debug.Log("Efficienfy upgraded to: " + getEfficiencyLevel());
    }
}
