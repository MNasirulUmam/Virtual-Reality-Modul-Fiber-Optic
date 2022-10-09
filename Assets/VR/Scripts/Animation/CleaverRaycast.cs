using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleaverRaycast : MonoBehaviour
{
    /*[SerializeFileld] private int rayLength = 5;
    [SerializeFileld] private LayerMask layerMaskInteract;
    [SerializeFileld] private string excludeLayerName = null;
*/
   /* private AttacherAnimation raycastedObj;*/

    /*[SerializeFileld] private KeyCode openDoorKey = KeyCode.Mouse0;*/

   /* private bool isCosshairActive;
    private bool doOnce;

    private const string interactableTag = "InteractiveObject";
    
    private void Update()
    {
        Raycast hit;
        Vector3.fwd = transform.TransFormDirection(Vector3.forward);

        int mask = 1 << layerMas.NameToLayer(excludeLayerName) | layerMaskInteract.value;
        if(Physics.Raycast(transform.position, fwd, out hit, rayLength, mask))
        {
            if (hit.collider.CompareTag(interactableTag))
            {
                if (!done)
                {
                    raycastedObj = hit.collider.gameobject.GetComponent<AttacherAnimation>();
                    CrosshairChange(true);
                }

                isCrosshairActive = true;
                doOnce = true;
                if (Input.GetKeyDown(openDoorKey))
                {
                    raycastedObj.PlayAnimation();
                }
            }
        }
        else
        {
            if (isCosshairActive)
            {
                CrosshairChange(false);
                doOnce(false);
            }
        }
    }
    void CrosshairChange(bool on)
    {
        if (on && !doOnce)
        {
            crosshair.color = Color.red;
        }
        else
        {
            crosshair.color = Color.white;
            isCosshairActive = false;
        }
    }*/
  
}
