using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerSpells
{
    Fireball,
    GravitySinkHole,
    PoisonCloud
}
public class Oliver_Player_Controller : MonoBehaviour
{
    private void Start()
    {
        
    }

    private void onClickExplosion()
    {
        //Instantiate(onClickExplosionEffect, transform.position, transform.rotation);
    }

    private void OnMouseDown()
    {
        if (gameObject.tag == "Enemy")
        {
            //Spell Effect
            gameObject.GetComponent<Oliver_EnemyController>().isWalking = false;
            gameObject.GetComponent<Oliver_EnemyController>().ToggleRagdoll(true);
            var ragdollBodies = gameObject.GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody rb in ragdollBodies)
            {
                rb.AddExplosionForce(75f, transform.position, 5f, 0f, ForceMode.Impulse);
                onClickExplosion();
            }
            gameObject.GetComponent<Oliver_EnemyController>().hasDied = true;
        }
    }

    void Update()
    {
        
        RaycastHit hit;
        Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            Fireball(hit.transform.position, hit.transform.rotation);
        }
    }
}
