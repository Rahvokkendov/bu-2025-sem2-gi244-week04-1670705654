using NUnit.Framework;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private GameObject[] dogPrefabs;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            float x = Random.Range(-10,10);
            int dogIndex = Random.Range(0,dogPrefabs.Length);

            if (dogPrefabs[dogIndex] != null)
            {
                Instantiate(dogPrefabs[dogIndex], new Vector3(x,0,20), Quaternion.Euler(0,180,0));
            }
            
        }

       
    }
}
