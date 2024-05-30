using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableMove : MonoBehaviour
{
    // Start is called before the first frame update
   public void Move()
    {
        LeafController.disMove = false;
        WindCharController.disMove = false;
        FireCharController.disMove = false;
        MentalCharController.disMove = false;
    }


}
