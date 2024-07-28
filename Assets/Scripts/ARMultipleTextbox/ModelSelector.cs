using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ModelSelector : MonoBehaviour
{
    [SerializeField] private List<GameObject> models;
    private int selectedModel = 0;

    [SerializeField] private Text selectedModelText;
 
    // Start is called before the first frame update
    void Start()
    {
        selectedModelText.text = "Selected: Model " + selectedModel;
        models[selectedModel].SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetNewModel(int index)
    {
        models[selectedModel].SetActive(false);
        this.selectedModel = index;
        selectedModelText.text = "Selected: Model " + selectedModel;
        models[selectedModel].SetActive(true);
        EventBroadcaster.Instance.PostEvent(EventNames.ARMultipleTextbox.ON_CLOSE_TEXTBOX);
    }
}
