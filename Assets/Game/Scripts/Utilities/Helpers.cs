using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Helpers
{
    private static Camera _camera;
    public static Camera Camera
    {
        get
        {
            if (_camera == null)
            {
                _camera = Camera.main;
            }
            return _camera;
        }
    }
    private static Dictionary<float, WaitForSeconds> _waitDictionary = new Dictionary<float, WaitForSeconds>();
    public static WaitForSeconds GetWait(float time)
    {
        if (_waitDictionary.TryGetValue(time, out var wait))
        {
            return wait;
        }
        _waitDictionary[time] = new WaitForSeconds(time);
        return _waitDictionary[time];
    }
    public static Vector3 ToV3(this Vector2 input) => new Vector3(input.x, 0, input.y);
}
