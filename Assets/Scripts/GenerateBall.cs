using UnityEngine;
using UnityEngine.Serialization;

public class GenerateBall : MonoBehaviour
{
    [FormerlySerializedAs("BallPreFab")]
    public GameObject ballPreFab;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.B))
        {
            var ballInstance = Instantiate(ballPreFab);
            ballInstance.transform.position = Vector3.zero;
            // ballInstance.GetComponent<AnimatedBall>.Speed = Random.range(0.2f, 2f);
        }
    }
}
