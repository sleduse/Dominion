using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class Bacterium : MonoBehaviour
{
    public float target;
    public float current;
    public Slider slider;
    public Slider targetSlider;
    public TextMeshProUGUI tmp, enemyTMP;


    public GameOver gameOver;

    private float time;

    public bool checkLose;

    private GameObject[] players;
    public List<GameObject> bacterium = new List<GameObject>();

    private GameObject[] enemies;
    public List<GameObject> enemy = new List<GameObject>();

    public static bool over;

    public bool boi;

    public float minValue;
    public float maxValue;

    public GameObject playerPos, enemyPos;
    public GameObject playerInstance, enemyInstance;

    public float enemyNumber, playerNumber;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(targetChange());
        enemyNumber = 0;
        playerNumber = 0;
        over = false;
        checkLose = false;
        StartCoroutine(check());
        current = 0;
        slider.maxValue = target;
        slider.minValue = 0;
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            bacterium.Add(player);
        }
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject enemya in enemies)
        {
            enemy.Add(enemya);

        }
        targetSlider.minValue = slider.minValue;
        targetSlider.maxValue = slider.maxValue;
    }

    // Update is called once per frame
    void Update()
    {
        slider.maxValue = enemy.Count + bacterium.Count;

        if (!over)
        {
            current = bacterium.Count;
            time += Time.deltaTime;
            if (time >= 0)
            {
                enemyd();
                player();
                time = 0;
            }
            if (current >= target)
            {
                gameOver.win();
                over = true;
                //winLevel
            }
        }
        if (checkLose)
        {
            if(bacterium.Count < (bacterium.Count + enemy.Count) / 10)
            {
                Debug.Log("LOST");
                gameOver.anim();
                over = true;
            }
            if (enemy.Count < (bacterium.Count + enemy.Count) / 10)
            {
                gameOver.win();
                over = true;
            }
        }
        minValue = targetSlider.value - 20f;
        maxValue = targetSlider.value + 20f;
   
    }
    void player()
    {
        tmp.text = bacterium.Count.ToString();
        //ebug.Log(current);
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            if (!bacterium.Contains(player))
            {
                bacterium.Add(player);

            }
        }
        slider.value = bacterium.Count;

    }

    void enemyd()
    {
        enemyTMP.text = enemy.Count.ToString();
        enemies = GameObject.FindGameObjectsWithTag("enemy");
        foreach (GameObject enemya in enemies)
        {
            if (!enemy.Contains(enemya))
            {
                enemy.Add(enemya);

            }
        }
    }


    IEnumerator check()
    {
        yield return new WaitForSeconds(10f);
        checkLose = true;
    }

    IEnumerator targetChange()
    {
        yield return new WaitForSeconds(Random.Range(10f, 24f));
        boi = false;
        targetSlider.value = Random.Range(targetSlider.minValue, targetSlider.maxValue);
        StartCoroutine(targetChange());

    }
 

    /*void spawn()
    {
        List<GameObject> objs = new List<GameObject>();
        objs = bacterium;
        List<GameObject> EnemyOBJS = new List<GameObject>();
        EnemyOBJS = enemy;
        foreach (GameObject bact in objs)
        {
            //Instantiate(playerInstance, playerPos.transform);

        }
        foreach (GameObject bact in EnemyOBJS)
        {
            //Instantiate(enemyInstance, enemyPos.transform);
            

        }
    }*/
}
