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
    private int Requested_amount;

    [SerializeField]
    private Resource Requested_resource;

    [SerializeField]
    private bool OnkoVapaa;

    [SerializeField]
    private int amount;

    [SerializeField]
    private GameObject home;
    
    [SerializeField]
    private Resource resource;
    public float speed = 1;

    [SerializeField]
    private GameObject target_flag;

    [SerializeField]
    private bool send_to_resource;
    public GameObject flag;
    // Start is called before the first frame update
    void Start()
    {
        home = GameObject.FindGameObjectWithTag("Home");
    }

    public void SetOnkoVapaa(bool vapaa)
    {
        this.OnkoVapaa = vapaa;
    }
    public bool tarkistaVapaus()
    {
        return this.OnkoVapaa;
    }
    public void SetTarget(GameObject target)
    {
        this.target = target;
    }
    public void MoveTo(GameObject target)
    {
        this.move_to = target;
    }
    public Resource getResource()
    {
        return this.resource;
    }
    public void SetSend_to_resource(bool r)
    {
        this.send_to_resource = r;
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
                if (hit.collider.gameObject.GetComponent<Outcrop>() != null && hit.collider.gameObject.tag == "Buildable")
                {
                    this.send_to_resource = true;
                }
                else
                {
                    this.send_to_resource = false;
                }
                DestroyImmediate(target_flag);
                target_flag = Instantiate(flag, hit.point, Quaternion.identity);
                target_flag.GetComponent<Flag>().SetWorker(this.gameObject);
                SetTarget(hit.collider.gameObject);
                if(resource == null || hit.collider.gameObject.tag == "Home")
                    MoveTo(hit.collider.gameObject);
            }
        }
        if (move_to != null)
            transform.position = Vector3.MoveTowards(new Vector3(transform.position.x, transform.position.y, -1f), move_to.transform.position, speed * Time.deltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (target_flag != null)
        {
            if(collision.gameObject.transform.position == target_flag.transform.position)
            {
                if(resource == null)
                {
                    if(home.GetComponent<BoxCollider2D>().bounds.Contains(new Vector3(target_flag.transform.position.x, target_flag.transform.position.y,home.transform.position.z)))
                    {
                        Destroy(target_flag);
                    }
                    else if (send_to_resource && target.GetComponent<Outcrop>() && target.tag == "Buildable")
                    {
                        if(this.amount > 0)
                            target.GetComponent<Outcrop>().addResource(this.amount);
                        Requested_resource = target.GetComponent<Outcrop>().getNeededResource();
                        Requested_amount = target.GetComponent<Outcrop>().stillNeeded();
                        StartCoroutine("goHome");
                    }
                    else
                    {
                        //Amount of resources worker is carrying right now
                        this.amount = target.GetComponent<Resource>().extractResource(this.max_amount);
                        //Gives target resource to resource variable
                        this.resource = this.target.GetComponent<Resource>();
                        StartCoroutine("goHome");
                    }

                    
                }
                else
                {
                    StartCoroutine("goHome");
                }               
            }
            else
            {
                if (collision.gameObject.GetComponent<BoxCollider2D>().bounds.Contains(new Vector3(home.transform.position.x, home.transform.position.y, collision.gameObject.transform.position.z)))
                {
                    if (target.GetComponent<Outcrop>() && this.Requested_resource != null)
                    {
                        if(this.Requested_amount < this.max_amount)
                            this.amount = home.GetComponent<City>().UseResource(this.Requested_resource, this.Requested_amount);
                        else
                            this.amount = home.GetComponent<City>().UseResource(this.Requested_resource, this.max_amount);
                    }
                    else
                    {

                        //resets amount and resource variables
                        collision.gameObject.GetComponent<City>().AddResource(this.resource, this.amount);
                        this.amount = 0;
                        this.resource = null;
                    }

                    MoveTo(this.target);
                }
            }
        }
    }
    IEnumerator goHome()
    {
        yield return new WaitForSeconds(4);
        if(target == null)
            DestroyImmediate(target_flag);
        MoveTo(home);
    }

}
