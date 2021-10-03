using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cross : MonoBehaviour
{
    public Animator anim;
    public float number0, number1;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(animCross());

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator animCross()
    {
        yield return new WaitForSeconds(Random.Range(number0, number1));
        anim.SetTrigger("jump");
        StartCoroutine(animCross());
    }
}
