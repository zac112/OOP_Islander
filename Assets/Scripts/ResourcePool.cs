using System.Collections;
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

    // Start is called before the first frame update
    void Start()
    {
    }
    public void setResource(Resource r)
    {
        this.r = r;
    }

    public Resource getResource()
    {
        return r;
    }
    /**
     * Kayttaa resurssia maaran X verran
     */
    public void useResource(int x)
    {
        if (this.amount - x <= 0)
        {
            this.amount = 0;
        }
        else
        {
            this.amount -= x;
        }
    }
    /**
     * Lisaa resurssia maaran X verran
     */
    public void addResource(int x)
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
}
