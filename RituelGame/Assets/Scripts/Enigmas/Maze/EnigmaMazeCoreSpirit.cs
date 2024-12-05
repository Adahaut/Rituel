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
    
    public void DrawIfFull()
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
            MazeStruct mazeStruct = _mazeStructures[k]; //taking each structures in the list _mazeStructures
            
        //----------------------------------------------------
        //In order to place the 2 firsts mazes on top of the 2 after,
        //we set an OffSet on the Y axis when we are at the middle number of mazes.
            int cicle = k;
            
            if (k >= _mazePatternScript._maxPaternNumber / 2)
            {
                paternOffsetY.y = -16;
                cicle = cicle - _mazePatternScript._maxPaternNumber / 2;
            }
        //-----------------------------------------------------
            
        //creating the start position of the maze to create the maze in the right place.
            GameObject mazeStartPosition = Instantiate(new GameObject(),
                (Vector2)_mazeFrameStartPosition.position + cicle * paternOffsetX + paternOffsetY,
                Quaternion.identity,
                _mazes.transform);
            
            for (int i = 0; i < gridLenght; i++)
            {
                for (int j = 0; j < gridLenght; j++)
                {
                    //Setting the position of the frame
                    Vector2 mazeFramePos = new Vector2(
                        mazeStartPosition.transform.position.x + i * frameScale,
                        mazeStartPosition.transform.position.y + j * frameScale);

                    //Instantiating the frame at "mazeFramePos", and placing it in "mazeStartPosition".
                    GameObject mazeFrame = Instantiate(_mazeFramePrefab, mazeFramePos, Quaternion.identity,
                        mazeStartPosition.transform);
                    
                    //Ging the right layer to the maze in order to check wich maze we click on after.
                    mazeFrame.layer = LayerMask.NameToLayer(mazeStruct._mazeLayer);
                    
                    if (mazeStruct._mazePattern[i, j] == 1) //Setting th color of the frame according to if it's a wall or not.
                    {
                        mazeFrame.GetComponent<SpriteRenderer>().color = Color.black;
                    }
                }
            }
            
            //-----------------------------
            //Rotating the maze according to the rotation given in the struct
            mazeStartPosition.transform.position = new Vector2(
                mazeStartPosition.transform.position.x + gridLenght / 2,
                mazeStartPosition.transform.position.y + gridLenght / 2);
            
            mazeStartPosition.transform.rotation = Quaternion.Euler(0, 0, mazeStruct._mazeRotation);
            
            mazeStartPosition.transform.position += ReplaceMaze(mazeStruct._mazeRotation);
            //------------------------------
            
            //placing the windRose with the rotation of the maze
            GameObject windRose = Instantiate(mazeStruct._mazeWindRose, new Vector2(
                    mazeStartPosition.transform.position.x + gridLenght * windScale - ReplaceMaze(mazeStruct._mazeRotation).x,
                    mazeStartPosition.transform.position.y + gridLenght / windScale - ReplaceMaze(mazeStruct._mazeRotation).y),
                Quaternion.identity,
                mazeStartPosition.transform);
        }
    }

    private Vector3 ReplaceMaze(float rotation) //after rotating, we replace the maze in his place.
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
