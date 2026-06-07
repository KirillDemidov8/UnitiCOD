using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSorter : MonoBehaviour
{
    [SerializeField] private float spacing = 2.0f;
    [SerializeField] private Vector3 startPosition = Vector3.zero;

    private void Start()
    {
        SortAndLineUpCubes();
    }

    private void SortAndLineUpCubes()
    {
        GameObject[] cubes = GameObject.FindGameObjectsWithTag("SizeCube");

        if (cubes.Length == 0) return;

        BubbleSort(cubes);
        PositionCubesInLine(cubes);
    }

    private void BubbleSort(GameObject[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                float sizeJ = arr[j].transform.localScale.x * arr[j].transform.localScale.y * arr[j].transform.localScale.z;
                float sizeJ1 = arr[j + 1].transform.localScale.x * arr[j + 1].transform.localScale.y * arr[j + 1].transform.localScale.z;

                if (sizeJ < sizeJ1)
                {
                    GameObject temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    private void PositionCubesInLine(GameObject[] arr)
    {
        Vector3 currentPos = startPosition;

        for (int i = 0; i < arr.Length; i++)
        {
            float halfSizeCurrent = arr[i].transform.localScale.x / 2f;

            if (i > 0)
            {
                float halfSizePrevious = arr[i - 1].transform.localScale.x / 2f;
                currentPos.x += halfSizePrevious + spacing + halfSizeCurrent;
            }

            arr[i].transform.position = currentPos;
        }
    }
}