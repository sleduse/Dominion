using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bacteria : MonoBehaviour
{
    [Header("References")]
    public Transform target;
    public SpriteRenderer rend;
    public GameObject[] players;
    public List<GameObject> bacteriums = new List<GameObject>();
    public Slider slider;
    public float dismantleMana, flowMana, impetusMana, enlargeMana, duplicateMana, forceMana, forceModeMana;
    public AudioSource audio;

    [Header("Optimisation")]
    public float time;

    [Header("Duplicate")]
    public bool canDuplicate = true;
    public GameObject split;
    public int numberOfSplits;

    [Header("Dismantle")]
    public bool canDismantle = false;
    public GameObject dismantleObject;
    public int numberOfDismantles;
    public GameObject slashEffect;

    [Header("Enlarge")]
    public bool canEnlarge = false;
    public float enlargeAmount;

    [Header("Flow")]
    public bool canFlow = false;
    public float flowNumber;
    public GameObject flowObject;
    public float flowDelay;

    [Header("Impetus")]
    public bool canImpetus = false;
    public float impetusForce;
    public float impetusRadius;

    [Header("Force")]
    public bool canForce = false;
    public float forceAmount;

    [Header("ForceMode")]
    public float forceModeAmount;
    public bool canForceMode = false;
    // Start is called before the first frame update
    void Start()
    {

        transform.localScale = new Vector3(1, 1, transform.localScale.z);
        slider = GameObject.FindGameObjectWithTag("slider").GetComponent<Slider>();
        for (int i = 0; i < 5; i++)
        {
            rend.color = Color.white;
        }
        /*
        canDismantle = false;
        canDuplicate = false;
        canFlow = false;
        canEnlarge = false;
        canImpetus = false;
        */
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.localScale += new Vector3(0.00003f, 0.00003f, 0);

        time += Time.deltaTime;
        if (time >= 1f)
        {
            players = GameObject.FindGameObjectsWithTag("Player");

            player();
            time = 0;

        }
        //Debug.Log("lo");
      
    }
    void player()
    {
        foreach (GameObject player in players)
        {
            if (!bacteriums.Contains(player))
            {
                bacteriums.Add(player);
                
            }
        }
    }
  
    void OnMouseDown()
    {
        Debug.Log("mousedwown");
        if (canForce)
        {
            if (slider.value >= forceMana)
            {
                forceThing();
                //canForce = false;
                
                slider.value -= forceMana;
            }
        }
        if (canDuplicate == true)
        {
            if(slider.value >= duplicateMana)
            {
                spawn();
                //canDuplicate = false;
                
                slider.value -= duplicateMana;

            }

        }
        if (canDismantle == true)
        {
            if(slider.value >= dismantleMana)
            {
                
                dismantle();
                //canDismantle = false;
                
                slider.value -= dismantleMana;

            }

        }
        if (canEnlarge == true)
        {
            if(slider.value >= enlargeMana)
            {
                
                Enlarge();
                //canEnlarge = false;
                
                slider.value -= enlargeMana;

            }
        }
        if (canFlow ==  true)
        {
            if(slider.value >= flowMana)
            {
                
                StartCoroutine(Flow());
                //canFlow = false;
                
                slider.value -= flowMana;

            }

        }
        if (canImpetus)
        {
            if(slider.value >= impetusMana)
            {

                Impetus();
                //canImpetus = false;
                
                slider.value -= impetusMana;

            }

        }
        if (canForceMode)
        {
            if (slider.value >= forceModeMana)
            {

                forceModeb();
                slider.value -= forceModeMana;

            }
        }
        
        //split
    }

    private void OnMouseOver()
    {
        Debug.Log("heyey");
        rend.color = Color.grey;
    }

    private void OnMouseExit()
    {
        
        rend.color = Color.white;
    }

    void forceThing()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.AddForce(Vector2.right * forceAmount);
    }
    
    void forceModeb()
    {
        Debug.Log("forcemode");
        foreach (GameObject bact in bacteriums)
        {    
            if(bact != null)
            {
                Rigidbody2D rb = bact.gameObject.GetComponent<Rigidbody2D>();
                rb.AddForce(Vector2.right * forceModeAmount);
            }
            
        }
    }


    IEnumerator audioPlayer(int amount, float delay)
    {
        for (int i = 0; i < amount; i++)
        {
            audio.Play();
            yield return new WaitForSeconds(delay);
        }
    }

    void spawn()
    {
        for (int i = 0; i < numberOfSplits; i++)
        {
            StartCoroutine(audioPlayer(numberOfSplits, 0.1f));
            Instantiate(split, target.position + new Vector3(0, 0.3f, 0), Quaternion.Euler(0, 0, Random.Range(0, 360)));
        }
        
    }


    void dismantle()
    {
       
        GameObject effect = (GameObject)Instantiate(slashEffect, transform.position + new Vector3(0, 0, -8), Quaternion.identity);
        Destroy(effect, 0.4f);

        for (int i = 0; i < numberOfDismantles; i++)
        {
            StartCoroutine(audioPlayer(numberOfDismantles, 0.03f));


            Instantiate(dismantleObject, target.position, Quaternion.Euler(0, 0, Random.Range(0, 360))); ;
        }
        bacteriums.Remove(gameObject);
        Destroy(gameObject, 0.3f);
    }

    void Enlarge()
    {
        transform.localScale = new Vector3(transform.localScale.x * enlargeAmount, transform.localScale.y * enlargeAmount, transform.localScale.z);
    }

    IEnumerator Flow()
    {
        float increment = transform.localScale.x / flowNumber;
        for (int i = 0; i < flowNumber; i++)
        {
            audio.Play();

            GameObject obj = (GameObject)Instantiate(flowObject, transform.position, transform.rotation);
            obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
            yield return new WaitForSeconds(flowDelay);
            transform.localScale = new Vector3(transform.localScale.x - increment, transform.localScale.y - increment, transform.localScale.x);
        }

        bacteriums.Remove(gameObject);

        Destroy(gameObject);
    }

    void Impetus()
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, impetusRadius);
        foreach (Collider2D col in cols)
        {
            Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 direction = col.transform.position - transform.position;

                rb.AddForce(direction * impetusForce);
            }
        }
        //Destroy(gameObject);
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, impetusRadius);
    }

    

}
