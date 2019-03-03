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
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Instantiate<GameObject>(endGame);
        }
    }
}
