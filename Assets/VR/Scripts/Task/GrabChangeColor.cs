using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using EPOOutline;

namespace VR
{
    public class GrabChangeColor : MonoBehaviour
    {
        void OnTriggerEnter(Collider other)
        {
            if (other.gameObject.tag == "Hand")
            {
                var outlineObject = GetComponent<Outlinable>();
                outlineObject.OutlineParameters.Color = Color.blue;
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.gameObject.tag == "Hand")
            {
                var outlineObject = GetComponent<Outlinable>();
                outlineObject.OutlineParameters.Color = Color.green;
            }
        }
    }
}