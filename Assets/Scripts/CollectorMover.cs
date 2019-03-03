using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectorMover : MonoBehaviour
{ 
    [SerializeField]
    Sprite[] sprites = null;
    Collector col;

    // Start is called before the first frame update
    void Start()
    {
        col = gameObject.GetComponent<Collector>();
    }

    // Update is called once per frame
    void Update()
    {

        //Vector3 target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 target = col.GetMoveToTarget().transform.position;
        Vector3 dir = target - transform.position;
        GameObject go = new GameObject();
        go.transform.position = target;
        dir = go.transform.InverseTransformDirection(dir);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        angle += 22.5f;
            
        Debug.Log(angle);
        Destroy(go);
        SpriteRenderer rd = gameObject.GetComponent<SpriteRenderer>();
        if(angle > -180 && angle < -135f)
        {
            rd.sprite = sprites[3];
        }
        else if (angle > -135f && angle < -90f)
        {
            rd.sprite = sprites[1];
        }
        else if (angle > -90f && angle < -45f)
        {
            rd.sprite = sprites[0];
        }
        else if (angle > -45f && angle < 0f)
        {
            rd.sprite = sprites[2];
        }
        else if (angle > 0f && angle < 45f)
        {
            rd.sprite = sprites[4];
        }
        else if (angle > 45f && angle < 90f)
        {
            rd.sprite = sprites[6];
        }
        else if (angle > 90f && angle < 135f) {
            rd.sprite = sprites[7];
        }
        else if (angle > 135f && angle < 180f)
        {
            rd.sprite = sprites[5];
        }
        else 
        {
            rd.sprite = sprites[3];
        }
    }
    
}
