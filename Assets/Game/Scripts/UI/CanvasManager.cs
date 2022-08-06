using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasManager : MonoBehaviour
{
    [SerializeField] private MainUIElement mainUIElement;

    private void Start()
    {
        mainUIElement.Initialize();
    }
}
