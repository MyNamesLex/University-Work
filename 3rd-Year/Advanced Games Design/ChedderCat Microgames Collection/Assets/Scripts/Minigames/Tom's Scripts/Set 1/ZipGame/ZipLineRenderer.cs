using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class ZipLineRenderer : MonoBehaviour
{
    public LineRenderer LineRenderer;
    public List<Transform> CircleTransforms;
    // Start is called before the first frame update
    void Start()
    {
        LineRenderer.positionCount = CircleTransforms.Count;
    }

    // Update is called once per frame
    void Update()
    {
        LineRenderer.SetPositions(CircleTransforms.Select(p => p.position).ToArray());
    }
}
