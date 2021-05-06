using UnityEngine;
using UnityEngine.UI;

public class ObjectSelectionController : MonoBehaviour
{
    // [SerializeField]
    // private GameObject welcomePanel;

    // [SerializeField]
    // private PlacementObject[] placedObjects;

    [SerializeField]
    private Text imageTrackedText;

    [SerializeField]
    private Text status;

    [SerializeField]
    private Color activeColor = Color.red;

    [SerializeField]
    private Color inactiveColor = Color.gray;

    // [SerializeField]
    // private Button dismissButton;

    [SerializeField]
    private Camera arCamera;

    private Vector2 touchPosition = default;

    // [SerializeField]
    // private bool displayOverlay = false;

    void Awake() 
    {
        //dismissButton.onClick.AddListener(Dismiss);
    }

    void Start()
    {
       //ChangeSelectedObject(placedObjects[0]);
    }

    //private void Dismiss() => welcomePanel.SetActive(false);

    void Update()
    {
        // do not capture events unless the welcome panel is hidden
        // if(welcomePanel.activeSelf)
        //     return;

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            
            touchPosition = touch.position;

            if(touch.phase == TouchPhase.Began)
            {
                DebuggingTextUpdate("touch began", "touched");
                Ray ray = arCamera.ScreenPointToRay(touch.position);
                RaycastHit hitObject;
                if(Physics.Raycast(ray, out hitObject))
                {
                    DebuggingTextUpdate("hit something", "hit");
                    //these game objects might need data? Make a new monobehavior? Might need a more specific object 
                    //ameObject foundObject = hitObject.transform.GetComponent<GameObject>();
                    if(hitObject.collider.tag == "Beacons")
                    {
                        DebuggingTextUpdate("foundObject", hitObject.collider.tag);
                        ChangeSelectedObject(hitObject.collider.gameObject);
                    }
                }
            }
        }
    }

    void ChangeSelectedObject(GameObject selected)
    {
        //find all objects in screen 
        GameObject[] placedObjects;
        placedObjects = GameObject.FindGameObjectsWithTag("Beacons");
        DebuggingTextUpdate("change selected", selected.name);
        // MeshRenderer meshRenderer = selected.GetComponent<MeshRenderer>();
        // meshRenderer.material.color = activeColor; 
        foreach (GameObject current in placedObjects)
        {   
            MeshRenderer meshRenderer = current.GetComponent<MeshRenderer>();
            if(selected != current) 
            {
                //DebuggingTextUpdate("not same as current", current.name);
                meshRenderer.material.color = inactiveColor;
            }
            else 
            {
               // DebuggingTextUpdate("same as current", selected.name);
                meshRenderer.material.color = activeColor;  
            }
            
            // if(displayOverlay)
            //     current.ToggleOverlay();
        }
    }

    private void DebuggingTextUpdate(string statusMessage, string name) {
        status.text = $"status: {statusMessage} object {name}";
        imageTrackedText.text =  $"{name}";
    }
}
