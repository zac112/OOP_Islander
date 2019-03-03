using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flag : MonoBehaviour
{
    [SerializeField]
    private GameObject Worker;

    public void SetWorker(GameObject w)
    {
        this.Worker = w;
    }
    public GameObject GetWorker()
    {
        return this.Worker;
    }
}
