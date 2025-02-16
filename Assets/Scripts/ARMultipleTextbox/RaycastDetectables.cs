using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RaycastDetectables : MonoBehaviour
{
    [SerializeField] private LayerMask layerToMask;
    [SerializeField] private LayerMask worldSpaceUILayer;
    private Ray ray;
    private RaycastHit hit;

    [SerializeField] private GameObject textboxPrefab;
    [SerializeField] private TextMeshProUGUI uiText;

    [SerializeField] private GameObject hint;

    // Start is called before the first frame update
    void Start()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.ARMultipleTextbox.ON_SHOW_HINTS, DisplayHints);
        EventBroadcaster.Instance.AddObserver(EventNames.ARMultipleTextbox.ON_CLOSE_TEXTBOX, OnCloseTextbox);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 2000f, layerToMask) && (1 << hit.collider.gameObject.layer) != worldSpaceUILayer.value)
            {
                spawnTextbox();
            }
        }
    }

    private void OnCloseTextbox()
    {
        Debug.Log("OnCloseTextbox");
        textboxPrefab.SetActive(false);
    }

    private void spawnTextbox()
    {
        textboxPrefab.transform.position = (hit.collider.gameObject.transform.position + Camera.main.transform.position) * 0.5f;
        textboxPrefab.transform.LookAt(hit.collider.gameObject.transform);
        uiText.text = hit.collider.gameObject.GetComponent<Detectables>().GetText();
        textboxPrefab.SetActive(true);
    }

    private void DisplayHints()
    {
        List<Collider> collidersHit = new List<Collider>();
        foreach(Transform detectable in transform.GetComponentInChildren<Transform>())
        {
            ray = new Ray(Camera.main.transform.position, (detectable.position - Camera.main.transform.position).normalized);
            if (Physics.Raycast(ray, out hit, 2000f, layerToMask) && (1 << hit.collider.gameObject.layer) != worldSpaceUILayer.value)
            {
                if (!collidersHit.Contains(hit.collider))
                {
                    collidersHit.Add(hit.collider);
                    Instantiate(hint, hit.collider.ClosestPoint(Camera.main.transform.position), hit.collider.transform.rotation);
                }
            }
        }
    }
}
