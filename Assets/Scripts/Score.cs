using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Score : MonoBehaviour
{
    [FormerlySerializedAs("PointPreFab")]
    public GameObject pointPreFab;
    private static int _blueScore;
    private static int _displayedBlueScore;
    private static List<GameObject> _blueDots;
    private static int _orangeScore;
    private static MeshFilter _cameraMesh;

    private void Start()
    {
        _blueScore = ScoreManager.instance.blueTeamScore;
        _orangeScore = ScoreManager.instance.orangeTeamScore;
        _blueDots = new List<GameObject>();
    }

    private void Update()
    {
        _blueScore = ScoreManager.instance.blueTeamScore;
        _orangeScore = ScoreManager.instance.orangeTeamScore;
        if (_blueScore <= 0) return;
        if (_blueScore != _blueDots.Count)
        {
            foreach (var dot in _blueDots)
            {
                Destroy(dot);
            }
            _blueDots.Clear();
            for (var i = 0; i < _blueScore; i++)
            {
                var pointInstance = Instantiate(pointPreFab);
                var pointSpriteRenderer = pointInstance.GetComponent<SpriteRenderer>();
                pointSpriteRenderer.color = new Color(1f, 0.51f, 0.01f);
                pointInstance.transform.position =
                    new Vector3(transform.position.x + (0.2f * (i+1)) - 0.6f, transform.position.y + 0.5f, 2);
                pointSpriteRenderer.sortingOrder = 3;
                _blueDots.Add(pointInstance);
            }
        }
        else
        {
            for (var i = 0; i < _blueScore; i++)
            {
                _blueDots[i].transform.position = new Vector3(transform.position.x + (0.2f * (i+1)) -0.6f, transform.position.y + 0.5f, 2);
            }
        }
    }

}
