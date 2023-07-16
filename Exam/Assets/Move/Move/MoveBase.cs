using Unity.VisualScripting;
using UnityEngine;

public abstract class MoveBase
{
    public GameObject go;
    public Vector3 begin;
    public Vector3 end;
    public float time;
    public bool pingPong;
    public bool isEnd;

    protected MoveBase(GameObject go, Vector3 begin, Vector3 end, float time, bool pingPong = false)
    {
        this.go = go;
        this.begin = begin;
        this.end = end;
        this.time = time;
        this.pingPong = pingPong;
    }

    protected float timePassed;
    protected Vector3 offsetPos = Vector3.zero;

    public void Step(float deltaTime)
    {
        if (go.IsDestroyed())
        {
            isEnd = true;
            return;
        }
        
        timePassed += deltaTime;
        
        if (timePassed > time)
        {
            if (pingPong)
            {
                (begin, end) = (end, begin);
                timePassed = 0;
            }
            else
            {
                isEnd = true;
                return;    
            }
        }
        
        Ease();
        RefreshPos();
    }

    /// <summary>
    /// 实现缓动
    /// </summary>
    protected abstract void Ease();

    private void RefreshPos()
    {
        go.transform.position = begin + offsetPos;
    }
}