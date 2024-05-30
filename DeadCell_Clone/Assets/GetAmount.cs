using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GetAmount : MonoBehaviour
{
    [SerializeField] Character character;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    private void OnValidate()
    {
        character = FindObjectOfType<Character>();
    }
    // Update is called once per frame
    void Update()
    {
        
        setAmount();
    }
    public void setAmount()
    {
        this.GetComponent<Text>().text = character.numGold.ToString();
    }
}
