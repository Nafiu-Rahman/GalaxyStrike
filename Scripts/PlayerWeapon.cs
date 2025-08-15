using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeapon : MonoBehaviour
{

    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetPoint;
    [SerializeField] float targetDistance = 10f;
    bool isFiring = false;

    private void Start()
    {
        Cursor.visible = false;
    }
    private void Update()
    {
        ProcessFire();
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();

    }

    public void OnFire(InputValue value)
    {
        isFiring = value.isPressed;
    }
    void ProcessFire()
    {
        foreach (GameObject laser in lasers) //foreach(type item in collction)
        {
            var emossionModule = laser.GetComponent<ParticleSystem>().emission;
            emossionModule.enabled = isFiring;
        }
    }

    void MoveCrosshair()
    {
        crosshair.position = Mouse.current.position.ReadValue();
    }

    void MoveTargetPoint()
    {
        Vector3 targetPointPosition = new Vector3(Mouse.current.position.ReadValue().x, Mouse.current.position.ReadValue().y, targetDistance);
        targetPoint.position = Camera.main.ScreenToWorldPoint(targetPointPosition);
    }

    void AimLasers()
    {
        foreach (GameObject laser in lasers)
        {
            Vector3 fireDirection = targetPoint.position - laser.transform.position;
            Quaternion rotationToTarget = Quaternion.LookRotation(fireDirection);
            laser.transform.rotation = rotationToTarget;
        }
    }

}
