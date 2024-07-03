using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PrizeTrigger : MonoBehaviour
{
    private int score=0;
    [SerializeField]
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Prize" && other.gameObject.activeInHierarchy==true)
        {
            other.gameObject.SetActive(false);
            score++;
            scoreText.text = "Score: " + score;
        }
    }
}
