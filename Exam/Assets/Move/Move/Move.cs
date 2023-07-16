using UnityEngine;

public class Move : MoveBase
{
    public Move(GameObject go, Vector3 begin, Vector3 end, float time, bool pingPong) : base(go, begin, end, time,
        pingPong)
    {
    }

    protected override void Ease()
    {
        offsetPos = (end - begin) * (timePassed / time);
    }
}