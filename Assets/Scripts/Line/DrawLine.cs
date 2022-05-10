using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLine : MonoBehaviour
{
    LineRenderer lineRenderer;
    EdgeCollider2D edgeCollider;
    List<Vector2> pointsV2;
    List<Vector3> pointsV3;
    Vector2 mousePos;
    Vector3 lineOffset;
    bool isDrawing;
    PlayerSettingsData playerData;
    Vector3 touchPos;

    private void Start()
    {
        playerData = SaveDatas.LoadData();
        lineRenderer = GetComponent<LineRenderer>();
        edgeCollider = GetComponent<EdgeCollider2D>();
        pointsV2 = new List<Vector2>();
        pointsV3 = new List<Vector3>();
        lineOffset = new Vector3(playerData.lineOffsetX, playerData.lineOffsetY, 0);

        SetCurve();
    }
    private void Update()
    {
        if (Time.timeScale != 0) Draw();
        else return;

        SetColliders();

        if (Input.GetKeyDown(KeyCode.Mouse0) && isDrawing) StopAllCoroutines();
        else if (Input.GetKeyUp(KeyCode.Mouse0)) StartCoroutine(Remove());
    }

    #region SetCurve
    private void SetCurve()
    {
        AnimationCurve curve = new AnimationCurve();
        curve.AddKey(0.0f, 0.0f);
        curve.AddKey(1.0f, 1.0f);
        lineRenderer.widthCurve = curve;
        lineRenderer.widthMultiplier = playerData.lineWidth;
    }
    #endregion

    #region Draw
    private void Draw()
    {
        if (Input.touchCount > 0)
        {
            edgeCollider.enabled = true;
            touchPos = new Vector3(Input.GetTouch(0).position.x, Input.GetTouch(0).position.y, 1);
            mousePos = Camera.main.ScreenToWorldPoint(touchPos + lineOffset);
            if (pointsV3.Count > 1)
            {
                if (Vector2.Distance(mousePos, pointsV3[pointsV3.Count - 1]) > 0.1f)
                {
                    isDrawing = true;
                    pointsV2.Add(mousePos);
                    pointsV3.Add(mousePos);
                    lineRenderer.positionCount = pointsV3.Count - 1;
                    lineRenderer.SetPositions(pointsV3.ToArray());
                }
            }
            else
            {
                pointsV3.Add(mousePos);
                pointsV2.Add(mousePos);
            }
            if (pointsV3.Count > 20)
            {
                pointsV3.RemoveAt(pointsV3.Count - 21);
                pointsV2.RemoveAt(pointsV2.Count - 21);
            }
        }
    }
    #endregion

    #region SetColliders
    private void SetColliders()
    {
        if (edgeCollider.pointCount > 20)
        {
            edgeCollider.Reset();
            edgeCollider.points = pointsV2.ToArray();
            edgeCollider.enabled = false;
            edgeCollider.enabled = true;
        }
        edgeCollider.points = pointsV2.ToArray();
    }
    #endregion

    #region Remove
    private IEnumerator Remove()
    {
        isDrawing = false;
        yield return new WaitForSeconds(0f);
        pointsV2.Clear();
        pointsV3.Clear();
        lineRenderer.positionCount = pointsV3.Count;
        edgeCollider.Reset();
        edgeCollider.enabled = false;
    }
    #endregion
}
