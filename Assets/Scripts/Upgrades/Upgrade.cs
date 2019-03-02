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

    public float GetEfficiencyLevel()
    {
        return efficiencyLevel;
    }

    public void IncreaseEfficiencyLevel()
    {
        efficiencyLevel++;
    }

    public float GetEfficiency()
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

    public List<int> GetPrices(float modifier)
    {
        List<int> prices = new List<int>();
        foreach(KeyValuePair<Resources, int> key in resources)
        {
            prices.Add((int) (key.Value * modifier * 50 * GetEfficiency()));
        }
        return prices;
    }

}
