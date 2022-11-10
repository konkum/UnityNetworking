using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;
using TouchPhase = UnityEngine.InputSystem.TouchPhase;

public class CameraController : MonoBehaviour
{
    private static CameraController _instance;
    public static CameraController Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<CameraController>();
            }
            return _instance;
        }

    }
    [SerializeField] private FixedJoystick joystick;
    [SerializeField] private CinemachineFreeLook freeLook;
    [SerializeField] private float swipeSpeed = 0.2f;


    private Touch _activeTouch;
    private Vector3 _firstPoint;
    private Vector3 _secondPoint;

    private float _swipeDirX = 0;
    private Vector3 _xSwipeAmount;


    public CinemachineFreeLook FreeLookCamera => freeLook;


    private void Start()
    {
        EnhancedTouchSupport.Enable();
        _xSwipeAmount = Vector3.zero;
    }



    private bool IsPointerOverUIObject(Vector2 pos)
    {
        PointerEventData eventDataCurrentPosition = new(EventSystem.current);
        eventDataCurrentPosition.position = pos;
        List<RaycastResult> results = new();
        EventSystem.current.RaycastAll(eventDataCurrentPosition, results);
        return results.Count > 0;
    }


    private void Update()
    {
        if (Touch.activeTouches.Count > 0)
        {
            _activeTouch = Touch.activeTouches[0];

            if (IsPointerOverUIObject(_activeTouch.screenPosition) || joystick.IsUsingJoystic)
            {
                return;
            }


            if (_activeTouch.phase == TouchPhase.Began)
            {
                _firstPoint = _activeTouch.screenPosition;
                _swipeDirX = 0;
            }
            else if (_activeTouch.phase == TouchPhase.Moved)
            {
                _secondPoint = _activeTouch.screenPosition;
                _swipeDirX = _secondPoint.x - _firstPoint.x;
            }
        }
        else
        {
            _swipeDirX = 0;
        }

        _xSwipeAmount = _swipeDirX * swipeSpeed * Time.deltaTime * Vector3.up;

        freeLook.m_XAxis.Value += _xSwipeAmount.y;
    }
}
