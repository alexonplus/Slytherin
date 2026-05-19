namespace SnakeGame;

public class Food
{
    public int X { get; private set; }
    public int Y { get; private set; }

    public void PlaceRandomly(GameBoard board, Random random)
    {
        var possible = new List<(int X, int Y)>();
        for (int i = 0; i < board.Width; i++)
        {
            for (int j = 0; j < board.Height; j++)
            {
                if (board.GetTile(i, j) == Tile.Open)
                    possible.Add((i, j));
            }
        }
        if (possible.Count == 0) return;

        var index = random.Next(possible.Count);
        (X, Y) = possible[index];
        board.SetTile(X, Y, Tile.Food);
    }
}