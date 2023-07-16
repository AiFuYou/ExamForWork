using System;
using UnityEngine;

public class MoveEaseIn : MoveBase
{
    public MoveEaseIn(GameObject go, Vector3 begin, Vector3 end, float time, bool pingPong) : base(go, begin, end, time,
        pingPong)
    {
    }

    protected override void Ease()
    {
        offsetPos = (end - begin) * (float)Math.Pow(timePassed / time, 2);
    }
}