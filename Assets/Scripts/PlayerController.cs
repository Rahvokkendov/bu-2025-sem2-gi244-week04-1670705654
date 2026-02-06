using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    public float speed = 10.0f;
    public float xRange = 10;
    private InputAction moveAction;
    private InputAction shootAction;

    private void Awake()
    {
         moveAction = InputSystem.actions.FindAction("Move");
        shootAction = InputSystem.actions.FindAction("Shoot");
    }

    // Update is called once per frame
    void Update()
    {
        
        var hInput = moveAction.ReadValue<Vector2>().x;
        transform.Translate(hInput * speed * Time.deltaTime * Vector3.right);

        if (transform.position.x < -xRange )
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        else if (transform.position.x > xRange )
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if(shootAction.triggered)
        {
            Instantiate(bulletPrefab, transform.position, Quaternion.identity); 
        }

       
        
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position, 1f);
        //Gizmos.color = Color.red;
        // Gizmos.DrawLine(transform.position, Camera.main.transform.position);
        Vector3 left = new Vector3(-xRange, transform.position.y, transform.position.z);
        Vector3 right = new Vector3(xRange, transform.position.y, transform.position.z);
        Gizmos.DrawLine(left, right);

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(left, 1f);
        Gizmos.DrawWireSphere(right, 1f);

    }
}
