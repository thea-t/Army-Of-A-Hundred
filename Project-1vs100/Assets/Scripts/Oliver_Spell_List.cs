using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oliver_Spell_List : MonoBehaviour
{
    [SerializeField] private ParticleSystem magicMissleEffect;
    public float magicMissleRadius = 5f;
    public float magicMissleForce = 75f;
    [SerializeField] private ParticleSystem fireBallEffect;
    public float fireBallRadius = 5f;
    public float fireBallForce = 3500f;
    [SerializeField] private ParticleSystem posionCloudEffect;
    [SerializeField] private Material posionedEnemyMat;
    public float posionCloudRadius = 2f;
    [SerializeField] private ParticleSystem gravitySinkHoleEffect;
    public float gravitySinkHoleRadius = 5f;
    public float gravitySinkHoleForce = -3500f;


    public void MagicMissle(GameObject gameObject)
    {
        Instantiate(magicMissleEffect, gameObject.transform.position, gameObject.transform.rotation);
        gameObject.GetComponent<Oliver_EnemyController>().Death();
        var ragdollBodies = gameObject.transform.parent.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in ragdollBodies)
        {
            rb.AddExplosionForce(magicMissleForce, gameObject.transform.position, magicMissleRadius, 0f, ForceMode.Impulse);
        }
    }
    public void Fireball(GameObject gameObject)
    {
        Instantiate(fireBallEffect, gameObject.transform.position, gameObject.transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position, fireBallRadius, 1, QueryTriggerInteraction.Collide);
        foreach (Collider nearbyObject in colliders)
        {
            if(nearbyObject.CompareTag("Enemy"))
            {
                nearbyObject.gameObject.GetComponent<Oliver_EnemyController>().Death();
            }
        }

        Collider[] collidersToExplode = Physics.OverlapSphere(gameObject.transform.position, fireBallRadius);
        foreach (Collider nearbyObject in collidersToExplode)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(fireBallForce, gameObject.transform.position, fireBallRadius);
            }
        }
    }

    public void PoisonCloud(GameObject gameObject)
    {
        Instantiate(posionCloudEffect, gameObject.transform.position, gameObject.transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position, posionCloudRadius, 1, QueryTriggerInteraction.Collide);
        foreach (Collider nearbyObject in colliders)
        {
            if (nearbyObject.CompareTag("Enemy"))
            {
                nearbyObject.gameObject.GetComponent<Oliver_EnemyController>().isPoisoned = true;
                nearbyObject.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material = posionedEnemyMat;
            }
        }
    }

    public void GravitySinkHole(GameObject gameObject)
    {
        Instantiate(gravitySinkHoleEffect, gameObject.transform.position, gameObject.transform.rotation);
        Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position, gravitySinkHoleRadius, 1, QueryTriggerInteraction.Collide);
        foreach (Collider nearbyObject in colliders)
        {
            if (nearbyObject.CompareTag("Enemy"))
            {
                nearbyObject.gameObject.GetComponent<Oliver_EnemyController>().Death();
            }
        }

        Collider[] collidersToExplode = Physics.OverlapSphere(gameObject.transform.position, gravitySinkHoleRadius);
        foreach (Collider nearbyObject in collidersToExplode)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(gravitySinkHoleForce, gameObject.transform.position, gravitySinkHoleRadius);
            }
        }

    }
}
