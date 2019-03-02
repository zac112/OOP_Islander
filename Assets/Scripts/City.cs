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
    public void useResource(Resource r, int amount)
    {
        if (amount<0)
        {
            return;
        }
        ResourcePool[] lista = gameObject.GetComponents<ResourcePool>();
        for (int i = 0; i < lista.Length; i++)
        {
            if (lista[i].getResource().GetType().Equals(r.GetType()))
            {
                lista[i].useResource(amount);
            }
        }
    }

    /** 
*  Lisaa resurssia r, maaran 'amount' verran (amount >= 0).
*  Voidaan lisata maximissaan resurssin maximikapasiteettiin asti,
*  ts. jos nykyinen resurssimaara + lisatty maara >= maximikapasiteetti
*  niin uusi resurssimaara = maximikapasiteetti
*/
    public void addResource(Resource r, int amount)
    {
        if (amount<0)
        {
            return;
        }
        ResourcePool[] lista = gameObject.GetComponents<ResourcePool>();
       
        for (int i = 0; i < lista.Length; i++)
        {
            if (lista[i].getResource().GetType().Equals(r.GetType()))
            {
                lista[i].addResource(amount);
                return;
            }
        }
        ResourcePool respool = gameObject.AddComponent<ResourcePool>();
        respool.setResource(r);
        respool.addResource(amount);
    }
}
