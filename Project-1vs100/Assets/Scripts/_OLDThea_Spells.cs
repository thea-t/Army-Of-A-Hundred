using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _OLDThea_Spells : MonoBehaviour
{

    [SerializeField] private ParticleSystem enemyBurning;
    [SerializeField] private ParticleSystem enemyPoisoned;
    [SerializeField] private ParticleSystem enemyFrozen;

    public void OnEnemyBurning()
    {
        Instantiate(enemyBurning, transform.position, transform.rotation);
    }

    public void OnEnemyPosioned()
    {
        Instantiate(enemyPoisoned, transform.position, transform.rotation);
    }

    public void OnEnemyFrozen()
    {
        Instantiate(enemyFrozen, transform.position, transform.rotation);
       
    }
}
