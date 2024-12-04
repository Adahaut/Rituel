using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class EnigmaMazeCoreSpirit : MonoBehaviour
{
    public MazePaterns _mazePaterns;
    
    public GameObject _mazeFramePrefab;
    public GameObject _mazes;
    public Transform _mazeFrameStartPosition;

    private int[,] mazeArray;
    
    [SerializeField] private GameObject windRose;
    [SerializeField] private float windScale;
    
    [SerializeField] private int frameScale;
    [SerializeField] private int gridLenght = 12;
    [SerializeField] private Vector2 paternOffsetX;
    [SerializeField] private Vector2 paternOffsetY;
    
    private void Start()
    {
        DrawMaze();
    }

    private void DrawMaze()
    {
        for (int k = 0; k < _mazePaterns._maxPaternNumber; k++)
        {
            int cicle = k;
            
            if (k >= _mazePaterns._maxPaternNumber / 2)
            {
                paternOffsetY.y = -16;
                cicle = cicle - _mazePaterns._maxPaternNumber / 2;
            }
            
            Debug.Log(cicle);
            
            GameObject mazeStartPosition = Instantiate(new GameObject(),
                (Vector2)_mazeFrameStartPosition.position + cicle * paternOffsetX + paternOffsetY,
                Quaternion.identity,
                _mazes.transform);
            
            mazeArray = _mazePaterns.SpiritMaze(k);
            
            for (int i = 0; i < gridLenght; i++)
            {
                for (int j = 0; j < gridLenght; j++)
                {
                    Vector2 mazeFramePos = new Vector2(
                        mazeStartPosition.transform.position.x + i * frameScale,
                        mazeStartPosition.transform.position.y + j * frameScale);

                    GameObject mazeFrame = Instantiate(_mazeFramePrefab, mazeFramePos, Quaternion.identity,
                        mazeStartPosition.transform);

                    if (mazeArray[i, j] == 1)
                    {
                        mazeFrame.GetComponent<SpriteRenderer>().color = Color.black;
                    }
                }
            }
            
            float windRoseRotation = _mazePaterns.SetMazeRotation(k);

            mazeStartPosition.transform.position = new Vector3(
                mazeStartPosition.transform.position.x + gridLenght / 2,
                mazeStartPosition.transform.position.y + gridLenght / 2,
                0.0f);
            
            mazeStartPosition.transform.rotation = Quaternion.Euler(0, 0, windRoseRotation);
            
            mazeStartPosition.transform.position += ReplaceMaze(windRoseRotation);
            
            windRose = Instantiate(_mazePaterns.GetWindRoseSprite(k), new Vector2(
                    mazeStartPosition.transform.position.x + gridLenght * windScale - ReplaceMaze(windRoseRotation).x,
                    mazeStartPosition.transform.position.y + gridLenght / windScale - ReplaceMaze(windRoseRotation).y),
                Quaternion.identity);
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
