using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
