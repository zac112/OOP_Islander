﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    [SerializeField]
    GameObject worker;

    [SerializeField]
    public int population = 0;

    [SerializeField]
    public int populationLevel = 0;

    [SerializeField]
    public int resourcePoolLevel = 0;

    [SerializeField]
    public int roadLevel = 0;

    [SerializeField]
    public int collectorLevel = 0;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public int GetLevel(UpgradeTargets target)
    {
        switch (target)
        {
            case UpgradeTargets.population:
                return this.populationLevel;
            case UpgradeTargets.capacity:
                return this.resourcePoolLevel;
            case UpgradeTargets.speed:
                return this.roadLevel;
            case UpgradeTargets.collector:
                return this.collectorLevel;
            default:
                Debug.Log("Default");
                return -1;
                break;
        }
        return 1;
    }

    public void AddCollector()
    {

        GameObject go = Instantiate<GameObject>(worker);

        go.transform.position = new Vector3();
    }


    /** 
     *  Kayttaa resurssia r, maaran 'amount' verran (amount >= 0).
     *  Voidaan kayttaa maximissaan sen verran resursseja mita niita on kaytossa.
     */
    public void UseResource(Resource r, int amount)
    {
        if (amount<0)
        {
            return;
        }
        ResourcePool[] lista = gameObject.GetComponents<ResourcePool>();
        for (int i = 0; i < lista.Length; i++)
        {
            if (lista[i].GetResource().GetType().Equals(r.GetType()))
            {
                lista[i].UseResource(amount);
            }
        }
    }

    public void AddPopulation(int v)
    {
        this.population += v;
    }


    /** 
*  Lisaa resurssia r, maaran 'amount' verran (amount >= 0).
*  Voidaan lisata maximissaan resurssin maximikapasiteettiin asti,
*  ts. jos nykyinen resurssimaara + lisatty maara >= maximikapasiteetti
*  niin uusi resurssimaara = maximikapasiteetti
*/
    public void AddResource(Resource r, int amount)
    {
        if (amount<0)
        {
            return;
        }
        ResourcePool[] lista = gameObject.GetComponents<ResourcePool>();
       
        for (int i = 0; i < lista.Length; i++)
        {
            if (lista[i].GetResource().GetType().Equals(r.GetType()))
            {
                lista[i].AddResource(amount);
                return;
            }
        }
        ResourcePool respool = gameObject.AddComponent<ResourcePool>();
        respool.SetResource(r);
        respool.AddResource(amount);
    }

    /**
     * Lisaa kaikkien resurssipoolien maxKapasiteettia x:n verran
     */
    public void IncreaseCapacity(int x)
    {
        ResourcePool[] lista = gameObject.GetComponents<ResourcePool>();
        for (int i = 0; i < lista.Length; i++)
        {
            lista[i].SetCapacity(x);
        }
        this.resourcePoolLevel++;
    }
    public void UseResources(List<int> a)
    {
        ResourcePool[] lista = gameObject.GetComponents<ResourcePool>();

        for (int i = 0; i < lista.Length; i++)
        {
            UseResource(lista[i].GetResource(), a[0]);
        }
    }
}
