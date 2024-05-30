using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour
{
    [SerializeField] GameObject game;
    // Start is called before the first frame update
    private void OnValidate()
    {
        
    }
    void Start()
    {
        game = FindObjectOfType<PlayerStatus>().gameObject;
        this.GetComponent<Cinemachine.CinemachineVirtualCamera>().Follow = game.transform;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
