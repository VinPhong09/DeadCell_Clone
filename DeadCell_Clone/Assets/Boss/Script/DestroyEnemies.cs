using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyEnemies : MonoBehaviour
{
    public GameObject ene;
    public int countChild;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        countChild = ene.transform.childCount;
        if (countChild == 0 )
        {
            Destroy(this.gameObject);
        }
    }
}
