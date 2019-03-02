using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade : MonoBehaviour
{
    /*
    private float baseWoodCost = 10;
    private float baseStoneCost = 10;
    private float baseFoodCost = 10;
    */
    private float efficiencyLevel = 1;

    private Dictionary<Resources, int> resources = new Dictionary<Resources, int>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public float getEfficiencyLevel()
    {
        return efficiencyLevel;
    }

    public void increaseEfficiencyLevel()
    {
        efficiencyLevel++;
    }

    public float getEfficiency()
    {
        switch (efficiencyLevel)
        {
            case 1:
                Debug.Log("effLevel 1");
                return 1;
            case 2:
                Debug.Log("effLevel 2");
                return 0.9f;
            case 3:
                return 0.8f;
            case 4:
                return 0.7f;
            case 5:
                return 0.6f;
            default:
                Debug.Log("Default");
                return 1;
        }

    }

    public List<float> getPrices(float modifier)
    {
        List<float> prices = new List<float>();
        foreach(KeyValuePair<Resources, int> key in resources)
        {
            prices.Add(key.Value * modifier * 50 * getEfficiency());
        }

        return prices;
    }

}
