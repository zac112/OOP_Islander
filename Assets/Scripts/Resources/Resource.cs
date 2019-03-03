using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Resource : MonoBehaviour
{
    [SerializeField]
    private int resources;

    [SerializeField]
    private bool resourceSource;

    [SerializeField]
    protected Sprite[] sprites;

    public bool isResourceSource()
    {
        return resourceSource;
    }

    public void setResourceSource(bool i)
    {
        resourceSource = i;
    }

    public virtual void setAmount(int i)
    {
        resources = i;
        refreshSprite();
        checkExistence();
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
            setAmount(0);
            return r;
        }
        else
        {
            setAmount(resources - amount);
            return amount;
        }
      
    }

    public abstract void refreshSprite();




    public abstract void checkExistence();
}
