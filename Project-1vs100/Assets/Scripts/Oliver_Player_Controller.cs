using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlayerSpells
{
    MagicMissle,
    Fireball,
    GravitySinkHole,
    PoisonCloud
}
public class Oliver_Player_Controller : MonoBehaviour
{
    public Camera mainCamera;
    public PlayerSpells currentSpell;
    public Oliver_Spell_List spells;

    private void Start()
    {
        
    }

    private void OnClick()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            RaycastHit hit;
            Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit))
            {
                var clickedObj = hit.transform.gameObject;
                if (clickedObj.tag == "Enemy" && currentSpell == PlayerSpells.MagicMissle)
                {
                    spells.MagicMissle(clickedObj);
                }
                if (clickedObj.tag == "Enemy" && currentSpell == PlayerSpells.Fireball)
                {
                    spells.Fireball(clickedObj);
                }
                if (clickedObj.tag == "Enemy" && currentSpell == PlayerSpells.PoisonCloud)
                {
                    spells.PoisonCloud(clickedObj);
                }
                if (clickedObj.tag == "Enemy" && currentSpell == PlayerSpells.GravitySinkHole)
                {
                    spells.GravitySinkHole(clickedObj);
                }
            }
        }
    }

    void CheckSpellKey()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            currentSpell = PlayerSpells.MagicMissle;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentSpell = PlayerSpells.Fireball;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentSpell = PlayerSpells.PoisonCloud;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentSpell = PlayerSpells.GravitySinkHole;
        }
    }

    void Update()
    {
        CheckSpellKey();
        OnClick();
    }
}
