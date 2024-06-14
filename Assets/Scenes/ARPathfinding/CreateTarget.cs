using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateTarget : MonoBehaviour
{
    public GameObject target;
    private GameObject targetGameObject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void InstantiateTarget()
    {
        targetGameObject=Instantiate(target, this.transform);

    }

    public void DeleteTarget()
    {
        Destroy(targetGameObject);
        targetGameObject=null;
    }
}
