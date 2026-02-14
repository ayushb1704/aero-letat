using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraScaler : MonoBehaviour
{
    // Set this to the orthographic size you like in the editor
    public float referenceOrthographicSize = 5f;

    void Start()
    {
        // This one line is all you need to "Match Height"
        GetComponent<Camera>().orthographicSize = referenceOrthographicSize;
    }
}
