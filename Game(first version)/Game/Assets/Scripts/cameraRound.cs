using UnityEngine;

using System.Collections;

public class cameraRound : MonoBehaviour

{

    private int MouseWheelSensitivity = 15;

    private int maxCamFov = 90;

    private int minCamFov = 10;

    public Transform target;

    Transform cam;

    private Vector3 normalized;

    void Start()

    {

        cam = Camera.main.transform;

    }

    void Update()

    {

        if (Input.GetMouseButtonDown(0))

        {

            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))

            {

                if (hit.transform.parent.name == "gobj")

                {

                    print(hit.transform.name);

                    Vector3 relativePos = hit.transform.position - cam.position;

                    print(relativePos.ToString());

                    Quaternion rotation = Quaternion.LookRotation(relativePos);

                    cam.rotation = rotation;

                }

            }

        }

        if (Input.GetAxis("Mouse ScrollWheel") != 0)

        {

            float fov = Camera.main.fieldOfView;

            fov += Input.GetAxis("Mouse ScrollWheel") * -MouseWheelSensitivity;

            fov = Mathf.Clamp(fov, minCamFov, maxCamFov);

            Camera.main.fieldOfView = fov;

        }

    }

}