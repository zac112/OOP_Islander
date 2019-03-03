using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Forest : Resource
{
    private bool isForester;
    private float growthspeed;

    public void setForester(bool i)
    {
        isForester = i;
        if (isForester == true)
        {
            growthspeed = 0.5f;
        }
        else
        {
            growthspeed = 1f;
        }
    }

    public override void refreshSprite()
    {
        if (resources < 125)
        {
            //yhden puun sprite
        }
        else if (resources < 250)
        {
            //2 sprite
        }
        else if (resources < 375)
        {

        }
        else if (resources < 500)
        {

        }
        else if (resources < 625)
        {

        }
        else if (resources < 750)
        {

        }
        else if (resources < 875)
        {

        }
        else
        {

        }
    }

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
        resources = Random.Range(50, 300);
        isForester = false;
        growthspeed = 1;
        StartCoroutine("Grow");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Grow()
    {
        while (resources < 1000)
        {
            resources++;
            yield return new WaitForSeconds(growthspeed);
        }
    }
}
