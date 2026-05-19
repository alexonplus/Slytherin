using Xunit;
using SnakeGame;

namespace SnakeGame.Tests;

public class SnakeTests
{
    [Fact]
    public void Move_Down_IncreasesY()
    {
        var snake = new Snake(10, 10);
        snake.Direction = Direction.Down;

        snake.Move();

        Assert.Equal(11, snake.HeadY);
    }
}