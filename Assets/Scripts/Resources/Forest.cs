﻿using System.Collections;
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
            growthspeed = 3f;
        }
        else
        {
            growthspeed = 5f;
        }
    }

    public override void refreshSprite()
    {
        if (sprites == null) return;
        if (getAmount() < 25)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[7];
        }
        else if (getAmount() < 50)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[6];
        }
        else if (getAmount() < 75)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[5];
        }
        else if (getAmount() < 100)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[4];
        }
        else if (getAmount() < 125)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[3];
        }
        else if (getAmount() < 150)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
        }
        else if (getAmount() < 175)
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
            gameObject.SetActive(false);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        setEventType(EventType.WoodChopped);
        setAmount(Random.Range(50, 70));
        isForester = false;
        growthspeed = 3f;
        StartCoroutine("Grow");
    }

    IEnumerator Grow()
    {
        while (getAmount() < 200)
        {
            setAmount(getAmount() + 1);
            yield return new WaitForSeconds(growthspeed);
        }
    }
}
