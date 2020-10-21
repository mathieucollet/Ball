using UnityEngine;
using UnityEngine.Serialization;

public class Tracker : MonoBehaviour
{
    [FormerlySerializedAs("Target")] public GameObject target;
    [FormerlySerializedAs("DeadWindow")] public Vector2 deadWindow;
    [FormerlySerializedAs("FollowSpeed")] public float followSpeed = 0.02f;
    
    private Rect _rect;
    
    private void LateUpdate()
    {
        _rect = new Rect((Vector2)transform.position - deadWindow * 0.5f, deadWindow);
        if (_rect.Contains(target.transform.position)) return;
        var position = transform.position;
        var z = position.z;
        var nextPos = Vector3.Lerp(position, target.transform.position, followSpeed);
        nextPos.z = z;
        position = nextPos;
        transform.position = position;
    }
}