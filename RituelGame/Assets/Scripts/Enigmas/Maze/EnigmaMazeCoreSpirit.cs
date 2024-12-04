using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class EnigmaMazeCoreSpirit : MonoBehaviour
{
    public MazePattern _mazePatternScript;

    public List<MazeStruct> _mazeStructures = new();
    
    public GameObject _mazeFramePrefab;
    public GameObject _mazes;
    public Transform _mazeFrameStartPosition;
    
    [SerializeField] private float windScale;
    
    [SerializeField] private int frameScale;
    [SerializeField] private int gridLenght = 12;
    [SerializeField] private Vector2 paternOffsetX;
    [SerializeField] private Vector2 paternOffsetY;
    
    public void CheckIfFull()
    {
        if (_mazeStructures.Count == _mazePatternScript._maxPaternNumber)
        {
            DrawMaze();
        }
    }

    private void DrawMaze()
    {
        for (int k = 0; k < _mazePatternScript._maxPaternNumber; k++)
        {
            MazeStruct mazeStruct = _mazeStructures[k];
            
            int cicle = k;
            
            if (k >= _mazePatternScript._maxPaternNumber / 2)
            {
                paternOffsetY.y = -16;
                cicle = cicle - _mazePatternScript._maxPaternNumber / 2;
            }
            
            GameObject mazeStartPosition = Instantiate(new GameObject(),
                (Vector2)_mazeFrameStartPosition.position + cicle * paternOffsetX + paternOffsetY,
                Quaternion.identity,
                _mazes.transform);
            
            for (int i = 0; i < gridLenght; i++)
            {
                for (int j = 0; j < gridLenght; j++)
                {
                    Vector2 mazeFramePos = new Vector2(
                        mazeStartPosition.transform.position.x + i * frameScale,
                        mazeStartPosition.transform.position.y + j * frameScale);

                    GameObject mazeFrame = Instantiate(_mazeFramePrefab, mazeFramePos, Quaternion.identity,
                        mazeStartPosition.transform);

                    mazeFrame.layer = LayerMask.NameToLayer(mazeStruct._mazeLayer);
                    
                    if (mazeStruct._mazePattern[i, j] == 1)
                    {
                        mazeFrame.GetComponent<SpriteRenderer>().color = Color.black;
                    }
                }
            }

            mazeStartPosition.transform.position = new Vector2(
                mazeStartPosition.transform.position.x + gridLenght / 2,
                mazeStartPosition.transform.position.y + gridLenght / 2);
            
            mazeStartPosition.transform.rotation = Quaternion.Euler(0, 0, mazeStruct._mazeRotation);
            
            mazeStartPosition.transform.position += ReplaceMaze(mazeStruct._mazeRotation);
            
            GameObject windRose = Instantiate(mazeStruct._mazeWindRose, new Vector2(
                    mazeStartPosition.transform.position.x + gridLenght * windScale - ReplaceMaze(mazeStruct._mazeRotation).x,
                    mazeStartPosition.transform.position.y + gridLenght / windScale - ReplaceMaze(mazeStruct._mazeRotation).y),
                Quaternion.identity,
                mazeStartPosition.transform);
        }
    }

    private Vector3 ReplaceMaze(float rotation)
    {
        switch (rotation)
        {
            case 90:
                return Vector2.right * (gridLenght - 1);
            case 180:
                return new Vector2((gridLenght - 1), (gridLenght - 1));
            case -90:
                return Vector2.up * (gridLenght - 1);
        }
        
        return Vector2.zero;
    }
}
