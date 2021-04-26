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
    public int level1SpellSlots = 85;
    public int level2SpellSlots = 35;
    public int level3SpellSlots = 25;
    public int level4SpellSlots = 15;

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
                if (clickedObj.tag == "Enemy" && currentSpell == PlayerSpells.MagicMissle && level1SpellSlots > 0)
                {
                    level1SpellSlots--;
                    spells.MagicMissle(clickedObj);
                }
                if (clickedObj.tag == "Enemy" && currentSpell == PlayerSpells.Fireball && level2SpellSlots > 0)
                {
                    level2SpellSlots--;
                    spells.Fireball(clickedObj);
                }
                if (clickedObj.tag == "Enemy" && currentSpell == PlayerSpells.PoisonCloud && level3SpellSlots > 0)
                {
                    level3SpellSlots--;
                    spells.PoisonCloud(clickedObj);
                }
                if (clickedObj.tag == "Enemy" && currentSpell == PlayerSpells.GravitySinkHole && level4SpellSlots > 0)
                {
                    level4SpellSlots--;
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
            GameManager.Instance.uIController.SwitchToSpell(PlayerSpells.MagicMissle);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            currentSpell = PlayerSpells.Fireball;
            GameManager.Instance.uIController.SwitchToSpell(PlayerSpells.Fireball);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            currentSpell = PlayerSpells.PoisonCloud;
            GameManager.Instance.uIController.SwitchToSpell(PlayerSpells.PoisonCloud);
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            currentSpell = PlayerSpells.GravitySinkHole;
            GameManager.Instance.uIController.SwitchToSpell(PlayerSpells.GravitySinkHole);
        }
    }

    void Update()
    {
        CheckSpellKey();
        OnClick();
    }
}
