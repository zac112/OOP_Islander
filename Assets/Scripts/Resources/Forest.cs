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
        if (getAmount() < 125)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[7];
        }
        else if (getAmount() < 250)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[6];
        }
        else if (getAmount() < 375)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[5];
        }
        else if (getAmount() < 500)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[4];
        }
        else if (getAmount() < 625)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[3];
        }
        else if (getAmount() < 750)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
        }
        else if (getAmount() < 875)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[1];
        }
        else
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[0];
        }
    }

    public override void checkExistence()
    {
        if (getAmount() < 1)
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        setEventType(EventType.WoodChopped);
        setAmount(Random.Range(50, 300));
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
        while (getAmount() < 1000)
        {
            setAmount(getAmount() + 1);
            yield return new WaitForSeconds(growthspeed);
        }
    }
}
