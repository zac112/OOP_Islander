using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    [SerializeField]
    private GameObject target;

    [SerializeField]
    private GameObject move_to;

    [SerializeField]
    private int max_amount = 10;

    [SerializeField]
    private int amount;

    [SerializeField]
    private GameObject home;

    [SerializeField]
    private Resource resource;
    public float speed = 1;

    // Start is called before the first frame update
    void Start()
    {
        home = GameObject.FindGameObjectWithTag("Home");
    }

    public void SetTarget(GameObject target)
    {
        this.target = target;
    }
    public void MoveTo(GameObject target)
    {
        this.move_to = target;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                SetTarget(hit.collider.gameObject);
                MoveTo(hit.collider.gameObject);
            }
        }
        if (target != null)
            transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, -1f), move_to.transform.position, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Resource")
        {
            //Amount of resources worker is carrying right now
            this.amount = collision.gameObject.GetComponent<Resource>().extractResource(this.max_amount);
            //Gives target resource to resource variable
            this.resource = this.target.GetComponent<Resource>();
            StartCoroutine("goHome");
        }
        else if (collision.gameObject.name == "City" && this.resource != null)
        {
            //resets amount and resource variables
            collision.gameObject.GetComponent<City>().AddResource(this.resource, this.amount);
            this.amount = 0;
            this.resource = null;
            MoveTo(this.target);
            
        }
    }
    IEnumerator goHome()
    {
        yield return new WaitForSeconds(4);
        MoveTo(home);
    }

}
