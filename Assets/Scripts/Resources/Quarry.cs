﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quarry : Resource
{
 
    public override void checkExistence()
    {
        if (getAmount() < 1)
        {
            gameObject.SetActive(false);
        }
    }

    public override void refreshSprite()
    {
        if (sprites == null) return;
        if (getAmount() < 50)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[5];
        }
        else if (getAmount() < 166)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[4];
        }
        else if (getAmount() < 333)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[3];
        }
        else if (getAmount() < 500)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
        }
        else if (getAmount() < 633)
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
        setEventType(EventType.StoneCut);
        setAmount(Random.Range(500, 800));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
