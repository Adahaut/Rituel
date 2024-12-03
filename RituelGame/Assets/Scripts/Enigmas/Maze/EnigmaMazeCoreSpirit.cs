using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnigmaMazeCoreSpirit : MonoBehaviour
{
    public GameObject _mazeFramePrefab;
    public Transform _mazeFrameStartPosition;
    
    private int[,] mazeArray =
    {
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 1, 1},
        { 1, 0, 0, 1, 0, 1, 1, 0, 1, 0, 0, 1},
        { 1, 0, 0, 1, 0, 0, 0, 0, 1, 1, 0, 1},
        { 1, 1, 0, 0, 1, 0, 0, 1, 0, 0, 0, 1},
        { 1, 0, 1, 0, 1, 1, 0, 1, 0, 1, 1, 1},
        { 1, 0, 0, 0, 1, 0, 0, 1, 0, 1, 1, 1},
        { 1, 0, 1, 0, 1, 0, 1, 0, 0, 0, 1, 1},
        { 1, 1, 1, 0, 0, 0, 1, 0, 1, 0, 1, 1},
        { 1, 0, 0, 0, 1, 0, 0, 1, 1, 0, 1, 1},
        { 1, 0, 1, 0, 1, 1, 0, 1, 0, 0, 1, 1},
        { 1, 0, 0, 0, 0, 0, 0, 0, 0, 1, 1, 1},
        { 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1}
    };
    
    [SerializeField] private int frameScale;
    [SerializeField] private int gridLenght = 12;
    
    private void Start()
    {
        DrawMaze();
    }
    
    private void DrawMaze()
    {
        for (int i = 0; i < gridLenght; i++)
        {
            for (int j = 0; j < gridLenght; j++)
            {
                Vector2 mazeFramePos = new Vector2(
                    _mazeFrameStartPosition.position.x + i * frameScale,
                    _mazeFrameStartPosition.position.y + j * frameScale);
                
                GameObject mazeFrame = Instantiate(_mazeFramePrefab, mazeFramePos, Quaternion.identity);

                if(mazeArray[i, j] == 1)
                {
                    mazeFrame.GetComponent<SpriteRenderer>().color = Color.black;
                }
            }
        }
    }
}
