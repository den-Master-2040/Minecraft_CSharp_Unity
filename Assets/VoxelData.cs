using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VoxelData : MonoBehaviour
{
    public readonly static int ChunkWidth = 5;
    public readonly static int ChunkHeight = 15;

    /*Vertex for cube*/
    public static readonly Vector3[] voxelVerts = new Vector3[8]
    {   
        new Vector3(0.0f, 0.0f, 0.0f),
        new Vector3(1.0f, 0.0f, 0.0f),
        new Vector3(1.0f, 1.0f, 0.0f),
        new Vector3(0.0f, 1.0f, 0.0f),
        new Vector3(0.0f, 0.0f, 1.0f),
        new Vector3(1.0f, 0.0f, 1.0f),
        new Vector3(1.0f, 1.0f, 1.0f),
        new Vector3(0.0f, 1.0f, 1.0f)
    };

    public static readonly Vector3[] faceChunks = new Vector3[6]
    {
        new Vector3(0.0f, 0.0f, -1.0f),
        new Vector3(0.0f, 0.0f, 1.0f),
        new Vector3(0.0f, 1.0f, 0.0f),
        new Vector3(0.0f, -1.0f, 0.0f),
        new Vector3(-1.0f, 0.0f, 0.0f),
        new Vector3(1.0f, 0.0f, 0.0f),
    };

    /*massive for read*/
    public static readonly int[,] voxelTris = new int[6, 4]
    {
        { 0, 3, 1, 2 },   // Back Face
        { 5, 6, 4, 7 },   // Front Face
        { 3, 7, 2, 6 },   // Top Face - ??????? ?????????
        { 1, 5, 0, 4 },   // Bottom Face
        { 4, 7, 0, 3 },   // Left Face
        { 1, 2, 5, 6 }    // Right Face
    };

    public static readonly Vector2[] voxelUvs = new Vector2[4]{
        new Vector2(0.0f, 0.0f),
        new Vector2(0.0f, 1.0f),
        new Vector2(1.0f, 0.0f),
        new Vector2(1.0f, 1.0f),
    };

}
