using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceRow : MonoBehaviour
{
    private Resource r;

    private Sprite sprite;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetRow(Resource r, float x, float y, float z)
    {
        this.r = r;
        this.GetComponent<SpriteRenderer>().sprite = r.getResourceImg();
        this.GetComponent<SpriteRenderer>().transform.position = new Vector3(x, y, z);
        this.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(0.35f, 0.35f, 1f);
    }

}
