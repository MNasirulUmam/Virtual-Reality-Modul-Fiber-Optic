using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PanelMove : MonoBehaviour
{
    public GameObject PanelAwal;
    public GameObject PanelTujuan;

    public void MovePanels()
    {
        PanelAwal.SetActive(false);
        PanelTujuan.SetActive(true);
    }
}
