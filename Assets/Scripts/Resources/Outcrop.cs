﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Luokka, joka vaatii collectoreilta 100 puuta ennen kuin Quarry voidaan luoda samaan pisteeseen kartalla
public class Outcrop : MonoBehaviour
{
    [SerializeField]
    private int wood;

    private int woodNeeded = 100;
    
    private GameObject quarry;
    public Resource neededResource;

    public int getAmount()
    {
        return wood;
    }

    public void setAmount(int amount)
    {
        wood += amount;
    }

    public void checkExistence()
    {
        if (getAmount() >= 100)
        {
            GameObject go = Instantiate<GameObject>(quarry);
            go.transform.position = this.transform.position;
            Destroy(gameObject);
        }
    }

    public void addResource(int amount)
    {
        setAmount(getAmount() + amount);
        checkExistence();
        woodNeeded -= getAmount();
    }

    public int stillNeeded()
    {
        return woodNeeded;
    }

    // Start is called before the first frame update
    void Start()
    {
        setAmount(0);
        GameObject go = new GameObject();
        neededResource = go.AddComponent<Forest>();
        neededResource.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (getAmount() == 100)
        {
            // luo Quarry -olio samaan pisteeseen kartalla ja tuhoa Outcrop -olio
        }
    }

}
