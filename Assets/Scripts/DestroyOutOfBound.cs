using UnityEngine;

public class DestroyOutOfBound : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        if(transform.position.z < -25 )
        {
            Destroy(gameObject);
        }
        else if (transform.position.z > 25)
        {
            Destroy(gameObject);
        }
    }
}
