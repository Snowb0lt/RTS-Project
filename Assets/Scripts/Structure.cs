using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Structure : MonoBehaviour, ISelectable
{
    public bool isSelected { get; set; }   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
        StructureSelect();
    }

    private void StructureSelect()
    {
        //Shows the indicator of selected units
        if (isSelected && this.gameObject.transform.childCount == 0)
        {
            var selectionPiece = Instantiate(PlayerControls.instance.selectionPrefab, transform);
            selectionPiece.transform.position = new Vector3(this.transform.position.x, 0.0f, this.transform.position.z);
            selectionPiece.transform.localScale = new Vector3(1.25f, 0, 1.25f);
        }
        else if (!isSelected && transform.Find("Selection(Clone)") != null)
        {
            Destroy(transform.Find("Selection(Clone)").gameObject);
        }
    }
    public List<GameObject> Producable = new List<GameObject>();
    private void Production(GameObject ItemToProduce)
    {

    }
}
