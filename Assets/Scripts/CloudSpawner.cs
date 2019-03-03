using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    [SerializeField]
    private GameObject cloudPrefab = null;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("StartSpawning");   
    }

    private IEnumerator StartSpawning() {
        while (true)
        {
            GameObject go = Instantiate<GameObject>(cloudPrefab);
            Vector3 min = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, 0, -10));
            Vector3 max = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, -10));
            go.transform.position = new Vector3(max.x+10, Random.Range(min.y,max.y),-5);
            yield return new WaitForSeconds(Random.Range(2, 7));
        }
    }
}
