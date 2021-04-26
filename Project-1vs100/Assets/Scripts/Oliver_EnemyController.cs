using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oliver_EnemyController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator = null;
    private GameObject spawnPoint;
    public GameObject deathExplosionEffect;
    public GameObject onClickExplosionEffect;
    private Rigidbody[] ragdollBodies;
    private Collider[] ragdollColliders;
    private float speed = 2.0f;
    private GameObject castle;
    public bool isWalking;
    public float delay = 4.9f;
    private float countdown;
    private bool hasExploded;
    public bool hasDied;
    private float health = 100f;
    public bool isPoisoned;
    private float poisonDmg = 33.4f;

    private void Start()
    {
        ragdollBodies = GetComponentsInChildren<Rigidbody>();
        ragdollColliders = GetComponentsInChildren<Collider>();
        ToggleRagdoll(false);
        isWalking = true;
        countdown = delay;
        spawnPoint = GameObject.Find("EnemySpawner");
        castle = GameObject.FindGameObjectWithTag("Target");
        hasDied = false;
        isPoisoned = false;
    }

    public void ToggleRagdoll(bool state)
    {
        animator.enabled = !state;

        foreach(Rigidbody rb in ragdollBodies)
        {
            rb.isKinematic = !state;
        }

        foreach (Collider collider in ragdollColliders)
        {
            if(collider.isTrigger != true)
            {
                collider.enabled = state;
            }
        }
    }

    private void deathExplosion()
    {
        Instantiate(deathExplosionEffect, transform.position, transform.rotation);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Boulder")
        {
            isWalking = false;
            ToggleRagdoll(true);
            hasDied = true;
        }
    }

    public void Walk(bool isWalking)
    {
        if(isWalking == true)
        {
            float step = speed * Time.deltaTime;
            Vector3 target = new Vector3(castle.transform.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, target, step);
        }
    }

    private void Poisoned()
    {
        if(isPoisoned == true)
        {
            health -= poisonDmg * Time.deltaTime;
            if (health <= 0f)
            {
                isWalking = false;
                ToggleRagdoll(true);
                hasDied = true;
                Death();
            }
        }
    }

    private void Death()
    {
        if (hasDied == true)
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0f && hasExploded == false)
            {
                deathExplosion();
                spawnPoint.GetComponent<Thea_EnemySpawner>().enemiesRemaining--;
                Destroy(gameObject);
                hasExploded = true;
            }
        }
    }

    private void Update()
    {
        Walk(isWalking);
        Poisoned();
        Death();
    }
}