using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrapplingGun : MonoBehaviour
{
   private LineRenderer lr;
   private Vector3 grapplePoint;
   public LayerMask whatIsGrappleable;
   public Transform gunTip, camera, player;
   private float maxDistance = 100f;
   private SpringJoint joint;

   void Awake() {
        lr = GetComponent<LineRenderer>();
   }

   void Update() {

        //DrawRope();

        if (Input.GetMouseButtonDown(0)) {
            StartGrapple();
        }
        else if (Input.GetMouseButtonUp(0)) {
            StopGrapple();
        }
   }

   void LateUpdate() {
    DrawRope();
   }

   void StartGrapple() {
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, whatIsGrappleable)) {
            grapplePoint = hit.point;
            joint = player.gameObject.AddComponent<SpringJoint>();
            joint.autoConfigureConnectedAnchor = false;
            joint.connectedAnchor = grapplePoint;

            float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

            joint.maxDistance = distanceFromPoint * 0.8f;
            joint.minDistance = distanceFromPoint * 0.05f;

            joint.spring = 4.5f;
            joint.damper = 7f;
            joint.massScale = 4.5f;

            lr.positionCount = 2;
        }
   }

   void StopGrapple() {
        lr.positionCount = 0;
        Destroy(joint);
   }
   void OnDisable() {
     StopGrapple();
   }

   void DrawRope() {

    if (!joint) return;
    lr.SetPosition(0, gunTip.position);
    lr.SetPosition(1,grapplePoint);
   }

   

   public bool IsGrappling() {
        return joint != null;
   }

   public Vector3 GetGrapplePoint() {
        return grapplePoint;
   }
}
