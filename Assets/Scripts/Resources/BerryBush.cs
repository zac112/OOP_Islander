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
        if (getAmount() < 100)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[5];
        }
        else if (getAmount() < 200)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[4];
        }
        else if (getAmount() < 300)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[3];
        }
        else if (getAmount() < 400)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
        }
        else if (getAmount() < 500)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        setAmount(Random.Range(50, 200));
        growthspeed = 1;
        StartCoroutine("Grow");
    }

    IEnumerator Grow()
    {
        while (getAmount() < 600)
        {
            setAmount(getAmount() + 1);
            yield return new WaitForSeconds(growthspeed);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
