using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnigmaMazeCoreSpirit : MonoBehaviour
{
    public MazePaterns _mazePaterns;
    
    public GameObject _mazeFramePrefab;
    public Transform _mazeFrameStartPosition;

    private int[,] mazeArray;
    
    [SerializeField] private GameObject windRose;
    [SerializeField] private float windScale;
    
    [SerializeField] private int frameScale;
    [SerializeField] private int gridLenght = 12;
    [SerializeField] private int paternOffsets = 2;
    
    private void Start()
    {
        mazeArray = _mazePaterns.Paterns();
        DrawMaze();
    }

    private void DrawMaze()
    {
        for (int k = 0; k < _mazePaterns.paternNumber; k++)
        {
            Vector2 paternOffset = new Vector2(0.0f, k * gridLenght + k * paternOffsets);
            mazeArray = _mazePaterns.SpiritMaze(k);
            
            GameObject mazeStartPosition = Instantiate(new GameObject(),
                (Vector2)_mazeFrameStartPosition.position + paternOffset,
                Quaternion.identity,
                _mazeFrameStartPosition);
            
            
            for (int i = 0; i < gridLenght; i++)
            {
                for (int j = 0; j < gridLenght; j++)
                {
                    Vector2 mazeFramePos = new Vector2(
                        mazeStartPosition.transform.position.x + i * frameScale,
                        mazeStartPosition.transform.position.y + j * frameScale);

                    GameObject mazeFrame = Instantiate(_mazeFramePrefab, mazeFramePos, Quaternion.identity, mazeStartPosition.transform);

                    if (mazeArray[i, j] == 1)
                    {
                        mazeFrame.GetComponent<SpriteRenderer>().color = Color.black;
                    }
                }
                
            }
            
            windRose = Instantiate(windRose, new Vector2(
                    mazeStartPosition.transform.position.x + gridLenght * windScale,
                    mazeStartPosition.transform.position.y + gridLenght / windScale),
                    Quaternion.identity);

            _mazeFrameStartPosition.transform.rotation = Quaternion.Euler(0, 0, -90.0f);
        }
    }
}
