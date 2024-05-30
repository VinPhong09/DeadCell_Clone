using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnEnemy : MonoBehaviour
{
    public static RespawnEnemy Instance;
    public bool respawn;
    public GameObject boss;
    public float timeSpawn;
    // Start is called before the first frame update
    void Start()
    {
        if (Instance != null)
        {
            Destroy(this.gameObject);
            return;
        }
    }
    IEnumerator Respawn()
    {
        respawn = false;
        yield return new WaitForSeconds(1f);
        var spawner = Instantiate(boss, this.transform.position, Quaternion.identity);
        
    }
    // Update is called once per frame
    void Update()
    {
        if (respawn)
        {
            StartCoroutine(Respawn());
        }
    }
}
