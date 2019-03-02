using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Outcrop : Resource
{
    public override void checkExistence()
    {
        if (resources < 1)
        {
            Destroy(gameObject);
        }
    }

    public override void refreshSprite()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        resources = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (resources == 100)
        {
            // luo Quarry -olio samaan pisteeseen kartalla ja tuhoa Outcrop -olio
        }
    }
}
