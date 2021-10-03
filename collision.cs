using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class collision : MonoBehaviour
{
    public Bacterium bact;

    public AudioSource asource;
    //public GameObject icon;
    //public Transform pos;

    //private GameObject instance;
   // public GameObject[] enemies;
    //private float time;

    //public bool isBIG = false;
    // public bacteria bacts;
    void Start()
    {
        bact = GameObject.FindGameObjectWithTag("GameController").GetComponent<Bacterium>();

    }

    private void Update()
    {
       
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("enemy"))
        {
            
            if (collision.gameObject.transform.localScale.x > transform.localScale.x)
            {
                
                asource.Play();

                //Debug.Log("destory");
                bact.bacterium.Remove(gameObject);
                //bacts.bacteriums.Remove(gameObject);
                //cam.targets.Remove(gameObject.transform);
                collision.transform.localScale -= new Vector3(collision.transform.localScale.x / 15, collision.transform.localScale.y / 15, collision.transform.localScale.x);
                //Destroy(instance);
                Destroy(gameObject);
            }
            else if (collision.gameObject.transform.localScale.x < transform.localScale.x)
            {
                asource.Play();

                bact.enemy.Remove(collision.gameObject);
                //Debug.Log("ur ded");
                Destroy(collision.gameObject);
                //Destroy(enemies[0]);
                transform.localScale -= new Vector3(transform.localScale.x/15, transform.localScale.y/15, transform.localScale.x);
            }
        }
    }

    
}
