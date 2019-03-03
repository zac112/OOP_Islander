using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinGame : MonoBehaviour
{
    [SerializeField]
    private GameObject housePrefab = null;
    [SerializeField]
    private GameObject workerPrefab = null;

    private List<GameObject> houses = new List<GameObject>();

    void Start()
    {
        StartCoroutine("MoveCamera");
        StartCoroutine("EndGame");
    }
    private IEnumerator MoveCamera()
    {
        while (Camera.main.orthographicSize < 9f) {
            Camera.main.orthographicSize += 0.01f;
            yield return null;
        }
    }

    private IEnumerator EndGame()
    {
        EventSystem.EventHappened(EventType.TimePeriodChanged);
        float spawnRate = 5f;
        int count = 0;
        while (count < 9)
        {
            GameObject go = Instantiate<GameObject>(housePrefab);
            Destroy(go.GetComponent<BoxCollider2D>());
            houses.Add(go);
            go.transform.position = new Vector3(Random.Range(1f, 14f), Random.Range(1f, 14f),-5);
            spawnRate -= 0.5f;
            yield return new WaitForSeconds(spawnRate);
            count++;
        }
        for (int i = 0; i < 10; i++) {
            GameObject go = Instantiate<GameObject>(housePrefab);
            Destroy(go.GetComponent<BoxCollider2D>());
            houses.Add(go);
            go.transform.position = new Vector3(Random.Range(1f, 14f), Random.Range(1f, 14f), -5);
            yield return new WaitForSeconds(spawnRate);
        }
        count = 0;
        EventSystem.EventHappened(EventType.WinMusic);
        while (count < 150)
        {
            GameObject go = Instantiate<GameObject>(workerPrefab);
            int index = Random.Range(0, houses.Count);
            go.transform.position = houses[index].transform.position;
            go.AddComponent<MoveRandomly>();
            Destroy(go.GetComponent<Collector>());
            Destroy(go.GetComponent<Rigidbody2D>());
            yield return new WaitForSeconds(0.1f);
            count++;
        }
    }
    
}
