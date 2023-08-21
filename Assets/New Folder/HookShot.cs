using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HookShot : MonoBehaviour
{
   private LineRenderer lr;
   private Vector3 grapplePoint;
   public LayerMask whatIsGrappleable;
   public Transform gunTip, camera, player;
   private float maxDistance = 100f;
   private SpringJoint joint;
   public Rigidbody rb;
   public float speed = 10f;
   public float minDist = 10f;
   public static float nextTimeToFire = 0f;
   public float fireRate = 0.1f;
   public static float time1 = 0f;
   public GameObject readyEffect;
   public float effectDuration = 10f;

   void Awake() {
        lr = GetComponent<LineRenderer>();
   }

   void Update() {

     
        DrawRope();

        if (Input.GetMouseButtonDown(1) && Time.time >= nextTimeToFire) {
            nextTimeToFire = Time.time + 1f/fireRate;
            StartHook();
            readyEffect.SetActive(false);
            StartCoroutine(ShowAndHideEffect());
            
        }
        else if (Input.GetMouseButtonUp(1)) {
            StopHook();
        }
   }
   private IEnumerator ShowAndHideEffect()
    {
        

        yield return new WaitForSeconds(effectDuration); // Wait for the specified duration
        readyEffect.SetActive(true); // Show the effect
        // Hide the effect gradually using a gradient or animation if desired
        // For now, let's just deactivate it
     //    readyEffect.SetActive(false);
    }
   void FixedUpdate(){
     
   }

   void LateUpdate() {
    DrawRope();
   }

   void StartHook() {
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward, out hit, maxDistance, whatIsGrappleable)) {
            grapplePoint = hit.point;
            float dist = Vector3.Distance(player.transform.position, transform.position);
            if(dist < minDist)
            {
               rb.velocity = camera.forward * speed;
            }
            
          //   joint = player.gameObject.AddComponent<SpringJoint>();
          //   joint.autoConfigureConnectedAnchor = false;
          //   joint.connectedAnchor = grapplePoint;

          //   float distanceFromPoint = Vector3.Distance(player.position, grapplePoint);

          //   joint.maxDistance = distanceFromPoint * 0.8f;
          //   joint.minDistance = distanceFromPoint * 0.05f;

          //   joint.spring = 4.5f;
          //   joint.damper = 7f;
          //   joint.massScale = 4.5f;

            lr.positionCount = 2;
        }
   }

   void StopHook() {
        lr.positionCount = 0;
        Destroy(joint);
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
