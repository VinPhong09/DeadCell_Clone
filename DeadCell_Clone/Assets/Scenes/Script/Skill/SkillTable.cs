using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillTable : MonoBehaviour
{
    [SerializeField] Character c;
    [SerializeField] Transform parent;
    public SkillSlot[] skillTable;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnValidate()
    {
        skillTable = parent.GetComponentsInChildren<SkillSlot>();
        c = FindObjectOfType<Character>();
    }
}
