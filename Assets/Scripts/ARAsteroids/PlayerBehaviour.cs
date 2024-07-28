using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerBehaviour : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI scoreUI;
    private int score = 0;

    private Ray ray;
    private RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Shoot();
        }
    }

    private void Shoot()
    {
        ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

        if (Physics.Raycast(ray, out hit) && hit.collider.gameObject.CompareTag("Asteroid"))
        {
            score += 5;
            scoreUI.text = "Score: " + score;

            hit.collider.gameObject.GetComponent<Fracture>().FractureObject();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Asteroid"))
        {
            score -= 5;
            scoreUI.text = "Score: " + score;

            Destroy(collision.gameObject);
        }

    }
}
