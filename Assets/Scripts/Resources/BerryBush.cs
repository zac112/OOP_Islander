using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BerryBush : Resource
{
    public bool coroutineRunning =false;

    public override void checkExistence()
    {
        if (!coroutineRunning)
        {
            StartCoroutine("timer");
            coroutineRunning = true;
        }
    }

    private IEnumerator timer()
    {
        yield return new WaitForSeconds(600);
        setAmount(50);
        coroutineRunning = false;


    }


    public override void setAmount(int i)
    {
        base.setAmount(i);
    }

    public override void refreshSprite()
    {
        if (sprites == null) return;
        if (getAmount() < 1)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[5];
        }
        else if (getAmount() <= 10)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[4];
        }
        else if (getAmount() <= 20)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[3];
        }
        else if (getAmount() <= 30)
        {
            gameObject.GetComponent<SpriteRenderer>().sprite = sprites[2];
        }
        else if (getAmount() <= 40)
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
        setEventType(EventType.Berrypicked);
        setAmount(50);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
