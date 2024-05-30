using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.TextCore.Text;

public class WakeUpBoss : MonoBehaviour
{
    public Door door;
    public GameObject boss;
    [SerializeField] private bool isInRange;
    // Start is called before the first frame update
    private void OnValidate()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (boss == null) { return; }
        if (!door.doorOpened)
        {
            boss.SetActive(false);
        }
        else
        {
            boss.SetActive(true);
        }

    }
    
}
