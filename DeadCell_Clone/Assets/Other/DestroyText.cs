using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyText : MonoBehaviour
{
    // Start is called before the first frame update
    public float timeOut = 2f;
    void Start()
    {
        //Destroy(this.gameObject, timeOut);
        StartCoroutine(ResultOut());
    }
   
    // Update is called once per frame
    IEnumerator ResultOut()
    {
        yield return new WaitForSeconds(timeOut);
        if (this.gameObject.activeSelf)
        {
            this.gameObject.SetActive(false);
        }
        
    }
}
