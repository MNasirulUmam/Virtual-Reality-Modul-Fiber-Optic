using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace VR
{
    public class LineCurved : MonoBehaviour
    {
        public bool isOnline;
        public NetworkedCounterAnchor NetworkedCounterAnchor;
        private PhotonView photonView;
        bool status;

        public GameObject line;
        public float tinggiPoint, nilaiNaik;

        public enum ObjectUsedForTrigger { x, y, z };

        public ObjectUsedForTrigger sumbu;

        // Start is called before the first frame update
        void Start()
        {
            photonView = GetComponent<PhotonView>();
        }

        void CheckKencang()
        {
            switch (sumbu)
            {
                case ObjectUsedForTrigger.x:
                    if (line.transform.localPosition.x >= tinggiPoint)
                    {
                        NetworkedCounterAnchor.counter++;
                        this.gameObject.SetActive(false);
                        print("Line telah dikencangkan");
                    }

                    break;

                case ObjectUsedForTrigger.y:
                    if (line.transform.localPosition.y >= tinggiPoint)
                    {
                        NetworkedCounterAnchor.counter++;
                        this.gameObject.SetActive(false);
                        print("Line telah dikencangkan");
                    }

                    break;

                case ObjectUsedForTrigger.z:
                    if (line.transform.localPosition.z >= tinggiPoint)
                    {
                        NetworkedCounterAnchor.counter++;
                        this.gameObject.SetActive(false);
                        print("Line telah dikencangkan");
                    }

                    break;
            }
        }


        public void XUp()
        {
            if (isOnline)
            {
                status = true;
                photonView.RPC("XNaik", RpcTarget.AllBuffered, status);
                photonView.RPC("CheckKencangOnline", RpcTarget.AllBuffered, status);
            }
            else
            {
                line.transform.Translate(nilaiNaik, 0f, 0f);
                CheckKencang();
            }

        }

        public void YUp()
        {
            if (isOnline)
            {
                status = true;
                photonView.RPC("YNaik", RpcTarget.AllBuffered, status);
                photonView.RPC("CheckKencangOnline", RpcTarget.AllBuffered, status);
            }
            else
            {
                line.transform.Translate(0f, nilaiNaik, 0f);
                CheckKencang();
            }

        }


        [PunRPC]
        void CheckKencangOnline(bool statusRPC)
        {
            if (statusRPC)
            {
                switch (sumbu)
                {
                    case ObjectUsedForTrigger.x:
                        if (line.transform.localPosition.x >= tinggiPoint)
                        {
                            NetworkedCounterAnchor.counter++;
                            this.gameObject.SetActive(false);
                            print("Line telah dikencangkan");
                        }

                        break;

                    case ObjectUsedForTrigger.y:
                        if (line.transform.localPosition.y >= tinggiPoint)
                        {
                            NetworkedCounterAnchor.counter++;
                            this.gameObject.SetActive(false);
                            print("Line telah dikencangkan");
                        }

                        break;

                    case ObjectUsedForTrigger.z:
                        if (line.transform.localPosition.z >= tinggiPoint)
                        {
                            NetworkedCounterAnchor.counter++;
                            this.gameObject.SetActive(false);
                            print("Line telah dikencangkan");
                        }

                        break;
                }
            }
        }

        [PunRPC]
        void XNaik(bool statusRPC)
        {
            if (statusRPC)
            {
                line.transform.Translate(nilaiNaik, 0f, 0f);
            }
        }

        [PunRPC]
        void YNaik(bool statusRPC)
        {
            if (statusRPC)
            {
                line.transform.Translate(nilaiNaik, 0f, 0f);
            }
        }

    }
}