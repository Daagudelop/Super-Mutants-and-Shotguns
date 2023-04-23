using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GridSystemManager : MonoBehaviour
{

    public static GridSystemManager sharedInstanceGridSystemManager;

    public Grid gridPrefab;
    public int matrixColumns;
    public int matrixLines;
    public int cellSize;
    private Transform gridStartPosisition;

    //********************************
    //  Unity methods

    private void Awake()
    {
        GenerateGridMesh();
    }

    void Start()
    {
        initializeSingleton();
    }

    void Update()
    {
        
    }
    //********************************

    private void initializeSingleton()
    {
        if (sharedInstanceGridSystemManager == null)
        {
            sharedInstanceGridSystemManager = this;
        }
    }

    private void GenerateGridMesh()
    {
        gridStartPosisition = GameObject.FindWithTag("StartPoint").GetComponent<Transform>();

        int[,] abstractMatrix = new int[matrixColumns, matrixLines];

        for (int i = 0; i < abstractMatrix.GetLength(0); i++)
        {
            for(int j = 0; j < abstractMatrix.GetLength(1); j++)
            {
                InstantiateGrid(i, j);
            }
        }
        
    }

    private void InstantiateGrid(int i, int j)
    {
        gridPrefab = Instantiate(gridPrefab);
        gridPrefab.transform.position = CalculateWorldPosition(i, j) + new Vector3(cellSize,cellSize) * 0.5f;


        // debbuging sector ******************************************
        Debug.DrawLine( //linea inferior
            CalculateWorldPosition(i, j), 
            CalculateWorldPosition(i + cellSize, j),
            Color.white, 1000f);
        Debug.DrawLine( //linea izquierda
            CalculateWorldPosition(i, j), 
            CalculateWorldPosition(i, j + cellSize), 
            Color.white, 1000f);
        Debug.DrawLine( //linea derecha
            CalculateWorldPosition(i + cellSize, j + cellSize), 
            CalculateWorldPosition(i + cellSize, j), 
            Color.white, 1000f);
        Debug.DrawLine( //linea superior
            CalculateWorldPosition(i + cellSize, j + cellSize), 
            CalculateWorldPosition(i, j + cellSize), 
            Color.white, 1000f);
        //************************************************************
    }

    


    private Vector3 CalculateWorldPosition(int i, int j)
    {
        return new Vector3(i+gridStartPosisition.position.x, j + gridStartPosisition.position.y, 0) * cellSize ;
    }

    // debbuging sector ******************************************

    //TODO: logica de debbug lines para crear las lineas de casillas.
    //private void DebbugCentral()
    //{
    //    DebugLines();
    //    DebugLines();
    //    DebugLines();
    //    DebugLines();
    //}
    //private void DebugLines(int i, int j, int x, int y)
    //{
    //    Debug.DrawLine( 
    //        CalculateWorldPosition(i, j),
    //        CalculateWorldPosition(x, y),
    //        Color.white);
    //}
}
