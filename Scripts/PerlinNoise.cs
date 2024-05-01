using System.Collections.Generic;
using UnityEngine;

public class PerlinNoise : MonoBehaviour
{
    [SerializeField] private float _mapWidth;
    [SerializeField] private float _mapHeight;
    [SerializeField] private List<float> _heights = new List<float>();
    [SerializeField] [Range(1,100)] private float _perlinNoiseHeight;

    [SerializeField] private float _xShift;
    [SerializeField] private float _zShift;

    [SerializeField] private GameObject _cube;

    private void Start()
    {
        CreateHeights();
        CreateMap();
    }

    private void CreateMap()
    {
        int num = 0;
        for (int i = 0; i < _mapHeight; i++)
        {
            for (int j = 0; j < _mapWidth; j++)
            {
                var cube = Instantiate(_cube);
                cube.transform.position = new Vector3(i, _heights[num] * _perlinNoiseHeight, j);
                num++;
            }
        }
    }

    private void CreateHeights()
    {
        for (int i = 0; i < _mapHeight; i++)
        {
            for (int j = 0; j < _mapWidth; j++)
            {
                float xPer = _xShift + j / _mapWidth;
                float zPer = _zShift + i / _mapHeight;
                float yPos = Mathf.PerlinNoise(xPer, zPer);
                _heights.Add(yPos);
            }
        }
    }
}
