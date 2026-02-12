using UnityEngine;
using System.Collections.Generic;

public class XR_PathMemory : MonoBehaviour
{
    public List<Vector3> pathPoints = new List<Vector3>();
    public LineRenderer pathVisualizer;

    public void AddPoint(Vector3 pos)
    {
        pathPoints.Add(pos);
        UpdatePathLine();
    }

    void UpdatePathLine()
    {
        if (pathVisualizer == null) return;
        pathVisualizer.positionCount = pathPoints.Count;
        pathVisualizer.SetPositions(pathPoints.ToArray());
    }

    public void ClearPath()
    {
        pathPoints.Clear();
        if (pathVisualizer != null) pathVisualizer.positionCount = 0;
    }
}
