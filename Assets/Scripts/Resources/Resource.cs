using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Resource : MonoBehaviour
{
    [SerializeField]
    private int resources;

    [SerializeField]
    protected Sprite[] sprites;


    public void setAmount(int i)
    {
        resources = i;
        refreshSprite();
    }

    public int getAmount()
    {
        return resources;
    }
    
    public int extractResource(int amount)
    {
        if (resources-amount < 0)
        {
            int r = resources;
            resources = 0;
            refreshSprite();
            checkExistence();
            return r;
        }
        else
        {
            resources = resources - amount;
            refreshSprite();
            checkExistence();
            return amount;
        }
      
    }

    public abstract void refreshSprite();




    public abstract void checkExistence();
}
