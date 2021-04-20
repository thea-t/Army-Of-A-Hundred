using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oliver_TriggerTrap : MonoBehaviour
{
    [SerializeField] private Animator animator;
    //private GameObject[] enemies;
    private GameObject trap;

    // Start is called before the first frame update
    void Start()
    {
        //enemies = GameObject.FindGameObjectsWithTag("Enemy");
        trap = GameObject.FindGameObjectWithTag("Trap");
    }

    private void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.tag == "Enemy")
            {
                //animator.SetBool("drawSword", true);
                other.GetComponent<Animator>().SetBool("attack", true);
                other.GetComponent<Oliver_RagdollToggle>().isWalking = false;
                trap.GetComponent<BoxCollider>().enabled = false;
            }
    }

    private void OnTriggerExit(Collider other)
    {
            if (other.gameObject.tag == "Enemy")
            {
                other.GetComponent<Animator>().SetBool("attack", false);
                other.GetComponent<Oliver_RagdollToggle>().isWalking = true;
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
