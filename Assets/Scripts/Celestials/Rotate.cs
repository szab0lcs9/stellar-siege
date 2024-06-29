using UnityEngine;

public class Rotate : MonoBehaviour
{
    [SerializeField] private float rotationRatio;

    void FixedUpdate()
    {
        RotateAroundYAxis();
    }

    void RotateAroundYAxis()
    {
        float secs = 86400.0f;
        float angle = 0.0f;

        if (secs != 0)
            angle = 360 / secs * rotationRatio;

        gameObject.GetComponent<Transform>().Rotate(Vector3.up, angle * Time.deltaTime);            
    }
}
