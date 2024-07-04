using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Quaternion = UnityEngine.Quaternion;

public class Detectables : MonoBehaviour
{
    [SerializeField] private string text;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public string GetText()
    {
        return text;
    }
}
