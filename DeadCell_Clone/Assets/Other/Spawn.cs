using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField]public GameObject panelTele;
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerStatus>().gameObject;
        player.transform.position = this.transform.position;
        panelTele = FindObjectOfType<Panel>().gameObject;
        panelTele.SetActive(true);
        StartCoroutine(closePanel());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator closePanel()
    {
        yield return new WaitForSeconds(0.5f);
        panelTele.SetActive(false);
    }
}
