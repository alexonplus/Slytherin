namespace SnakeGame;

public class GameBoard
{
    private readonly Tile[,] _tiles;

    public GameBoard(int width, int height)
    {
        Width = width;
        Height = height;
        _tiles = new Tile[width, height];
    }

    public int Width { get; }
    public int Height { get; }

    public Tile GetTile(int x, int y) => _tiles[x, y];
    public void SetTile(int x, int y, Tile tile) => _tiles[x, y] = tile;

    public bool IsWallCollision(int x, int y)
    {
        return x < 0 || x >= Width || y < 0 || y >= Height;
    }

    public bool IsSnakeCollision(int x, int y)
    {
        if (IsWallCollision(x, y)) return false;
        return _tiles[x, y] == Tile.Snake;
    }
}