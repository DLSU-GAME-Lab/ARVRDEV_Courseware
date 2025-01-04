using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PrizeTrigger : MonoBehaviour
{
    private int score=0;
    [SerializeField]
    public TextMeshProUGUI scoreText;

    // Sets an object to inactive if the object is of tag "Prize"
    // Increments the score UI element.
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
