using UnityEngine;

public class Rotation : MonoBehaviour
{
    public Transform Target;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(Target.position, Vector3.up, 100 * Time.deltaTime);  
    }
}
