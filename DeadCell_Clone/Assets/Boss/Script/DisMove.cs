using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisMove : MonoBehaviour
{
    // Start is called before the first frame update
   public void DisMovebomb()
    {
        LeafController.disMove = true;
        WindCharController.disMove = true;
        FireCharController.disMove = true;
        MentalCharController.disMove = true;
    }
}
