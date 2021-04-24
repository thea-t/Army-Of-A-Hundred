using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Thea_UIController : MonoBehaviour
{
    [SerializeField] Image[] spellImages; 


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
                tempColor.a = 0.4f;
            }
            spellImages[i].color = tempColor;
        }
    }

}
