using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    [SerializeField]
    private GameObject Worker;

    private void Start()
    {
        StartCoroutine("resize");
    }
    public void SetWorker(GameObject w)
    {
        this.Worker = w;
    }
    public GameObject GetWorker()
    {
        return this.Worker;
    }

    private IEnumerator resize() {
        int multiplier = 1;
        while (true) {
            for (int i = 0; i < 100; i++) {
                yield return new WaitForSeconds(0.01f);
                transform.localScale = transform.localScale + new Vector3(0.01f,0.01f,0)*multiplier;
            }
            multiplier *= -1;
        }
    }
}
