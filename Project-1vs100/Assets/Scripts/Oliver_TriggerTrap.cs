﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oliver_TriggerTrap : MonoBehaviour
{
    [SerializeField] private Thea_UIController uIController;
    public float maxHealth = 200f;
    public float currentHealth;
    public GameObject youLose;

    void Start()
    {
        currentHealth = maxHealth;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            //animator.SetBool("drawSword", true);
            other.GetComponent<Animator>().SetBool("attack", true);
            other.GetComponent<Oliver_EnemyController>().isAttacking = true;
            other.GetComponent<Oliver_EnemyController>().isWalking = false;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other != null)
        {
            if (other.GetComponent<Oliver_EnemyController>().isAttacking == true)
            {
                currentHealth -= 1f * Time.deltaTime;
                uIController.SetHealthBarPercent(currentHealth / maxHealth);
            }
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
        if(currentHealth <= 0f)
        {
            youLose.SetActive(true);
        }
    }
}
