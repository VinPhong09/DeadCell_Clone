using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeySkill : MonoBehaviour
{
    public KeyCode skillCode;
    private Button Button;
    // Start is called before the first frame update
    void Start()
    {
        Button = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(skillCode))
        {
            Button.onClick.Invoke();
        }
    }
}
