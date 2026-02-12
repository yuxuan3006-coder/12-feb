using UnityEngine;
using TMPro;

public class XR_KeypadButton : MonoBehaviour
{
    public TMP_InputField targetField;
    public string keyValue;

    public void OnKeyPress()
    {
        if (targetField == null) return;

        switch (keyValue)
        {
            case "C": targetField.text = ""; break;
            case "←":
                if (targetField.text.Length > 0)
                    targetField.text = targetField.text.Substring(0, targetField.text.Length - 1);
                break;
            default:
                targetField.text += keyValue;
                break;
        }
    }
}
