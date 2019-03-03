using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Luokka, joka vaatii collectoreilta 100 puuta ennen kuin Quarry voidaan luoda samaan pisteeseen kartalla
public class Outcrop : Resource
{
    public override void checkExistence() { }
    public override void refreshSprite() { }

    // Start is called before the first frame update
    void Start()
    {
        setAmount(0);
    }

    // Update is called once per frame
    void Update()
    {
        if (getAmount() == 100)
        {
            // luo Quarry -olio samaan pisteeseen kartalla ja tuhoa Outcrop -olio
        }
    }
}
