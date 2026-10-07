using System.Collections.Generic;
using UnityEngine;

public class ArrowManager : MonoBehaviour
{
    public Material arrowMaterial;   // optional: drag a material here
    public List<Arrow> arrows = new List<Arrow>();

    public Arrow AddArrow(Vector3 start, Vector3 end, Color color)
    {
        GameObject go = new GameObject("Arrow");
        go.transform.parent = transform;

        LineRenderer lr = go.AddComponent<LineRenderer>();
        lr.positionCount = 2;   // was 3
        lr.useWorldSpace = true;
        lr.textureMode = LineTextureMode.Stretch;
        lr.material = arrowMaterial != null
            ? arrowMaterial
            : new Material(Shader.Find("Sprites/Default"));

        Arrow a = new Arrow();
        a.start = start;
        a.end = end;
        a.color = color;
        a.line = lr;

        arrows.Add(a);
        return a;
    }

    public void RemoveArrow(Arrow a)
    {
        Destroy(a.line.gameObject);
        arrows.Remove(a);
    }

    void Update()
    {
        foreach (Arrow a in arrows)
            a.Redraw();
    }
}