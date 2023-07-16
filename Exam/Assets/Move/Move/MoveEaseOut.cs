using System;
using UnityEngine;

public class MoveEaseOut : MoveBase
{
    public MoveEaseOut(GameObject go, Vector3 begin, Vector3 end, float time, bool pingPong) : base(go, begin, end, time,
        pingPong)
    {
    }

    protected override void Ease()
    {
        offsetPos = (end - begin) * (1 - (float)Math.Pow(1 - timePassed / time, 2));
    }
}