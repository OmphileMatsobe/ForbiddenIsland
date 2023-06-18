using UnityEngine;

[System.Serializable]
public class Tile : MonoBehaviour
{
    [SerializeField] public TileManager tileManager;
    [SerializeField] public GameManager gameManager;
    public TileInfo tileInfo;
    public SpriteRenderer spriteRenderer;
    public TileInfo.State CurrentState;
    public TileInfo.treasureOnTile TreasureOnTile;
    public TileInfo.PlayerPieceStart PlayerPieceStart;

    public void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        CurrentState = TileInfo.State.Default;
        TreasureOnTile = tileInfo.currentTreasure;
        gameObject.name = tileInfo.tileName;
        PlayerPieceStart = tileInfo.playerPieceStart;
    }

    public void Update()
    {
        if (spriteRenderer != null)
        {
            switch (CurrentState)
            {
                case TileInfo.State.Default:
                    spriteRenderer.sprite = tileInfo.Default;
                    break;
                case TileInfo.State.Flooded:
                    spriteRenderer.sprite = tileInfo.Flooded;
                    break;
                case TileInfo.State.Sunk:
                    spriteRenderer.sprite = tileInfo.Sunk;
                    break;
            }
        }
    }
}

