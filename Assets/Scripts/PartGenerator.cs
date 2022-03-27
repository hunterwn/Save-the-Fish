using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartGenerator : MonoBehaviour
{
    public Transform generatedPartsContainer;
    public Transform partToGenerate;
    // Start is called before the first frame update
    void Start()
    {
        PartGeneratorButton pgb = gameObject.GetComponent<PartGeneratorButton>();
        pgb.generatedPartsContainer = generatedPartsContainer;
        pgb.partToGenerate = partToGenerate;
    }
}
