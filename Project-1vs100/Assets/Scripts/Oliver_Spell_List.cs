using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oliver_Spell_List : MonoBehaviour
{

    [SerializeField] private ParticleSystem fireBallEffect;
    public float fireBallRadius = 5f;
    public float fireBallForce = 700f;
    [SerializeField] private ParticleSystem gravitySinkHoleEffect;
    public float gravitySinkHoleRadius = 5f;
    public float gravitySinkHoleForce = 700f;
    [SerializeField] private ParticleSystem posionCloud;
    public Camera mainCamera;
    public PlayerSpells currentSpell;
    private void Fireball(Vector3 position, Quaternion rotation)
    {
        Instantiate(fireBallEffect, position, rotation);

        Collider[] colliders = Physics.OverlapSphere(position, fireBallRadius);
        foreach (Collider nearbyObject in colliders)
        {
            nearbyObject.GetComponent<Oliver_RagdollToggle>().isWalking = false;
            nearbyObject.GetComponent<Oliver_RagdollToggle>().ToggleRagdoll(true);
        }

        Collider[] collidersToExplode = Physics.OverlapSphere(position, fireBallRadius);
        foreach (Collider nearbyObject in collidersToExplode)
        {
            Rigidbody rb = nearbyObject.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.AddExplosionForce(fireBallForce, position, fireBallRadius);
            }
        }
    }

    public void OnEnemyPosioned()
    {
        Instantiate(enemyPoisoned, transform.position, transform.rotation);
    }

    public void OnEnemyFrozen()
    {
        Instantiate(enemyFrozen, transform.position, transform.rotation);

    }
    private void Update()
    {
        CheckSpellKey();
    }

    void CheckSpellKey()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            currentSpell = Spells.Fireball;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            currentSpell = Spells.Poison;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            currentSpell = Spells.Frostball;
        }
    }
}
