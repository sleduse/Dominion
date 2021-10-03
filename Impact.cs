using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Impact : MonoBehaviour
{
    public float impact;
    public GameObject impactEffect;

    public bool tagged = false;
    public string tagName;

    public AudioSource asource;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(!tagged){
            if (collision.relativeVelocity.magnitude >= impact && collision.gameObject.CompareTag(tagName))
            {
                asource.Play();
                GameObject effect = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
                Destroy(effect, 3f);
            }
        }
        if (tagged){
            if (collision.gameObject.CompareTag(tagName))
            {
                asource.Play();
                GameObject effect = (GameObject)Instantiate(impactEffect, transform.position, transform.rotation);
                Destroy(effect, 3f);
            }
        }
    }
}
