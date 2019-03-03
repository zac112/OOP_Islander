using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRandomly : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine("moveAround");
    }

    private IEnumerator moveAround() {
        while (true)
        {
            float moveTime = Random.value * 2;
            float timeSpent = 0;
            Vector3 direction = new Vector3(Random.value*2-1,Random.value*2-1, 0);

            while (timeSpent < moveTime)
            {
                transform.position = transform.position + direction*0.01f;
                yield return null;
                timeSpent += Time.deltaTime;

            }
        }
    }
}
