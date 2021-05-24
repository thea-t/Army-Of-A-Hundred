using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Oliver_EnemyController : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator = null;
    private GameObject spawnPoint;
    public GameObject deathExplosionEffect;
    private Rigidbody[] ragdollBodies;
    private Collider[] ragdollColliders;
    private NavMeshAgent agent;
    private float speed = 2.0f;
    private GameObject castle;
    public bool isWalking;
    public bool isRunning;
    public bool hasDied;
    private float health = 100f;
    public bool isPoisoned;
    private float poisonDmg = 33.4f;
    private float step;
    public bool isAttacking;
    private int randomAnimation;
    private string[] walkingAnims = { "walking", "run_jogging", "run_sprinting" };

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ragdollBodies = GetComponentsInChildren<Rigidbody>();
        ragdollColliders = GetComponentsInChildren<Collider>();
        ToggleRagdoll(false);
        isWalking = true;
        spawnPoint = GameObject.Find("EnemySpawner");
        castle = GameObject.FindGameObjectWithTag("Target");
        hasDied = false;
        isPoisoned = false;
        isAttacking = false;
        
        randomAnimation = Random.Range(0, 2);
        animator.SetBool(walkingAnims[randomAnimation], true);
        SyncSpeedWithAnimations();
    }

    public void ToggleRagdoll(bool state)
    {
        animator.enabled = !state;

        foreach(Rigidbody rb in ragdollBodies)
        {
            rb.isKinematic = !state;
        }
        foreach(Collider collider in ragdollColliders)
        {
            if(collider.isTrigger != true)
            {
                collider.enabled = state;
            }
        }
    }

    private void OnDestroy()
    {
        spawnPoint.GetComponent<Thea_EnemySpawner>().enemiesRemaining--;
        Instantiate(deathExplosionEffect, transform.position, transform.rotation);
    }

    public void Walk()
    {
        if(isWalking == true)
        {
            Vector3 target = new Vector3(castle.transform.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, target, step* Time.deltaTime);
        }
    }

    private void Poisoned()
    {
        if(isPoisoned == true)
        {
            health -= poisonDmg * Time.deltaTime;
            if (health <= 0f)
            {
                Death();
            }
        }
    }

    public void Death()
    {
        isWalking = false;
        if (isAttacking == true)
        {
            isAttacking = false;
        }
        ToggleRagdoll(true);
        Destroy(gameObject, 5f);
    }

    private void SyncSpeedWithAnimations()
    {
        if (randomAnimation == 0)
        {
            step = speed;
            agent.speed = step;
        }
        if (randomAnimation == 1)
        {
            step = speed* 1.2f;
            agent.speed = step;
        }
        if (randomAnimation == 1)
        {
            step = speed* 1.7f;
            agent.speed = step;
        }
    }

    private void Update()
    {
        Walk();
        Poisoned();
    }
}