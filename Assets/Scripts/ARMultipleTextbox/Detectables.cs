using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Quaternion = UnityEngine.Quaternion;

public class Detectables : MonoBehaviour
{
    [TextArea]
    [SerializeField] private string text;
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
