using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerControls : MonoBehaviour
{

    public static PlayerControls instance;
    private void Awake()
    {
        if (instance == null || instance != this)
        {
            instance = this;
        }
    }
   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MakeSelection();
        foreach (var obj in SelectedObjects)
        {
            obj.GetComponent<ISelectable>().isSelected = true;
        }
        MoveSelected();
    }
    public GameObject selectionPrefab;
    public List<GameObject> SelectedObjects = new List<GameObject>();
    private void MakeSelection()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                //Check if object is selectable
                try
                {
                    if (hit.rigidbody.gameObject.GetComponent<ISelectable>() != null)
                    {
                        foreach (var obj in SelectedObjects)
                        {
                            obj.GetComponent<ISelectable>().isSelected = false;
                        }
                        SelectedObjects.Clear();
                        var selection = hit.rigidbody.gameObject;
                        Debug.Log($"Clicked on {selection.name}");
                        SelectedObjects.Add(selection);
                        

                    }
                }
                catch
                {
                    foreach (var obj in SelectedObjects)
                    {
                        obj.GetComponent<ISelectable>().isSelected = false;
                    }
                    SelectedObjects.Clear();
                }
            }
        }
    }
    public void MoveSelected()
    {
        //Move Units
        if(Input.GetMouseButtonDown(1))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray,out hit))
            {
                foreach (var obj in SelectedObjects)
                {
                    if (obj.gameObject.GetComponent<ISelectable>() != null && obj.gameObject.GetComponent<Unit>() != null)
                    {
                        obj.GetComponent<NavMeshAgent>().SetDestination(hit.point);
                    }
                }
            }
        }
    }
}
