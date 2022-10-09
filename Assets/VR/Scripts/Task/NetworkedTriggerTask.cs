using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace VR
{
    public class NetworkedTriggerTask : MonoBehaviour
    {
        TaskManager TaskManager;
        public bool isOnline = true;
        public NetworkedCounterAnchor NetworkedCounterAnchor;
        private PhotonView photonView;
        bool status;
        public GameObject otherObject1, otherObject2, otherObject3, otherObject4, activeAnchor, activeRope, destroyAnchorRope;
        // Start is called before the first frame update
        void Start()
        {
            TaskManager = GameObject.Find("TaskManager").GetComponent<TaskManager>();
            photonView = GetComponent<PhotonView>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        void OnTriggerEnter(Collider other)
        {
            if (isOnline)
            {
                if (other.gameObject == otherObject1 | other.gameObject == otherObject2 | other.gameObject == otherObject3 | other.gameObject == otherObject4)
                {
                    status = true;
                    Debug.Log(status);
                    photonView.RPC("CounterAnchor", RpcTarget.AllBuffered, status);
                }
            }
            else
            {
                if (other.gameObject == otherObject1 | other.gameObject == otherObject2 | other.gameObject == otherObject3 | other.gameObject == otherObject4)
                {
                    Debug.Log(status);
                    NetworkedCounterAnchor.counter++;
                    this.gameObject.SetActive(false);
                    destroyAnchorRope.SetActive(false);
                    activeAnchor.SetActive(true);
                    if (activeRope != null)
                    {
                        activeRope.SetActive(true);
                    }
                    status = false;
                    Debug.Log(status);
                }
            }


        }

        [PunRPC]
        void CounterAnchor(bool statusRPC)
        {
            if (statusRPC)
            {
                NetworkedCounterAnchor.counter++;
                this.gameObject.SetActive(false);
                destroyAnchorRope.SetActive(false);
                activeAnchor.SetActive(true);
                if (activeRope != null)
                {
                    activeRope.SetActive(true);
                }
                status = false;
                Debug.Log(status);
            }
        }
    }
}
