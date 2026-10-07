using UnityEngine;

[System.Serializable]
public class Arrow
{
    public Vector3 start;
    public Vector3 end;
    public float width = 0.2f;       // shaft thickness
    public float headLength = 0.5f;  // head length in real units
    public float headWidth = 2.5f;   // head thickness (times shaft width)
    public Color color = Color.white;
    public LineRenderer line;

    public void Redraw()
    {
        if ((end - start).sqrMagnitude < 0.0001f) { line.enabled = false; return; }
        line.enabled = true;

        line.SetPosition(0, start);
        line.SetPosition(1, end);

        line.widthMultiplier = width;
        line.startColor = color;
        line.endColor = color;
    }
// direction the arrow points, length 1
    public Vector3 Direction()
    {
        return (end - start).normalized;
    }

    // rotation for 3D (the arrow's "forward" points along the arrow)
    public Quaternion Rotation3D()
    {
        Vector3 dir = end - start;
        if (dir.sqrMagnitude < 0.0001f) return Quaternion.identity;   // too short
        return Quaternion.LookRotation(dir);
    }

    // rotation for 2D, as an angle in degrees around Z
    public float AngleZ()
    {
        Vector3 dir = end - start;
        return Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
    }

    // where the head starts (same math as in Redraw)
    public Vector3 Neck()
    {
        float head = Mathf.Min(headLength, (end - start).magnitude);
        return end - Direction() * head;
    }

    // length of the whole arrow
    public float Length()
    {
        return (end - start).magnitude;
    }

}