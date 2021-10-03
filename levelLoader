using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelLoader : MonoBehaviour
{
    public Animator transition;
    public float transitionTime = 1f;

    private void Start()
    {
        this.enabled = true;
        this.gameObject.SetActive(true);
    }

    public void levelLoad(int levelINdex)
    {
        StartCoroutine(loadLevel(levelINdex));
    }

    IEnumerator loadLevel(int levelIndex)
    {
        transition.SetTrigger("Start");
        Debug.Log("levelLoaded");
        yield return new WaitForSeconds(transitionTime);
        SceneManager.LoadScene(levelIndex);

    }
    // Update is called once per frame
    void Update()
    {
        
    }
} 
