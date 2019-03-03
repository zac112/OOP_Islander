using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Resource : MonoBehaviour
{
    [SerializeField]
    private int resources;

    [SerializeField]
    private Sprite resourceImg;

    [SerializeField]
    protected Sprite[] sprites;

    private EventType type;

    public void setEventType(EventType e)
    {
        type = e;
    }

    public EventType getEventType()
    {
        return type;
    }

    public Sprite getResourceImg()
    {
        return resourceImg;
    }

    public virtual void setAmount(int i)
    {
        resources = i;
        refreshSprite();
        checkExistence();
    }

    public int getAmount()
    {
        return resources;
    }

    // Soittaa resurssin keruuseen liittyvän äänen sekä vähentää resurssista annetun määrän yksiköitä tai asettaa määrän nollaan,
    // mikäli vähennettävä arvo on suurempi kuin resurssiyksiköiden senhetkinen määrä. Palauttaa resurssin vähennetyn määrän.
    public int extractResource(int amount)
    {
        EventSystem.EventHappened(getEventType());
        if (resources-amount < 0)
        {
            int r = resources;
            setAmount(0);
            return r;
        }
        else
        {
            setAmount(resources - amount);
            return amount;
        }
    }

    // Metodi spriten päivitystä varten.
    public abstract void refreshSprite();

    // Metodi jolla tarkistetaan resurssien olemassaolon ehdot ja suoritetaan tarvittavat toimenpiteet.
    public abstract void checkExistence();
}
