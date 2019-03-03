using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour
{

    private void Start()
    {
        transform.localScale = new Vector3(Random.Range(2f, 5f), Random.Range(2f, 5f), 1);
    }

    void Update()
    {
        float x = transform.position.x;
        transform.position = new Vector3(x-0.1f, transform.position.y, transform.position.z);
        
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
