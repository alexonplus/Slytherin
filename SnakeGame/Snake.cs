namespace SnakeGame;

public class Snake
{
    private readonly Queue<(int X, int Y)> _body = new();

    public Snake(int startX, int startY)
    {
        HeadX = startX;
        HeadY = startY;
        _body.Enqueue((startX, startY));
    }

    public int HeadX { get; private set; }
    public int HeadY { get; private set; }
    public Direction? Direction { get; set; }
    public int Length => _body.Count;
    public IEnumerable<(int X, int Y)> Body => _body;

    public void Move()
    {
        switch (Direction)
        {
            case SnakeGame.Direction.Up: HeadY--; break;
            case SnakeGame.Direction.Down: HeadY++; break;
            case SnakeGame.Direction.Left: HeadX--; break;
            case SnakeGame.Direction.Right: HeadX++; break;
        }
        _body.Enqueue((HeadX, HeadY));
    }

    public (int X, int Y) RemoveTail() => _body.Dequeue();

    public bool ContainsBody(int x, int y)
    {
        foreach (var segment in _body)
        {
            if (segment.X == x && segment.Y == y) return true;
        }
        return false;
    }
}