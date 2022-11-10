using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fusion;
public struct NetworkInputData : INetworkInput
{
    public bool ShootButton;
    public Vector3 Direction;
    public Vector3 CamDirection;
}
