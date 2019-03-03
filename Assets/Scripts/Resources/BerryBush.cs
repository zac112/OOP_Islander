using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerryBush : Resource
{

    private float growthspeed;

    public override void checkExistence()
    {
        
    }

    public override void refreshSprite()
    {
        if (resources < 100)
        {
            //1 marjan sprite
        }
        else if (resources < 200)
        {
            //2 marjan sprite
        }
        else if (resources < 300)
        {
            //3 marjan sprite
        }
        else if (resources < 400)
        {
            //4 marjan sprite
        }
        else
        {
            // 5 marjan sprite
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        resources = Random.Range(50, 200);
        growthspeed = 1;
        StartCoroutine("Grow");
    }

    IEnumerator Grow()
    {
        while (resources < 500)
        {
            resources++;
            yield return new WaitForSeconds(growthspeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
