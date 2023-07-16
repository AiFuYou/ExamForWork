using System;
using UnityEngine;

public class MoveEaseInOut : MoveBase
{
    public MoveEaseInOut(GameObject go, Vector3 begin, Vector3 end, float time, bool pingPong) : base(go, begin, end, time,
        pingPong)
    {
    }

    protected override void Ease()
    {
        var halfTime = time / 2;
        if (timePassed <= halfTime)
        {
            offsetPos = (end - begin) / 2 * ((float)Math.Pow(timePassed / halfTime, 2));
        }
        else
        {
            var realTimePassed = timePassed - halfTime;
            offsetPos = (end - begin) / 2 * (1 - (float)Math.Pow(1 - realTimePassed / halfTime, 2) + 1);
        }
    }
}