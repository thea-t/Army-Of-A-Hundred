using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Benet_RagdollToggle : MonoBehaviour
{
    [Header("References")]
    [SerializeField] private Animator animator = null;
    public GameObject character;
    public GameObject deathExplosionEffect;
    public GameObject onClickExplosionEffect;
    private Rigidbody[] ragdollBodies;
    private Collider[] ragdollColliders;
    private float speed = 2.0f;
    //private Transform target;
    private GameObject castle;
    public bool isWalking;
    public float delay = 4.9f;
    private float countdown;
    private bool hasExploded;
    private bool hasDied;

    private void Start()
    {
        ragdollBodies = GetComponentsInChildren<Rigidbody>();
        ragdollColliders = GetComponentsInChildren<Collider>();
        ToggleRagdoll(false);
        isWalking = true;
        countdown = delay;
        castle = GameObject.FindGameObjectWithTag("Target");
        hasDied = false;
        //target = castle.transform;
    }

    public void ToggleRagdoll(bool state)
    {
        animator.enabled = !state;

        foreach (Rigidbody rb in ragdollBodies)
        {
            rb.isKinematic = !state;
        }

        foreach (Collider collider in ragdollColliders)
        {
            if (collider.isTrigger != true)
            {
                collider.enabled = state;
            }
        }
    }

    private void deathExplosion()
    {
        Instantiate(deathExplosionEffect, transform.position, transform.rotation);
    }

    private void onClickExplosion()
    {
        Instantiate(onClickExplosionEffect, transform.position, transform.rotation);
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
        if (isWalking == true)
        {
            float step = speed * Time.deltaTime;
            Vector3 target = new Vector3(castle.transform.position.x, transform.position.y, transform.position.z);
            transform.position = Vector3.MoveTowards(transform.position, target, step);
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
                Destroy(character);
                hasExploded = true;
            }
        }
    }

    private void OnMouseDown()
    {
        if (gameObject.tag == "Enemy")
        {
            isWalking = false;
            ToggleRagdoll(true);
            foreach (Rigidbody rb in ragdollBodies)
            {
                rb.AddExplosionForce(75f, transform.position, 5f, 0f, ForceMode.Impulse);
                onClickExplosion();
            }
            hasDied = true;
        }
    }

    private void Update()
    {
        Walk(isWalking);
        Death();
    }
}
