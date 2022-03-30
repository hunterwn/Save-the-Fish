using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartGenerator : MonoBehaviour
{
    public GridManager gridManager;
    public Transform partToGenerate;
    // Start is called before the first frame update
    void Start()
    {
        PartGeneratorButton pgb = gameObject.GetComponent<PartGeneratorButton>();
        pgb.gridManager = gridManager;
        pgb.partToGenerate = partToGenerate;
    }
}
