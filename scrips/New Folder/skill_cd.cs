using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player_basic_attribute;
using UnityEngine.UI;
public class skill_cd : MonoBehaviour
{
    public Image skill_a,skill_b,skill_c;
    

    private void Update()
    {
        skill_a.fillAmount = Tutorial.Skill1_up/2;
        skill_b.fillAmount = Tutorial.Skill2_up/2;
        skill_c.fillAmount = Tutorial.Skill3_up/2;
    }
    

}
