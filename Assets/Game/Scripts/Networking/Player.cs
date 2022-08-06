using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
public class Player : NetworkBehaviour
{
    [SerializeField] private Ball ballPrefab;

    [Networked] private TickTimer delay { get; set; }

    private Vector3 _foward;
    private NetworkCharacterControllerPrototype _cc;

    public static Player Local;
    private void Awake()
    {
        _cc = GetComponent<NetworkCharacterControllerPrototype>();
    }
    public override void Spawned()
    {
        if (Object.HasInputAuthority)
        {
            Local = this;
            CameraController.Instance.FreeLookCamera.Follow = this.transform.GetChild(0);
            CameraController.Instance.FreeLookCamera.LookAt = this.transform.GetChild(0);
        }
    }
    public override void FixedUpdateNetwork()
    {
        if (GetInput(out NetworkInputData data))
        {
            data.Direction.Normalize();
            _cc.Move(5 * data.Direction * Runner.DeltaTime);

            if (data.Direction.sqrMagnitude > 0)
            {
                _foward = data.Direction;
            }

            if (delay.ExpiredOrNotRunning(Runner))
            {
                if (data.ShootButton)
                {
                    delay = TickTimer.CreateFromSeconds(Runner, 0.5f);
                    Runner.Spawn(ballPrefab, transform.position + _foward, Quaternion.LookRotation(_foward), Object.InputAuthority, (runner, o) =>
                    {
                        o.GetComponent<Ball>().Init();
                    });
                }
            }
        }
    }
}
