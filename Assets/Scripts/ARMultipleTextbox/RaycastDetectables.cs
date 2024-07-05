using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.EnhancedTouch;
using EnhancedTouch = UnityEngine.InputSystem.EnhancedTouch;

public class RaycastDetectables : MonoBehaviour
{
    [SerializeField] private LayerMask layerToMask;
    private Ray ray;
    private RaycastHit hit;

    [SerializeField] private GameObject textboxPrefab;
    [SerializeField] private TextMeshProUGUI uiText;

    [SerializeField] private GameObject hint;
    private List<GameObject> hints = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        EventBroadcaster.Instance.AddObserver(EventNames.ARMultipleTextbox.ON_SHOW_HINTS, DisplayHints);
    }

    // Update is called once per frame
    void Update()
    {
        ///////////////////////////////////////////////////////////////
        //JUST FOR TESTING
        //if (Mouse.current.leftButton.wasPressedThisFrame)
        //{
        //    Debug.Log("click");
        //    ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        //    if (Physics.Raycast(ray, out hit, 2000f, layerToMask))
        //    {
        //        Debug.Log(hit.collider.gameObject.name);
        //        spawnTextbox();
        //    }
        //}
        //END OF TEST
        ///////////////////////////////////////////////////////////////
    }

    private void OnEnable()
    {
        EnhancedTouch.EnhancedTouchSupport.Enable();
        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.Touch.onFingerDown += findDetectable;
    }

    private void OnDisable()
    {
        EnhancedTouch.EnhancedTouchSupport.Disable();
        EnhancedTouch.TouchSimulation.Disable();
        EnhancedTouch.Touch.onFingerDown -= findDetectable;
    }

    private void OnDestroy()
    {
        EnhancedTouch.EnhancedTouchSupport.Disable();
        EnhancedTouch.TouchSimulation.Disable();
        EnhancedTouch.Touch.onFingerDown -= findDetectable;
    }

    private void findDetectable(EnhancedTouch.Finger finger)
    {
        if (finger.currentTouch.tapCount != 0) return;

        ray = Camera.main.ScreenPointToRay(finger.screenPosition);
        if (Physics.Raycast(ray, out hit, 2000f, layerToMask))
        {
            spawnTextbox();
        }
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
        foreach(Transform detectable in transform.GetComponentInChildren<Transform>())
        {
            ray = new Ray(Camera.main.transform.position, (detectable.position - Camera.main.transform.position).normalized);
            if (Physics.Raycast(ray, out hit, 2000f, layerToMask))
            {
                Instantiate(hint, hit.collider.transform.position, hit.collider.transform.rotation);
            }
        }
    }
}
