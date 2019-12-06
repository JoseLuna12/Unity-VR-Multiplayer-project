using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

public class CameraOnline : MonoBehaviour
{
    private Camera m_Camera, cam_center, cam_right, cam_left;
    [SerializeField] private GameObject centereye, rightEye, leftEye, controllerVr;
    PhotonView myPhotonView;

    private void Awake()
    {
        myPhotonView = GetComponent<PhotonView>();
        //m_Camera.enabled = false;
        cam_center = centereye.GetComponent<Camera>();
        cam_right = rightEye.GetComponent<Camera>();
        cam_left = leftEye.GetComponent<Camera>();
        if (!myPhotonView.IsMine)
        {
            cam_center.enabled = false;
            cam_right.enabled = false;
            cam_left.enabled = false;
            controllerVr.GetComponent<OVRControllerHelper>().enabled = false;
            this.transform.gameObject.GetComponent<OVRCameraRig>().enabled = false;
            this.transform.gameObject.GetComponent<OVRManager>().enabled = false;
            this.transform.gameObject.GetComponent<OVRHeadsetEmulator>().enabled = false;
            //this.transform.gameObject.GetComponent<shoot>().enabled = false;
            //
            controllerVr.SetActive(false);
            Debug.Log("desactivado todo");
        }

        if (myPhotonView.IsMine)
        {
            controllerVr.GetComponent<OVRControllerHelper>().enabled = true;
            this.transform.gameObject.GetComponent<OVRCameraRig>().enabled = true;
            this.transform.gameObject.GetComponent<OVRManager>().enabled = false;
            this.transform.gameObject.GetComponent<OVRHeadsetEmulator>().enabled = true;
            //this.transform.gameObject.GetComponent<shoot>().enabled = true;
            return;
        }
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
