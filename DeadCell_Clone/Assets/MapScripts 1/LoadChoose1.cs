using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadChoose : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Choose());
    }
    public void Loading()
    {
        SceneManager.LoadScene("Loading");
    }
    // Update is called once per frame
    IEnumerator Choose()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Map0");
    }
    public void LoadMap4()
    {
        SceneManager.LoadScene("Map4");
    }
}
