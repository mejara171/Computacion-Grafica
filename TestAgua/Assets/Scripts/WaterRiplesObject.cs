using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class WaterRiplesObject : MonoBehaviour
{

    [SerializeField] private Material referenceMaterial;

    // Update is called once per frame
    void Update()
    {
        if (referenceMaterial == null) return;
        Vector3 pos = transform.position;
        Vector3 bounds = GetComponent<Renderer>().bounds.extents;
        float radius = Mathf.Max(Mathf.Max(bounds.x, bounds.y), bounds.z);
        referenceMaterial.SetVector("_RippleSource", new Vector4(pos.x,pos.y,pos.z,radius*5f));
    }
}
