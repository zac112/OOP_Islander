using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMover : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey) {
            float x = transform.position.x;
            float y = transform.position.y;
            float z = transform.position.z;
            if (Input.GetKey(KeyCode.LeftArrow)){
                gameObject.transform.position = new Vector3(x - 0.1f, y, z);
            }
            if (Input.GetKey(KeyCode.RightArrow)){
                gameObject.transform.position = new Vector3(x + 0.1f, y, z);
            }
            if (Input.GetKey(KeyCode.UpArrow)){
                gameObject.transform.position = new Vector3(x, y + 0.1f, z);
            }
            if (Input.GetKey(KeyCode.DownArrow)){
                gameObject.transform.position = new Vector3(x, y - 0.1f, z);
            }
        }
    }
}
