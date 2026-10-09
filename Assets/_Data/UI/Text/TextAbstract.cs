using TMPro;
using UnityEngine;
using UnityEngine.Rendering;

public class TextAbstract : BaseMonoBehaviour
{
    [SerializeField] protected TextMeshProUGUI textPro;

    protected override void LoadComponents()
    {
        base.LoadComponents();
        this.LoadTextPro();
    }

    protected virtual void LoadTextPro()
    {
        if(this.textPro != null) return;
        this.textPro = GetComponent<TextMeshProUGUI>();
    }
}