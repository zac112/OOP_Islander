using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quarry : Resource
{
 
    public override void checkExistence()
    {
        if (getAmount() < 1)
        {
            Destroy(gameObject);
        }
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
        setEventType(EventType.StoneCut);
        setAmount(Random.Range(2000, 4000));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
