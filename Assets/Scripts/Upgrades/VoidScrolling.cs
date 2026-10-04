using UnityEngine;
using UnityEngine.InputSystem;

public class VoidScrolling : MonoBehaviour
{
    public RectTransform UpgradeVoid;
    public float Scale = 5;
    private float smthScale;
    void Start() {
        Scale = UpgradeVoid.localScale.x;
    }
    void Update()
    {
        smthScale = Mathf.Lerp(UpgradeVoid.localScale.x, Scale, 1f - Mathf.Exp(-15f * Time.deltaTime));
        UpgradeVoid.localScale = new Vector3(smthScale,smthScale,smthScale);
        Vector2 scroll = Mouse.current.scroll.ReadValue();
        float amount = scroll.y;

        if (amount != 0)
            Scale += scroll.y;
            Scale = Mathf.Clamp(Scale,3f,30f);
            
    }
}
