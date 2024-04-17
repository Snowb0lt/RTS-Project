using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Unit : MonoBehaviour, ISelectable
{
    public bool isSelected { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }
    [SerializeField] private float selectionOffset;
    // Update is called once per frame
    void Update()
    {
        ShowUnitSelection();
    }

    private void ShowUnitSelection()
    {
        //Shows the indicator of selected units
        if (isSelected && this.gameObject.transform.childCount == 0)
        {
            var selectionPiece = Instantiate(PlayerControls.instance.selectionPrefab, transform);
            selectionPiece.transform.position = new Vector3(this.transform.position.x, 0.0f, this.transform.position.z);

        }
        else if (!isSelected && transform.Find("Selection(Clone)") != null)
        {
            Destroy(transform.Find("Selection(Clone)").gameObject);
        }
    }

    //Controls Navmesh Agent
    [SerializeField] private NavMeshAgent navMeshAgent;
}
