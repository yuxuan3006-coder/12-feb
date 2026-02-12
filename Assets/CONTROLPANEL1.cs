using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.XR.Interaction.Toolkit;

public class XR_CNCControlPanel : MonoBehaviour
{
    [Header("Assign Tool & UI Elements")]
    public Transform millingTool;           // The milling tool GameObject
    public TMP_InputField inputX;           // TMP fields (work in XR)
    public TMP_InputField inputY;
    public TMP_InputField inputZ;
    public Button moveButton;
    public Button homeButton;

    [Header("Settings")]
    public float moveSpeed = 0.5f;          // Speed of motion
    private Vector3 homePos;
    private bool isMoving = false;

    private void Start()
    {
        if (millingTool == null)
        {
            millingTool = this.transform;
        }

        homePos = millingTool.position;

        // Bind buttons
        moveButton.onClick.AddListener(() => StartCoroutine(MoveToTarget()));
        homeButton.onClick.AddListener(() => StartCoroutine(MoveTo(homePos)));
    }

    IEnumerator MoveTo(Vector3 target)
    {
        if (isMoving) yield break;
        isMoving = true;

        while (Vector3.Distance(millingTool.position, target) > 0.01f)
        {
            millingTool.position = Vector3.MoveTowards(millingTool.position, target, moveSpeed * Time.deltaTime);
            yield return null;
        }

        millingTool.position = target;
        isMoving = false;
    }

    IEnumerator MoveToTarget()
    {
        if (string.IsNullOrEmpty(inputX.text) || string.IsNullOrEmpty(inputY.text) || string.IsNullOrEmpty(inputZ.text))
            yield break;

        float x = float.Parse(inputX.text);
        float y = float.Parse(inputY.text);
        float z = float.Parse(inputZ.text);

        Vector3 target = new Vector3(x, y, z);
        yield return MoveTo(target);
    }
}
