using JellySmash.Presenter.Screen.Play;
using System.Collections;
using UnityEngine;

namespace JellySmash.Extensions
{
    public class SwipeDrawer : MonoBehaviour
    {
        [SerializeField]
        private float _lineDrawSpeed;

        [SerializeField]
        private LineRenderer _lineRenderer;

        [SerializeField]
        private GameObject _lineRendererPrefab;

        private float _counter;

        private void Awake()
        {
            GridPresenter.OnDrawLine += DrawLine;
            GridPresenter.OnResetLine += ResetLine;
        }

        private void OnDestroy()
        {
            GridPresenter.OnDrawLine -= DrawLine;
            GridPresenter.OnResetLine -= ResetLine;
        }

        private void ResetLine()
        {
            _lineRenderer.positionCount = 0;
        }

        private void DrawLine(Vector3[] positions)
        {
            if (!IsValidLine(positions.Length))
            {
                ResetLine();
                return;
            }

            int count = positions.Length - 1;
            _lineRenderer.positionCount = count + 1;

            Vector3[] positionsForLine = GetArray(positions, count);
            _lineRenderer.SetPositions(positionsForLine);

            StartCoroutine(AnimateLine(positions[count - 1], positions[count], count));
        }

        private bool IsValidLine(int posCount)
        {
            return posCount > 1;
        }

        private Vector3[] GetArray(Vector3[] positions, int count)
        {
            Vector3[] positionsForLine = new Vector3[count];
            for (int i = 0; i < count; i++)
            {
                positionsForLine[i] = positions[i];
            }

            return positionsForLine;
        }

        private IEnumerator AnimateLine(Vector3 startPos, Vector3 endPos, int positionIndex)
        {
            float dist = Vector3.Distance(startPos, endPos);
            _counter = 0;

            while (_counter < dist)
            {
                _counter += .1f / _lineDrawSpeed;

                float x = Mathf.Lerp(0, dist, _counter);
                Vector3 pointAlongLine = x * Vector3.Normalize(endPos - startPos) + startPos;

                _lineRenderer.SetPosition(positionIndex, pointAlongLine);
                yield return null;
            }
        }
    }
}
