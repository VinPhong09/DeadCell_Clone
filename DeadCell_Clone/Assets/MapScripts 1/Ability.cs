using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Ability : MonoBehaviour
{
    public Animator m;
    [Header("Skill1")]

    public Image abilityI1;
    public float cooldown1 = 3f;
    [SerializeField]bool isCooldown = false;

    [Header("Skill2")]
    public InforSkill skill2;
    public Image abilityI2;
    public float cooldown2 = 3f;
    [SerializeField] bool isCooldown2 = false;

    [Header("Skill3")]
    public InforSkill skill3;
    public Image abilityI3;
    public float cooldown3 = 3f;
    [SerializeField] bool isCooldown3 = false;

    private void Start()
    {

        cooldown2 = skill2.timeRenew;
        cooldown3 = skill3.timeRenew;
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
        //m = FindObjectOfType<Defaut>().GetComponent<Animator>();
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
            if (state.IsName("Roll") && state.normalizedTime < 0.5f)
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
            if (state.IsName("Air_Atk") && state.normalizedTime < 0.5f)
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
            if (state.IsName("Sp_Atk") && state.normalizedTime < 0.5f)
            {
                isCooldown3 = true;
                abilityI3.fillAmount = 0;
            }
        }
    }
}
