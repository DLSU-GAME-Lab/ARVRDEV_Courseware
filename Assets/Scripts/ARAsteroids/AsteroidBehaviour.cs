using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidBehaviour : MonoBehaviour
{
    [SerializeField] private float speed = 1f;
    private float rotationSpeed;
    private Vector3 rotationDirection = new Vector3(1, 1, 0);

    private static int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        count++;
        rotationSpeed = Random.Range(10f, 50f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, 
                                                    Camera.main.transform.position, 
                                                    speed * Time.deltaTime);

        transform.Rotate(rotationDirection * rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Player")
        {
            Destroy(gameObject);
        }
        
    }

    private void OnDestroy()
    {
        count--;
    }

    public static int GetCount() { return count; }
}
