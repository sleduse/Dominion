using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour
{
  
    public Slider slider;

    public Button[] buttons;
    private GameObject[] players;
    List<bacteria> bacterium = new List<bacteria>();

    [Header("Optimisation")]
    public float time;

    [Header("Abilities")]
    public bool duplicate, dismantle, enlarge, flow, impetus, force, forceMode;
    // Start is called before the first frame update
    void Start()
    {
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 1f)
        {
            boolCheck();

            player();
            time = 0;
        }
    }

    void player()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject player in players)
        {
            bacteria BOI = player.GetComponent<bacteria>();
            if (BOI != null)
            {
                bacterium.Add(player.GetComponent<bacteria>());

            }
        }
    }

    public void spend()
    {
        spendAbility();
    }
    void spendAbility()
    {
        foreach (Button button in buttons)
        {
            button.interactable = true;
        }
        gameObject.GetComponent<Button>().interactable = false;
        if (force)
        {
            foreach (bacteria bact in bacterium)
            {
                bact.canDuplicate = false;
                bact.canDismantle = false;
                bact.canEnlarge = false;
                bact.canFlow = false;
                bact.canImpetus = false;
                bact.canForce = true;
                bact.canForceMode = false;
            }

        }
        if (duplicate)
        {
            foreach (bacteria bact in bacterium)
            {
                bact.canDuplicate = true;
                bact.canDismantle = false;
                bact.canEnlarge = false;
                bact.canFlow = false;
                bact.canImpetus = false;
                bact.canForce = false;
                bact.canForceMode = false;
            }

        }
        if (dismantle)
        {
            foreach (bacteria bact in bacterium)
            {
                bact.canDuplicate = false;
                bact.canDismantle = true;
                bact.canEnlarge = false;
                bact.canFlow = false;
                bact.canImpetus = false;
                bact.canForce = false;
                bact.canForceMode = false;
            }
        }
        if (enlarge)
        {
            foreach (bacteria bact in bacterium)
            {
                bact.canDuplicate = false;
                bact.canDismantle = false;
                bact.canEnlarge = true;
                bact.canFlow = false;
                bact.canImpetus = false;
                bact.canForce = false;
                bact.canForceMode = false;
            }
        }
        if (flow)
        {
            foreach (bacteria bact in bacterium)
            {
                bact.canDuplicate = false;
                bact.canDismantle = false;
                bact.canEnlarge = false;
                bact.canFlow = true;
                bact.canImpetus = false;
                bact.canForce = false;
                bact.canForceMode = false;
            }
        }
        if (impetus)
        {
            foreach (bacteria bact in bacterium)
            {
                bact.canDuplicate = false;
                bact.canDismantle = false;
                bact.canEnlarge = false;
                bact.canFlow = false;
                bact.canImpetus = true;
                bact.canForce = false;
                bact.canForceMode = false;
            }
        }
        if (forceMode)
        {
            foreach (bacteria bact in bacterium)
            {
                bact.canDuplicate = false;
                bact.canDismantle = false;
                bact.canEnlarge = false;
                bact.canFlow = false;
                bact.canImpetus = false;
                bact.canForce = false;
                bact.canForceMode = true;
            }
        }
    }

    void boolCheck()
    {
        if (duplicate)
        {
            foreach (bacteria bact in bacterium)
            {
                if(bact.canDuplicate == false)
                {
                    gameObject.GetComponent<Button>().interactable = true;
                }
            }
            
        }
        if (dismantle)
        {
            foreach (bacteria bact in bacterium)
            {
                if (bact.canDismantle == false)
                {
                    gameObject.GetComponent<Button>().interactable = true;
                }
            }
        }
        if (enlarge)
        {
            foreach (bacteria bact in bacterium)
            {
                if (bact.canEnlarge == false)
                {
                    gameObject.GetComponent<Button>().interactable = true;
                   
                }
            }
        }
        if (flow)
        {
            foreach (bacteria bact in bacterium)
            {
                if (bact.canFlow == false)
                {
                    gameObject.GetComponent<Button>().interactable = true;
                    
                }
            }
        }
        if (impetus)
        {
            foreach (bacteria bact in bacterium)
            {
                if (bact.canImpetus == false)
                {
                    gameObject.GetComponent<Button>().interactable = true;
                    
                }
            }
        }
        if (force)
        {
            foreach (bacteria bact in bacterium)
            {
                if (bact.canForce == false)
                {
                    gameObject.GetComponent<Button>().interactable = true;

                }
            }
        }
        if (forceMode)
        {
            foreach (bacteria bact in bacterium)
            {
                if (bact.canForceMode == false)
                {
                    gameObject.GetComponent<Button>().interactable = true;

                }
            }
        }
    }
}
