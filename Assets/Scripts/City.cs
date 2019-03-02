using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class City : MonoBehaviour
{
    
    
    // Start is called before the first frame update
    void Start()
    {
        
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
    }
    public void useResources(List<float> a)
    {
        
    }
}
