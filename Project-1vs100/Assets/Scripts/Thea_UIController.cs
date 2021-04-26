using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Thea_UIController : MonoBehaviour
{
    [SerializeField] Image[] spellImages;
    public Oliver_Player_Controller player_Controller;
    public TMP_Text availableMagicMissile;
    public TMP_Text availableFireball;
    public TMP_Text availablePoisionCloud;
    public TMP_Text availableGravitySinkHole;


    private void Start()
    {
    }

    //https://answers.unity.com/questions/1121691/how-to-modify-images-coloralpha.html
    public void SwitchToSpell(PlayerSpells spell)
    {
        for (int i = 0; i < spellImages.Length; i++)
        {
            Color tempColor;
            tempColor = spellImages[i].color;

            if (i == (int)spell)
            {
                tempColor.a =1f;
            }
            else
            {
                tempColor.a = 0.3f;
            }
            spellImages[i].color = tempColor;
        }
    }

    private void Update()
    {
        availableMagicMissile.text = player_Controller.level1SpellSlots.ToString();
        availableFireball.text = player_Controller.level2SpellSlots.ToString();
        availablePoisionCloud.text = player_Controller.level3SpellSlots.ToString();
        availableGravitySinkHole.text = player_Controller.level4SpellSlots.ToString();
    }

}
