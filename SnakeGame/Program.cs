using SnakeGame;

int speedInput = ReadSpeed();
int[] velocities = [100, 70, 50];
TimeSpan sleep = TimeSpan.FromMilliseconds(velocities[speedInput - 1]);
char[] directionChars = ['^', 'v', '<', '>'];

int width = Console.WindowWidth;
int height = Console.WindowHeight;

var board = new GameBoard(width, height);
var snake = new Snake(width / 2, height / 2);
var food = new Food();
var game = new SnakeGameLogic(board, snake, food, Random.Shared);

bool closeRequested = false;
Exception? exception = null;

try
{
    Console.CursorVisible = false;
    Console.Clear();
    Console.SetCursorPosition(snake.HeadX, snake.HeadY);
    Console.Write('@');
    Console.SetCursorPosition(food.X, food.Y);
    Console.Write('+');

    while (!snake.Direction.HasValue && !closeRequested)
        ReadDirection();

    while (!closeRequested && !game.IsGameOver)
    {
        if (Console.WindowWidth != width || Console.WindowHeight != height)
        {
            Console.Clear();
            Console.Write("Console was resized. Snake game has ended.");
            return;
        }

        var prevTail = snake.Body.First();
        var result = game.Tick();

        if (result == TickResult.GameOver)
        {
            Console.Clear();
            Console.Write($"Game Over. Score: {snake.Length - 1}.");
            return;
        }

        Console.SetCursorPosition(snake.HeadX, snake.HeadY);
        Console.Write(directionChars[(int)snake.Direction!]);

        if (result == TickResult.AteFood)
        {
            Console.SetCursorPosition(food.X, food.Y);
            Console.Write('+');
        }
        else
        {
            Console.SetCursorPosition(prevTail.X, prevTail.Y);
            Console.Write(' ');
        }

        if (Console.KeyAvailable) ReadDirection();
        Thread.Sleep(sleep);
    }
}
catch (Exception e) { exception = e; throw; }
finally
{
    Console.CursorVisible = true;
    Console.Clear();
    Console.WriteLine(exception?.ToString() ?? "Snake was closed.");
}

void ReadDirection()
{
    switch (Console.ReadKey(true).Key)
    {
        case ConsoleKey.UpArrow: snake.Direction = Direction.Up; break;
        case ConsoleKey.DownArrow: snake.Direction = Direction.Down; break;
        case ConsoleKey.LeftArrow: snake.Direction = Direction.Left; break;
        case ConsoleKey.RightArrow: snake.Direction = Direction.Right; break;
        case ConsoleKey.Escape: closeRequested = true; break;
    }
}

int ReadSpeed()
{
    string prompt = "Select speed [1], [2] (default), or [3]: ";
    Console.Write(prompt);
    string? input;
    int value;
    while (!int.TryParse(input = Console.ReadLine(), out value) || value < 1 || value > 3)
    {
        if (string.IsNullOrWhiteSpace(input)) return 2;
        Console.WriteLine("Invalid Input. Try Again...");
        Console.Write(prompt);
    }
    return value;
}