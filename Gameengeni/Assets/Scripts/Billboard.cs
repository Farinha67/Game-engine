using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;

    void Update()
    {
        if (cam != null)
        {
            transform.LookAt(transform.position + cam.forward);
        }
    }
}