using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputHandler : MonoBehaviour
{
    private static InputHandler _instance;
    public static InputHandler Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<InputHandler>();
            }
            return _instance;
        }
    }

    public bool ShootButton;

    private IEnumerator Start()
    {
        while (true)
        {
            yield return Helpers.GetWait(0.1f);
            RefreshInput();
        }
    }
    private void RefreshInput()
    {
        ShootButton = false;
    }
}
