﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    [SerializeField]
    GameObject respanelPrefab;

    [SerializeField]
    GameObject resrowPrefab;

    [SerializeField]
    List<GameObject> workerlista;

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

    public int paneelienmaara = 0;



    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    /**
     * Palauttaa kysytyn targetin levelin
     */
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
                return this.workerlista.Count;
            default:
                Debug.Log("Default");
                return -1;
                break;
        }
        return 1;
    }

    /**
     * Lisaa uuden collecotrin
     */
    public void AddCollector()
    {

        GameObject go = Instantiate<GameObject>(worker);
        this.workerlista.Add(go);
        
        go.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y);

        
        this.population++;
    }


    /** 
     *  Kayttaa resurssia r, maaran 'amount' verran (amount >= 0).
     *  Voidaan kayttaa maximissaan sen verran resursseja mita niita on kaytossa.
     */
    public int UseResource(Resource r, int amount)
    {
        if (amount<0)
        {
            return 0;
        }
        int otettuMaara = 0;
        ResourcePool[] lista = gameObject.GetComponents<ResourcePool>();
        for (int i = 0; i < lista.Length; i++)
        {
            if (lista[i].GetResource().GetType().Equals(r.GetType()))
            {
                otettuMaara = lista[i].UseResource(amount);
            }
        }
        return otettuMaara;
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
        if (amount < 0)
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
        if (paneelienmaara == 0)
        {
            GameObject respanel = Instantiate<GameObject>(respanelPrefab);
            paneelienmaara++;
        }
        float x = gameObject.transform.position.x;
        float y = gameObject.transform.position.y + 1f - lista.Length * 0.5f;
        float z = gameObject.transform.position.z;
        GameObject resrow = Instantiate<GameObject>(resrowPrefab);
        resrow.GetComponent<ResourceRow>().SetRow(r, x - 2f, y, z);
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
    public List<GameObject> GetWorkerList()
    {
        return workerlista;
    }
    public void OnMouseDown()
    {
        AddCollector();
    }
}
