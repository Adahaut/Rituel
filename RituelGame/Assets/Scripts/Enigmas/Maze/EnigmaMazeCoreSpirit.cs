using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class EnigmaMazeCoreSpirit : MonoBehaviour
{
    public MazePattern _mazePatternScript;

    public List<MazeStruct> _mazeStructures = new();
    
    public GameObject _mazeFramePrefab;
    public GameObject _mazes;
    public Transform _mazeFrameStartPosition;
    
    [SerializeField] private Vector2 windScale;
    
    [FormerlySerializedAs("frameScale")] [SerializeField] public int _frameScale;
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
                cicle -= _mazePatternScript._maxPaternNumber / 2;
            }
        //-----------------------------------------------------
            
        //creating the start position of the maze to create the maze in the right place.
            GameObject mazeStartPosition = Instantiate(new GameObject(),
                (Vector2)_mazeFrameStartPosition.position + cicle * paternOffsetX * _frameScale + paternOffsetY * _frameScale,
                Quaternion.identity,
                _mazes.transform);
            mazeStartPosition.AddComponent<Canvas>();
            mazeStartPosition.AddComponent<GraphicRaycaster>();

            GameObject pivotParent = new GameObject("parentPivot");
            pivotParent.transform.SetParent(mazeStartPosition.transform, true);
            pivotParent.transform.position = (Vector2)mazeStartPosition.transform.position +
                Vector2.one * _frameScale * gridLenght / 2f - (Vector2.one * _frameScale / 2f);
            
            for (int i = 0; i < gridLenght; i++)
            {
                for (int j = 0; j < gridLenght; j++)
                {
                    //Setting the position of the frame
                    Vector2 mazeFramePos = new Vector2(
                        mazeStartPosition.transform.position.x + i * _frameScale,
                        mazeStartPosition.transform.position.y + j * _frameScale);

                    //Instantiating the frame at "mazeFramePos", and placing it in "mazeStartPosition".
                    GameObject mazeFrame = Instantiate(_mazeFramePrefab, mazeFramePos, Quaternion.identity,
                        mazeStartPosition.transform);
                    mazeFrame.GetComponent<RectTransform>().sizeDelta = Vector2.one * _frameScale;
                    mazeFrame.transform.SetParent(pivotParent.transform, true);
                    
                    //Ging the right layer to the maze in order to check wich maze we click on after.
                    mazeFrame.layer = LayerMask.NameToLayer(mazeStruct._mazeLayer);
                    
                    if (mazeStruct._mazePattern[i, j] == 1) //Setting th color of the frame according to if it's a wall or not.
                    {
                        mazeFrame.GetComponent<Image>().color = Color.black;
                    }
                }
            }
            
            //-----------------------------
            //Rotating the maze according to the rotation given in the struct
            pivotParent.transform.position = new Vector2(
                mazeStartPosition.transform.position.x + _frameScale * gridLenght / 2f,
                mazeStartPosition.transform.position.y + _frameScale * gridLenght / 2f);
            
            pivotParent.transform.rotation = Quaternion.Euler(0, 0, mazeStruct._mazeRotation);
            
            //mazeStartPosition.transform.position += ReplaceMaze(mazeStruct._mazeRotation);
            //------------------------------
            
            //placing the windRose with the rotation of the maze
            GameObject windRose = Instantiate(mazeStruct._mazeWindRose, new Vector2(
                    mazeStartPosition.transform.position.x + gridLenght * windScale.x - ReplaceMaze(mazeStruct._mazeRotation).x,
                    mazeStartPosition.transform.position.y + gridLenght * windScale.y - ReplaceMaze(mazeStruct._mazeRotation).y),
                Quaternion.identity,
                mazeStartPosition.transform);
            windRose.transform.SetParent(pivotParent.transform);
        }
    }

    private Vector3 ReplaceMaze(float rotation) //after rotating, we replace the maze in his place.
    {
        return Vector2.zero;
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
