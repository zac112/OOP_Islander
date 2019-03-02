using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quarry : Resource
{
 
    public override void checkExistence()
    {
        if (resources < 1)
        {
            Destroy(gameObject);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        resources = Random.Range(2000, 4000);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
