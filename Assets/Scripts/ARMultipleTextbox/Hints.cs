using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using UnityEngine;

public class Hints : MonoBehaviour
{
    private Color color;

    // Start is called before the first frame update
    void Start()
    {
        color = GetComponent<Renderer>().material.color;

        StartCoroutine("Fade");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator Fade()
    {
        yield return new WaitForSecondsRealtime(1f);
        while (GetComponent<Renderer>().material.color.a > 0)
        {
            color.a -= 0.05f;
            GetComponent<Renderer>().material.color = color;
            yield return new WaitForSecondsRealtime(0.01f);
        }
        Destroy(gameObject);
    }
}
