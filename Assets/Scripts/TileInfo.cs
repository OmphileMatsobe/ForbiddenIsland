using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]

public class TileInfo : ScriptableObject
{
    public Sprite Default;
    public Sprite Flooded;
    public Sprite Sunk;
    public enum State
    {
        Default, Flooded, Sunk
    }

    public State currentState;
    public enum treasureOnTile
    {
        None, RedTreasure, YellowTreasure, BlueTreasure, GreyTreasure
    }
    public enum PlayerPieceStart
    {
        None, RedPiece, BlackPiece, GreenPiece, GreyPiece, YellowPiece, BluePiece
    }

    public treasureOnTile currentTreasure;
    public PlayerPieceStart playerPieceStart;
    public string tileName;

}
