namespace SnakeGame;

public class SnakeGameLogic
{
    private readonly GameBoard _board;
    private readonly Snake _snake;
    private readonly Food _food;
    private readonly Random _random;

    public SnakeGameLogic(GameBoard board, Snake snake, Food food, Random random)
    {
        _board = board;
        _snake = snake;
        _food = food;
        _random = random;

        _board.SetTile(snake.HeadX, snake.HeadY, Tile.Snake);
        _food.PlaceRandomly(_board, _random);
    }

    public bool IsGameOver { get; private set; }
    public Snake Snake => _snake;
    public Food Food => _food;
    public GameBoard Board => _board;

    public TickResult Tick()
    {
        _snake.Move();

        if (_board.IsWallCollision(_snake.HeadX, _snake.HeadY) ||
            _board.IsSnakeCollision(_snake.HeadX, _snake.HeadY))
        {
            IsGameOver = true;
            return TickResult.GameOver;
        }

        var ateFood = _board.GetTile(_snake.HeadX, _snake.HeadY) == Tile.Food;

        if (ateFood)
        {
            _board.SetTile(_snake.HeadX, _snake.HeadY, Tile.Snake);
            _food.PlaceRandomly(_board, _random);
            return TickResult.AteFood;
        }
        else
        {
            var tail = _snake.RemoveTail();
            _board.SetTile(tail.X, tail.Y, Tile.Open);
            _board.SetTile(_snake.HeadX, _snake.HeadY, Tile.Snake);
            return TickResult.Moved;
        }
    }
}

public enum TickResult
{
    Moved,
    AteFood,
    GameOver,
}