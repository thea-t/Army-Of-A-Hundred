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
    private GameObject audioManager;
    private Rigidbody[] ragdollBodies;
    private Collider[] ragdollColliders;
    private float speed = 2.0f;
    private GameObject castle;
    public bool isWalking;
    public bool isRunning;
    public float delay = 4.9f;
    private float countdown;
    private bool hasExploded;
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
        audioManager = GameObject.Find("AudioManager");
        ragdollBodies = GetComponentsInChildren<Rigidbody>();
        ragdollColliders = GetComponentsInChildren<Collider>();
        ToggleRagdoll(false);
        isWalking = true;
        countdown = delay;
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

    public void Walk()
    {
        if(isWalking == true)
        {
            audioManager.GetComponent<AudioManager>().Play("footsteps");
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
            if(isAttacking == true)
            {
                isAttacking = false;
            }
            countdown -= Time.deltaTime;
            if (countdown <= 0f && hasExploded == false)
            {
                deathExplosion();
                audioManager.GetComponent<AudioManager>().Play("deathSound");
                spawnPoint.GetComponent<Thea_EnemySpawner>().enemiesRemaining--;
                Destroy(gameObject);
                hasExploded = true;
            }
        }
    }

    private void SyncSpeedWithAnimations()
    {
        if (randomAnimation == 0)
        {
            step = speed;
        }
        if (randomAnimation == 1)
        {
            step = speed* 1.2f;
        }
        if (randomAnimation == 1)
        {
            step = speed* 1.7f;
        }
    }

    private void Update()
    {
        Walk();
        Poisoned();
        Death();
    }
}