using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class level : MonoBehaviour
{
    public float seconds;
    public int index;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Load(index));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void levelLoad(int indexs)
    {
        SceneManager.LoadScene(index);
    }

    IEnumerator Load(int idnexxx)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(idnexxx);

    }

}
