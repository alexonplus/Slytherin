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

    [Fact]
    public void Move_Left_DecreasesX()
    {
        var snake = new Snake(10, 10);
        snake.Direction = Direction.Left;
        snake.Move();
        Assert.Equal(9, snake.HeadX);
    }

    [Fact]
    public void Move_Right_IncreasesX()
    {
        var snake = new Snake(10, 10);
        snake.Direction = Direction.Right;
        snake.Move();
        Assert.Equal(11, snake.HeadX);
    }

    [Fact]
    public void Move_Up_DecreasesY()
    {
        var snake = new Snake(10, 10);
        snake.Direction = Direction.Up;
        snake.Move();
        Assert.Equal(9, snake.HeadY);
    }




}