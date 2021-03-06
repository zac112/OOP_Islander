﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcePool : MonoBehaviour
{

    [SerializeField]
    private Resource r;

    [SerializeField]
    private int amount = 0;

    [SerializeField]
    private int maxCapacity = 100;

    private int oneBar = 25;

    private Sprite icon;

    public int CalcBars()
    {
        return maxCapacity / oneBar;
    }



    // Start is called before the first frame update
    void Start()
    {

    }
    public void SetResource(Resource r)
    {
        if (r == null)
        {
            return;
        }
        this.r = r;
        icon = r.getResourceImg();
    }

    public Resource GetResource()
    {
        return r;
    }
    /**
     * Kayttaa resurssia maaran X verran
     */
    public int UseResource(int x)
    {
        int otettuMaara = 0;
        if (this.amount - x <= 0)
        {
            otettuMaara = this.amount;
            this.amount = 0;
            return otettuMaara;
        }
        else
        {
            this.amount -= x;
            return x;
        }
    }
    /**
     * Lisaa resurssia maaran X verran
     */
    public void AddResource(int x)
    {
        if (this.amount + x >= this.maxCapacity)
        {
            this.amount = this.maxCapacity;
        }
        else
        {
            this.amount += x;
        }
    }
    public void SetCapacity(int x)
    {
        this.maxCapacity += x;
    }
    public int GetMaxCapacity()
    {
        return this.maxCapacity;
    }
    public int GetAmount()
    {
        return amount;
    }
    
}
