using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hover : MonoBehaviour
{
    public GameObject hover1;
    void Start()
    {
        hover1.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnMouseOver()
    {
        hover1.SetActive(true);
    }
    private void OnMouseExit()
    {
        hover1?.SetActive(false);
    }
}
