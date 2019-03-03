using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceRow : MonoBehaviour
{
    private Resource r;

    private Sprite sprite;

    [SerializeField]
    private Sprite[] sprites;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        UpdateBars();
    }

    public void SetRow(Resource r, float x, float y, float z)
    {
        this.r = r;
        this.GetComponent<SpriteRenderer>().sprite = r.getResourceImg();
        this.GetComponent<SpriteRenderer>().transform.position = new Vector3(x, y, z);
        this.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(0.35f, 0.35f, 1f);
    }
    public void UpdateBars()
    {
        GameObject city = GameObject.FindGameObjectWithTag("Home");
        ResourcePool[] lista = city.GetComponents<ResourcePool>();

        for (int i = 0; i < lista.Length; i++)
        {
            if (lista[i].GetResource().GetType().Equals(r.GetType()))
            {
                

                int amount = lista[i].GetAmount();
                int max = lista[i].GetMaxCapacity();
                float pros = amount*1f / max*1f;
                if (pros<=0.2)
                {
                    transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[0];
                } else if(pros<=0.4)
                {
                    transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[1];
                } else if(pros<=0.6)
                {
                    transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[2];
                } else if(pros<=0.8)
                {
                    transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[3];
                } else
                {
                    transform.GetChild(0).GetComponent<SpriteRenderer>().sprite = sprites[4];
                }
            }
        }
    }

}
