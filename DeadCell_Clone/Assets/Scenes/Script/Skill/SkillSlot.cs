using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSlot : MonoBehaviour
{
    public InforSkill skill;
    public Image img;
    [SerializeField] Character c;
    [SerializeField] Text resultNoti;
    [SerializeField] Text curLvl;
    [SerializeField] Text price;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnValidate()
    {
        c = FindObjectOfType<Character>();
        
    }
    // Update is called once per frame
    void Update()
    {
        skill.totalDame = skill.baseDame * (1f + (0.05f * skill.curLevel));
        img.sprite = skill.sprite;
        curLvl.text = skill.curLevel.ToString();
        price.text = skill.price.ToString();
    }
    public void Upgrade()
    {
        float randNum = Random.value;
        if (skill.CanUpgrade() && skill.price<=c.numGold)
        {
            skill.curLevel++;
            
            resultNoti.gameObject.SetActive(true);
            resultNoti.text = "Successful".ToString();
            c.numGold -= skill.price;
        }
        else
        {
            resultNoti.gameObject.SetActive(true);
            resultNoti.text = "Fail";
        }
    }
    public void ResetSkill()
    {
        skill.curLevel = 0;
    }
}
