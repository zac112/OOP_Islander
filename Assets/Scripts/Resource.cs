using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Resource : MonoBehaviour
{
    protected int resources;

    public void setAmount(int i)
    {
        resources = i;
    }

    public int getAmount()
    {
        //r.setAmount(ref.getAmount() - extraction);
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
