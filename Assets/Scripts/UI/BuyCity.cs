using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyCity : MonoBehaviour
{

    [SerializeField]
    private GameObject endGame;

    // Start is called before the first frame update
    void Start()
    {
        if(!transform.root.gameObject.GetComponent<City>().IsSufficientResources(createResourceGO(), 150))
        {
            Color c = gameObject.GetComponent<SpriteRenderer>().color;
            gameObject.GetComponent<SpriteRenderer>().color = c - new Color(25, 25, 25);
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            City c = transform.root.gameObject.GetComponent<City>();

            if (c.population > 200 && c.IsSufficientResources(createResourceGO(), 150))
            {
                Instantiate<GameObject>(endGame);
            }
        }
    }

    private List<Resource> createResourceGO()
    {
        GameObject go = new GameObject();
        go.AddComponent<Forest>();
        go.AddComponent<Quarry>();
        go.AddComponent<BerryBush>();
        return new List<Resource>(go.GetComponents<Resource>());
    }
}
    
