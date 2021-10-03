using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//NOTE I BARELY USED THIS SCRIPT GOTO ENEMY SCRIPT INSTEAD

public class enemyBacteria : MonoBehaviour
{
    public float delay;
    public int abilityCount;

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
    // Start is called before the first frame update
    void Start()
    {
        abilityD = true;
        StartCoroutine(ability());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator ability()
    {
        if (abilityD == false)
        {
            abilityCount = Random.Range(0, 8);
        }
        else
        {
            abilityCount = 1;
            abilityD = false;
        }
        yield return new WaitForSeconds(Random.Range(delay, delay + 3));
        if (abilityCount == 1 || abilityCount >= 6)
        {
            for (int i = 0; i < numberOfSplits; i++)
            {
                Instantiate(split, transform.position + new Vector3(0, 0.3f, 0), Quaternion.Euler(0, 0, Random.Range(0, 360)));
            }
            delay = 18;
        }
        if (abilityCount == 2)
        {
            GameObject effect = (GameObject)Instantiate(slashEffect, transform.position + new Vector3(0, 0, -8), Quaternion.identity);
            Destroy(effect, 1f);

            for (int i = 0; i < numberOfDismantles; i++)
            {
                Instantiate(dismantleObject, transform.position, Quaternion.Euler(0, 0, Random.Range(0, 360))); ;
            }
            Destroy(gameObject, 0.4f);
            delay = 30f;
        }
        if (abilityCount == 3)
        {
            transform.localScale += new Vector3(0.5f, 0.5f, 0);
            delay = 12f;
        }
        if (abilityCount == 4)
        {
            float increment = transform.localScale.x / flowNumber;
            for (int i = 0; i < flowNumber; i++)
            {
                GameObject obj = (GameObject)Instantiate(flowObject, transform.position, transform.rotation);
                obj.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, 5), ForceMode2D.Impulse);
                yield return new WaitForSeconds(flowDelay);
                transform.localScale = new Vector3(transform.localScale.x - increment, transform.localScale.y - increment, transform.localScale.x);
            }
            Destroy(gameObject);
            delay = 24f;
        }
        
        StartCoroutine(ability());
    }
}
