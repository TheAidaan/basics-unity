using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class LoadingPanelController : MonoBehaviour
{
    [SerializeField]
    Image _loadbar;

   public Image GetLoadBar()
    {
        return _loadbar;
    }
}
