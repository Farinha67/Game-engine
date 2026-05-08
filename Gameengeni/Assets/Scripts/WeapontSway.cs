using UnityEngine;

public class WeaponSway : MonoBehaviour
{
    public float smooth = 8f;
    public float swayAmount = 0.05f;

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * swayAmount;
        float mouseY = Input.GetAxis("Mouse Y") * swayAmount;

        Quaternion targetRotation =
            Quaternion.Euler(-mouseY, mouseX, 0);

        transform.localRotation =
            Quaternion.Slerp(
                transform.localRotation,
                targetRotation,
                Time.deltaTime * smooth
            );
    }
}