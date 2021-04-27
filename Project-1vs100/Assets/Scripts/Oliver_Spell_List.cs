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
        GameObject magicMissle = Instantiate(magicMissleEffect, gameObject.transform.position, gameObject.transform.rotation).gameObject;
        Destroy(magicMissle,3);
        gameObject.GetComponent<Oliver_EnemyController>().isWalking = false;
        gameObject.GetComponent<Oliver_EnemyController>().ToggleRagdoll(true);
        var ragdollBodies = gameObject.GetComponentsInChildren<Rigidbody>();
        foreach (Rigidbody rb in ragdollBodies)
        {
            rb.AddExplosionForce(magicMissleForce, gameObject.transform.position, magicMissleRadius, 0f, ForceMode.Impulse);
        }
        gameObject.GetComponent<Oliver_EnemyController>().hasDied = true;
    }
    public void Fireball(GameObject gameObject)
    {
        GameObject fireball = Instantiate(fireBallEffect, gameObject.transform.position, gameObject.transform.rotation).gameObject;
        Destroy(fireball, 3);
        Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position, fireBallRadius, 1, QueryTriggerInteraction.Collide);
        foreach (Collider nearbyObject in colliders)
        {
            if(nearbyObject.CompareTag("Enemy"))
            {
                Debug.Log("Enemy");
                nearbyObject.gameObject.GetComponent<Oliver_EnemyController>().isWalking = false;
                nearbyObject.gameObject.GetComponent<Oliver_EnemyController>().ToggleRagdoll(true);
                nearbyObject.gameObject.GetComponent<Oliver_EnemyController>().hasDied = true;
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
        GameObject poisonCloud = Instantiate(posionCloudEffect, gameObject.transform.position, gameObject.transform.rotation).gameObject;
        Destroy(poisonCloud,3);
        Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position, posionCloudRadius, 1, QueryTriggerInteraction.Collide);
        foreach (Collider nearbyObject in colliders)
        {
            if (nearbyObject.CompareTag("Enemy"))
            {
                Debug.Log("Enemy");
                nearbyObject.gameObject.GetComponent<Oliver_EnemyController>().isPoisoned = true;
                nearbyObject.gameObject.GetComponentInChildren<SkinnedMeshRenderer>().material = posionedEnemyMat;
            }
        }
    }

    public void GravitySinkHole(GameObject gameObject)
    {
        GameObject gravitySinkHole = Instantiate(gravitySinkHoleEffect, gameObject.transform.position, gameObject.transform.rotation).gameObject;
        Destroy(gravitySinkHole,3);
        Collider[] colliders = Physics.OverlapSphere(gameObject.transform.position, gravitySinkHoleRadius, 1, QueryTriggerInteraction.Collide);
        foreach (Collider nearbyObject in colliders)
        {
            if (nearbyObject.CompareTag("Enemy"))
            {
                Debug.Log("Enemy");
                nearbyObject.gameObject.GetComponent<Oliver_EnemyController>().isWalking = false;
                nearbyObject.gameObject.GetComponent<Oliver_EnemyController>().ToggleRagdoll(true);
                nearbyObject.gameObject.GetComponent<Oliver_EnemyController>().hasDied = true;
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
