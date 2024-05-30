using QuanVo.CharacterStat;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

public class PlayerStatus : MonoBehaviour
{
    // Start is called before the first frame update
    public static PlayerStatus Instance;
    [SerializeField] GameObject dieDialog;
    [SerializeField] Transform spawn;
    public MapLevel mapLevel;
    public int HP;
    public int MP;
    public float dameSkill;
    public bool canUseHP;
    public bool canUseMP;
    public bool canBlock;
    public bool canSkill;
    public float shell;
    public int timeDie;
    public bool die;
    public int curAge;
    public int maxAge = 100;
    public int totalDie;
    public Character c;
    public int Defense;
    public int randomNum;
    public int maxHP;
    public int maxMP;
    public bool openShell;
    [SerializeField] LoadingMap map;
    [SerializeField] GameObject test;
    public Button reNewBtn;
    public TMP_Text age;
    public Text HPText;
    public Text MPText;
    public Button HP_Potion;
    public Button MP_Potion;
    public LeafController facingLeaf;
    public FireCharController facingChar;
    public WindCharController windChar;
    public MentalCharController mentalChar;
    public float facing;
    private void OnValidate()
    {
        c = FindObjectOfType<Character>();
        HP = GetHP();
        MP = GetMP();
    }
    private void Start()
    {

        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }

