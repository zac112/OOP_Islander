using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

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


    public void SetTarget(GameObject target)
    {
        this.target = target;
    }
    public void MoveTo(GameObject target)
    {
        this.move_to = target;
    }
    GameObject lastClicked;
    Ray ray;
    RaycastHit rayHit;
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
            transform.position = Vector2.MoveTowards(new Vector2(transform.position.x, transform.position.y), move_to.transform.position, speed * Time.deltaTime);
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
        else if (collision.gameObject.name == "City")
        {
            //resets amount and resource variables
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
