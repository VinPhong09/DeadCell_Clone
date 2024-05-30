using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Dontdestroy : MonoBehaviour
{
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        GameObject oldPlayer = GameObject.Find("Player(Clone)");

        if (oldPlayer != null)
        {
            player.transform.position = oldPlayer.transform.position;
            Destroy(oldPlayer);
        }
    }

}