        //DontDestroyOnLoad(this.gameObject);
        Instance = this;
        facingLeaf = GetComponent<LeafController>();
        facingChar = GetComponent<FireCharController>();
        windChar = GetComponent<WindCharController>();
        mentalChar = GetComponent<MentalCharController>();

    }
    private void Update()
    {
        maxHP = GetHP();
        maxMP = GetMP();

        Die();
        GetDef();
        age.text = curAge.ToString();
        /*reNew();
        newGame();*/
        

        if (HP >= maxHP)
        {
            canUseHP = false;

            HP = maxHP;
        }
        else
        {
            canUseHP = true;

        }
        if (MP >= maxMP)
        {
            canUseMP = false;
            MP = maxMP;
        }
        else
        {
            canUseMP = true;
        }
        if (MP <= 0)
        {
            MP = 0;
        }
        HP_Potion.interactable = canUseHP;
        MP_Potion.interactable = canUseMP;
        spawn = FindObjectOfType<Spawn>().transform;

        mapLevel = FindObjectOfType<TypeMap>().mapLevel;
        if (facingLeaf != null)
        {
            facing = facingLeaf.facing;
        }
        else if (facingChar != null)
        {
            facing = facingChar.facing;
        }
        else if (windChar != null)
        {
            facing = windChar.facing;
        }
        else
        {
            facing = mentalChar.facing;
        }
        GetShell();
        
    }
    public float GetShell()
    {
        if (openShell == true && MP >= 0)
        {
            return shell = MP;
        }
        else return shell = 0;
    }
    public int GetHP()
    {
        return (int)c.HP.Value * 100;
    }
    public int GetMP()
    {
        return (int)c.MP.Value * 50;
    }
    public int GetDef()
    {
        return Defense = (int)c.DEF.Value * 10;
    }
    public void IncreaseHealth(int value)
    {
        Debug.Log("Run");
        HP += value;
    }
    public void IncreaseMana(int value)
    {
        MP += value;
    }
    public void IncreaseDef(int value)
    {
        Defense += value;
    }
    public void TakeDamage(int damage)
    {
        //HP -= damage;
        if (openShell)
        {
            if ((damage - (int)shell) < 0)
            {
                MP = MP - damage + Defense;
            }
            else
            {

                HP = HP - damage + Convert.ToInt32(shell) + Defense;
                MP = 1;
            }
        }
        else
        {
            HP = HP - damage + Defense;
        }

        StartCoroutine(DamageAnimation());

    }
    public void TakeTrueDame(int trueDame)
    {
        HP -= trueDame;
        StartCoroutine(DamageAnimation());
    }
    public void UseSkill(int mana)
    {
        if (MP >= mana)
        {
            MP -= mana;
        }
        else
        {
            MP = 0;
        }
    }
    public void Die()
    {
        if (HP <= 0)
        {
            Time.timeScale = 0f;

            die = true;
            dieDialog.SetActive(true);

            if (canRenew())
            {
                reNewBtn.interactable = true;

                return;
                //SceneManager.SetActiveScene(SceneManager.GetSceneByName("DieScene"));
            }
            else
            {
                reNewBtn.interactable = false;
            }
        }

    }
    public bool canRenew()
    {
        return curAge < maxAge;
    }
    public void reNew()
    {
        //if (isRenew)
        {
            Time.timeScale = 1f;
            Debug.Log(1);
            timeDie++;
            curAge += 5 * timeDie;
            totalDie = curAge;
            this.transform.position = this.transform.position;
            OutStatWhenDie(c);
            //die = true;
            HP = GetHP();
            MP = GetMP();
            die = false;
            dieDialog.SetActive(false);

            //isRenew = false;
        }
    }

    public void newGame()
    {
        //if (isNewGame)
        {
            Time.timeScale = 1;
            curAge = 20;
            AddStatWhenNewGame(c);
            HP = GetHP();
            MP = GetMP();
            Defense = GetDef();
            timeDie = 0;
            totalDie = 0;
            die = false;
            //c.gameObject.SetActive(false);
            dieDialog.SetActive(false);
            //isNewGame = false;
        }

    }
    public void OutStatWhenDie(Character c)
    {
        c.HP.AddModifier(new StatModifier(-c.HP.BaseValue * (curAge - 20) * 0.007f, StatModType.Flat, this));
        Debug.Log(-c.HP.BaseValue * (curAge - 20) * 0.007f);
        c.MP.AddModifier(new StatModifier(-c.MP.BaseValue * (curAge - 20) * 0.007f, StatModType.Flat, this));
        c.DA.AddModifier(new StatModifier(-c.DA.BaseValue * (curAge - 20) * 0.007f, StatModType.Flat, this));
        c.DEF.AddModifier(new StatModifier(-c.DEF.BaseValue * (curAge - 20) * 0.007f, StatModType.Flat, this));
        c.ArP.AddModifier(new StatModifier(-c.ArP.BaseValue * (curAge - 20) * 0.007f, StatModType.Flat, this));
        c.LUK.AddModifier(new StatModifier(-c.LUK.BaseValue * (curAge - 20) * 0.007f, StatModType.Flat, this));
        c.UpdateStatValues();
        //GetHP();
    }
    public void AddStatWhenNewGame(Character c)
    {
        c.HP.AddModifier(new StatModifier(c.HP.BaseValue * (totalDie - 15) * 0.007f, StatModType.Flat, this));
        c.MP.AddModifier(new StatModifier(c.MP.BaseValue * (totalDie - 15) * 0.007f, StatModType.Flat, this));
        c.DA.AddModifier(new StatModifier(c.DA.BaseValue * (totalDie - 15) * 0.007f, StatModType.Flat, this));
        c.DEF.AddModifier(new StatModifier(c.DEF.BaseValue * (totalDie - 15) * 0.007f, StatModType.Flat, this));
        c.ArP.AddModifier(new StatModifier(c.ArP.BaseValue * (totalDie - 15) * 0.007f, StatModType.Flat, this));
        c.LUK.AddModifier(new StatModifier(c.LUK.BaseValue * (totalDie - 15) * 0.007f, StatModType.Flat, this));
        c.UpdateStatValues();
    }
    IEnumerator DamageAnimation()
    {
        SpriteRenderer[] srs = GetComponentsInChildren<SpriteRenderer>();

        for (int i = 0; i < 3; i++)
        {
            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 0;
                sr.color = c;
            }

            yield return new WaitForSeconds(.1f);

            foreach (SpriteRenderer sr in srs)
            {
                Color c = sr.color;
                c.a = 1;
                sr.color = c;
            }

            yield return new WaitForSeconds(.1f);
        }
    }
}
