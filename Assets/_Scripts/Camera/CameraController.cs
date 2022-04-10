using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class CameraController : MonoBehaviour
    {
        public float CamSpeed = 20f;
        public float CamBorderMouse = 10f;
        public Vector2 CamLimit;
        public float MouseScrollSpeed = 20f;
        public float MinY = 20f;
        public float MaxY = 120f;

        // Update is called once per frame
        void Update()
        {
            Vector3 pos = transform.position;
            
            if ((Input.GetKey("w") || Input.mousePosition.y >= Screen.height - CamBorderMouse))
            {
                pos.z += CamSpeed * Time.deltaTime;
                Debug.Log(
                "pozice Z"
                + pos.z
                );
            }
            if ((Input.GetKey("s") || Input.mousePosition.y <= CamBorderMouse))
            {
                pos.z -= CamSpeed * Time.deltaTime;
                Debug.Log(
                "pozice Z"
                + pos.z
                );
            }
            if ((Input.GetKey("d") || Input.mousePosition.x >= Screen.width - CamBorderMouse))
            {
                pos.x += CamSpeed * Time.deltaTime;
                Debug.Log(
                "pozice X" +
                pos.x
                );
            }
            if ((Input.GetKey("a") || Input.mousePosition.x <= CamBorderMouse))
            {
                pos.x -= CamSpeed * Time.deltaTime;
                Debug.Log(
                "pozice X" +
                pos.x
                );
            }
            pos.x = Mathf.Clamp(pos.x, -CamLimit.x, CamLimit.x);
            Debug.Log(
            "pozice X" +
            pos.x
            );
            pos.z = Mathf.Clamp(pos.z, -CamLimit.y, CamLimit.y);
            Debug.Log(
            "pozice Z" +
            pos.z
            );
            float MouseScroll = Input.GetAxis("Mouse ScrollWheel");
            pos.y -= MouseScroll * MouseScrollSpeed * 100f * Time.deltaTime;
            Debug.Log(
            "pozice Y" +
            pos.y
            );
            pos.y = Mathf.Clamp(pos.y, MinY,MaxY);
            Debug.Log(
            "pozice Y" +
            pos.y
            );
            transform.position = pos;
            Debug.Log(
                "pozice Z" 
                + pos.z
                );
            Debug.Log(
                "pozice Y" +
                pos.y
                ); 
            Debug.Log(
                "pozice X" +
                pos.x
                );

        }
    }


