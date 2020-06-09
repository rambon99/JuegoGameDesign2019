using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : CharacterTemplate

{   public float dashForce, dashCooldownTime;
    private bool dashActive = false;

    private Rigidbody myRigidbody;
    private Camera mainCamera;
    public float counterDash;


    // Start is called before the first frame update
    public override void Start()
    {
        base.Start();
        myRigidbody = GetComponent<Rigidbody>();
        mainCamera = FindObjectOfType<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        HorizontalMovement(Input.GetAxis("Horizontal"));
        VerticalMovement(Input.GetAxis("Vertical"));
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Attack();
        }
        CameraMove();
        if (Input.GetKeyDown(KeyCode.Space) && !dashActive)
        {
            StartCoroutine(DashStart());
        }
    }

    private void CameraMove()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if (groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);

            transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
        }
    }

    private void DashMove()
    {
        myRigidbody.AddRelativeForce(Vector3.forward * dashForce * 100);
    }

    private IEnumerator DashStart()
    {
        dashActive = true;
        DashMove();
        counterDash = dashCooldownTime;
        while (counterDash >= 0)
        {
            yield return new WaitForSeconds(1);
            counterDash--;
        }
        dashActive = false;
    }
}
