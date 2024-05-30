using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill_effect_1 : MonoBehaviour
{
    public GameObject skill_effects;
    public GameObject effect_effects;
    public Transform player;
    private void Update()
    {
        player = FindObjectOfType<PlayerStatus>().transform;
    }
    public void Skill_effects_1()
    {
        effect_effects = Instantiate(skill_effects, player.position, Quaternion.identity);
        Destroy(effect_effects, 2f);        
    }
    
}
