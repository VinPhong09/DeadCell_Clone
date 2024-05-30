using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Image = UnityEngine.UI.Image;

public class ProgessBar : MonoBehaviour
{
    public Image HP_Bar;
    public Image MP_Bar;
    public int maxHP ;
    public int maxMP;
    public int currentHP;
    public int currentMP;
    [SerializeField] PlayerStatus status;
    
    private void Start()
    {
        HP_Bar.fillAmount = 1f;
        MP_Bar.fillAmount = 1f;
        status = FindObjectOfType<PlayerStatus>();

    }

    private void Update()
    {
        maxHP = status.maxHP;
        maxMP = status.maxMP;
        currentHP = status.HP;
        currentMP = status.MP;

        // chổ này code trừ máu 
        if (currentHP < 0)
        {
            currentHP = 0;
        }

        if (currentHP > maxHP)
        {
            currentHP = maxHP;
        }
        fillHP();
        fillMP();
        
    }
    public void fillHP()
    {
        float fillAmountHP = (float)currentHP / maxHP;
        HP_Bar.fillAmount = fillAmountHP;
    }
    public void fillMP()
    {
        float fillAmountMP = (float)currentMP / maxMP;
        MP_Bar.fillAmount = fillAmountMP;
    }
}
