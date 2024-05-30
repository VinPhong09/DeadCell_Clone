using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnterGame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject tutorial;
    public SpriteRenderer menu;
    public int countEnter;
    void Start()
    {
        countEnter = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (countEnter == 1)
            {
                menu.sortingOrder=2;
                transform.position = new Vector3(transform.position.x,transform.position.y,0);
                tutorial.SetActive(true);
                countEnter = 2;
            }
            else
            {
                SceneManager.LoadScene("Game");
            }
        }

    }

}
