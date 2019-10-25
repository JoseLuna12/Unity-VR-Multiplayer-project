using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spawner1;
    public GameObject spawner2;
    public GameObject spawner3;
    int spw;
    void Start()
    {
        StartCoroutine(selectInstansiator(1.3f));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        
    }

    void instansiateB(int _spw)
    {
        switch (_spw)
        {
            case 1:
                spawner1.gameObject.GetComponent<InstantsiateBird>().instansiateBirdPlease();
                Debug.Log("Spawner " + 1);
                break;
            case 2:
                spawner2.gameObject.GetComponent<InstantsiateBird>().instansiateBirdPlease();
                Debug.Log("Spawner " + 2);
                break;
            default:
                spawner3.gameObject.GetComponent<InstantsiateBird>().instansiateBirdPlease();
                Debug.Log("Spawner " + 3);
                break;
        }
    }

    public IEnumerator selectInstansiator(float velSpawn)
    {
        
        yield return new WaitForSeconds(velSpawn);
        int ran = Random.Range(1, 4);
        instansiateB(ran);
        StartCoroutine(selectInstansiator(0.6f));
    }

}
