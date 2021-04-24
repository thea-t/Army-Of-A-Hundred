using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Spells
{
    Fireball,
    Poison,
    Frostball
}

public class _OLDThea_Player : MonoBehaviour
{
    public Spells currentSpell;

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
