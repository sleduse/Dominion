using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float delay;
    public int abilityCount;
    public Bacterium bacterium;

    [Header("Duplicate")]
    public GameObject split;
    public int numberOfSplits;

    [Header("Dismantle")]
    public GameObject dismantleObject;
    public int numberOfDismantles;
    public GameObject slashEffect;

    [Header("Enlarge")]
    public float enlargeAmount;

    [Header("Flow")]
    public float flowNumber;
    public GameObject flowObject;
    public float flowDelay;

    [Header("Impetus")]
    public float impetusForce;
    public float impetusRadius;

    public bool abilityD = true;
    public float lifetime;
    private float current;

    public bool isSpiky = false;

    public AudioSource audio;
    // Start is called before the first frame update
    void Start()
    {
        bacterium = GameObject.FindGameObjectWithTag("GameController").GetComponent<Bacterium>();
        current = 0;
        StartCoroutine(ability());
        if (!isSpiky)
            transform.localScale = new Vector3(1, 1, transform.localScale.z);
        else
            transform.localScale = new Vector3(3, 3, transform.localScale.z);
    }

    // Update is called once per frame
    void Update()
    {
        current += Time.deltaTime;
        if(current >= lifetime)
        {

            bacterium.enemy.Remove(gameObject);
            Destroy(gameObject);
        }
        foreach (GameObject obj in bacterium.enemy)
        {
            if(obj == null)
            {
                bacterium.enemy.Remove(obj);
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
    IEnumerator ability()
    {
        abilityCount = Random.Range(0, 13);
       
        yield return new WaitForSeconds(Random.Range(delay - delay/3, delay + 3));
        if(abilityCount == 12)
        {
            foreach (GameObject enem in bacterium.enemy)
            {
                if (enem != null)
                {
                    Rigidbody2D rb = enem.gameObject.GetComponent<Rigidbody2D>();
                    rb.AddForce(Vector2.left * 1000);
                }

            }
        }

        if(abilityCount == 7)
        {
            if (isSpiky)
            {
                Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, 6);
                foreach (Collider2D col in cols)
                {
                    if (col.gameObject.CompareTag("Player"))
                    {
                        Rigidbody2D rb = col.gameObject.GetComponent<Rigidbody2D>();
                        if (rb != null)
                        {
                            Vector2 direction = col.transform.position - transform.position;

                            rb.AddForce(-direction * 90);
                        }
                    }

                }
                delay = 15f;
            }
            
        }
        if (abilityCount == 1 || abilityCount == 6 || abilityCount ==7)
        {
            for (int i = 0; i < numberOfSplits; i++)
            {
                StartCoroutine(audioPlayer(numberOfSplits, 0.1f));

                Instantiate(split, transform.position + new Vector3(0, 0.3f, 0), Quaternion.Euler(0, 0, Random.Range(0, 360)));
            }
            delay = 11;
        }
        if (abilityCount == 2 || abilityCount == 11)
        {
            GameObject effect = (GameObject)Instantiate(slashEffect, transform.position + new Vector3(0, 0, -8), Quaternion.identity);
            Destroy(effect, 1f);

            for (int i = 0; i < numberOfDismantles; i++)
            {
                StartCoroutine(audioPlayer(numberOfDismantles, 0.1f));

                Instantiate(dismantleObject, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360))); ;
            }
            Destroy(gameObject, 0.4f);
            delay = 9.5f;

        }
        if (abilityCount == 3)
        {
            transform.localScale += new Vector3(0.5f, 0.5f, 0);
            delay = 6.5f;
        }
        if (abilityCount == 4 || abilityCount == 9)
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
            Destroy(gameObject);
            delay = 13;

        }
        
        StartCoroutine(ability());
    }
}
