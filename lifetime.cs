using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lifetime : MonoBehaviour
{
    public float life;
    private float current;

    public Bacterium bact;
    // Start is called before the first frame update
    void Start()
    {
        bact = GameObject.FindGameObjectWithTag("GameController").GetComponent<Bacterium>();

        current = 0;
    }

    // Update is called once per frame
    void Update()
    {
        current += Time.deltaTime;
        if (current >= life)
        {
            bact.enemy.Remove(gameObject);
            Destroy(gameObject);
        }
    }
}
