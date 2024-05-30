using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine;
using UnityEngine.UI;

public class AbilityFire : MonoBehaviour
{
    public Animator m;
    [Header("Skill1")]
    public Image abilityI1;
    public float cooldown1 = 3f;
    bool isCooldown = false;

    [Header("Skill2")]
    public Image abilityI2;
    public float cooldown2 = 3f;
    bool isCooldown2 = false;

    [Header("Skill3")]
    public Image abilityI3;
    public float cooldown3 = 3f;
    bool isCooldown3 = false;

    private void Start()
    {
        abilityI1.fillAmount = 1;
    }
    private void Update()
    {

        ability1();
        Skill1();
        ability2();
        Skill2();
        ability3();
        Skill3();
    }
    private void OnValidate()
    {
        m = FindObjectOfType<FireCharController>().GetComponent<Animator>();
    }
    public void CheckSkill1()
    {

    }
    public void Skill1()
    {
        //Skill1
        if (isCooldown == true)
        {
            abilityI1.fillAmount += 1 / cooldown1 * Time.deltaTime;
        }
        if (abilityI1.fillAmount == 1)
        {
            isCooldown = false;
        }
    }
    public void Skill2()
    {
        //Skill2
        if (isCooldown2 == true)
        {
            abilityI2.fillAmount += 1 / cooldown2 * Time.deltaTime;
        }
        if (abilityI2.fillAmount == 1)
        {
            isCooldown2 = false;
        }
    }
    public void Skill3()
    {
        //Skill3
        if (isCooldown3 == true)
        {
            abilityI3.fillAmount += 1 / cooldown3 * Time.deltaTime;
        }
        if (abilityI3.fillAmount == 1)
        {
            isCooldown3 = false;
        }
    }
    public void ability1()
    {
        if (isCooldown == false)
        {
            Animator animator = m.GetComponent<Animator>();
            AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
            if (state.IsName("Roll") && state.normalizedTime < 1.0f)
            {
                isCooldown = true;
                abilityI1.fillAmount = 0;
            }
        }
    }
    public void ability2()
    {
        if (isCooldown2 == true)
        {

        }
        else
        {
            Animator animator = m.GetComponent<Animator>();
            AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
            if (state.IsName("Air_atk") && state.normalizedTime < 1.0f)
            {
                isCooldown2 = true;
                abilityI2.fillAmount = 0;
            }
        }
    }
    public void ability3()
    {
        if (isCooldown3 == true)
        {

        }
        else
        {
            Animator animator = m.GetComponent<Animator>();
            AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);
            if (state.IsName("Sp_Atk") && state.normalizedTime < 1.0f)
            {
                isCooldown3 = true;
                abilityI3.fillAmount = 0;
            }
        }
    }
}
