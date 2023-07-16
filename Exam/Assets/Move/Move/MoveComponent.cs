using System.Collections.Generic;
using UnityEngine;

public class MoveComponent : MonoBehaviour
{
    private List<MoveBase> _moveList = new List<MoveBase>();

    /// <summary>
    /// 向列表中添加移动对象
    /// </summary>
    /// <param name="m">MoveBase</param>
    public void AddMove(MoveBase m)
    {
        _moveList.Add(m);
    }

    private void Update()
    {
        if (_moveList.Count > 0)
        {
            var count = _moveList.Count;
            for (var i = count - 1; i >= 0; i--)
            {
                var m = _moveList[i];
                if (m != null)
                {
                    if (m.isEnd)
                    {
                        _moveList.RemoveAt(i);
                    }
                    else
                    {
                        _moveList[i].Step(Time.deltaTime);
                    }
                }
            }
        }
    }
}

public enum Ease
{
    Linear,
    In,
    Out,
    InOut
}

public class MoveManager
{
    private static MoveComponent _moveComponent;

    static MoveManager()
    {
        var go = new GameObject("MoveComponent");
        _moveComponent = go.AddComponent<MoveComponent>();
        Object.DontDestroyOnLoad(go);
    }

    [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
    private static void Initialize()
    {
        Debug.Log("MoveCore Initialize");
    }

    public static void Move(GameObject go, Vector3 begin, Vector3 end, float time, bool pingPong = false, Ease ease = Ease.Linear)
    {
        
        switch (ease)
        {
            case Ease.In:
                _moveComponent.AddMove(new MoveEaseIn(go, begin, end, time, pingPong));
                break;
            case Ease.Out:
                _moveComponent.AddMove(new MoveEaseOut(go, begin, end, time, pingPong));
                break;
            case Ease.InOut:
                _moveComponent.AddMove(new MoveEaseInOut(go, begin, end, time, pingPong));
                break;
            default:
                _moveComponent.AddMove(new Move(go, begin, end, time, pingPong));        
                break;
        }
    }
}