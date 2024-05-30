using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public enum MapLevel
{
    Map1,
    Map2,
    Map3,
    Map4,
    Map5,
    Map6,
    Map7
}

public class MapProfile : MonoBehaviour
{
    public MapLevel mapLevel;
    public bool isLocked;
    public GameObject Lock;
    public TMP_Text level;
    public float HP_value;
    public float MP_value;
    public float DA_value;
    public float DEF_value;
    public float ArP_value;
    public float LUK_value;
    public int curAge_value;
    public int maxAge_value;
    public int amountGold_value;
    public Text HP;
    public Text MP;
    public Text DA;
    public Text DEF;
    public Text ArP;
    public Text LUK;
    public Text curAge;
    public Text maxAge;
    public Text amountGold;
    [SerializeField] ItemSaveManager saveManager;
    // Start is called before the first frame update
    void Start()
    {
        level.text = mapLevel.ToString();
        saveManager = FindObjectOfType<ItemSaveManager>();
        ItemSaveManager.LoadMap(this);
    }

    // Update is called once per frame
    void Update()
    {
        if (isLocked)
        {
            Lock.SetActive(true);
        }
        else Lock.SetActive(false);
        GetProfile();
    }
    public void GetProfile()
    {
        HP.text = HP_value.ToString();
        MP.text = MP_value.ToString();
        DA.text = DA_value.ToString();
        DEF.text = DEF_value.ToString();
        ArP.text = ArP_value.ToString();
        LUK.text = LUK_value.ToString();
        curAge.text = curAge_value.ToString();
        maxAge.text = maxAge_value.ToString();
        amountGold.text = amountGold_value.ToString();
    }
    
}
