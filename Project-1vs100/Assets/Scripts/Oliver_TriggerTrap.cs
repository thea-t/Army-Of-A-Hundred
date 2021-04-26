﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oliver_TriggerTrap : MonoBehaviour
{
    [SerializeField] private Animator animator;

    void Start()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.tag == "Enemy")
            {
                //animator.SetBool("drawSword", true);
                other.GetComponent<Animator>().SetBool("attack", true);
                other.GetComponent<Oliver_EnemyController>().isWalking = false;
            }
    }

    private void OnTriggerExit(Collider other)
    {
            if (other.gameObject.tag == "Enemy")
            {
                other.GetComponent<Animator>().SetBool("attack", false);
                other.GetComponent<Oliver_EnemyController>().isWalking = true;
            }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
