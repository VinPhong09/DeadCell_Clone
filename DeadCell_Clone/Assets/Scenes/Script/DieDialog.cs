using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DieDialog : MonoBehaviour
{
    public PlayerStatus character;
    public bool isRenew = false;
    public bool isNewGame = false;
    [SerializeField] GameObject dieDialog;
    
    private void OnValidate()
    {
        character = FindObjectOfType<PlayerStatus>();
    }
    private void Update()
    {
        if (dieDialog.activeSelf)
        {
            Time.timeScale = 0;
        }
    }
    public void reNew()
    {
        //dieDialog.gameObject.SetActive(false);
        character.reNew();
        /*isRenew = true;
        StaticRequest.isRenew = isRenew;
        //GameObject.FindObjectOfType<PlayerStatus>().SendMessage("reNew",SendMessageOptions.RequireReceiver);
        SceneManager.LoadScene("Leaf_Scene_OutBoss");*/
    }
    public void newGame()
    {

        //GameObject.FindObjectOfType<PlayerStatus>().SendMessage("newGame");
        //
        dieDialog.gameObject.SetActive(false);
        character.newGame();
        SceneManager.LoadScene("Select_Map");
        
    }
}
