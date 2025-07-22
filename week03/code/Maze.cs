using System;
using System.Collections.Generic;

public class Maze
{
    private readonly Dictionary<(int, int), bool[]> _mazeMap;
    private int _currX = 1;
    private int _currY = 1;

    public Maze(Dictionary<(int, int), bool[]> mazeMap)
    {
        _mazeMap = mazeMap;
    }

    public void MoveLeft()
    {
        var options = _mazeMap[(_currX, _currY)];
        if (options[0])
            _currX--;
        else
            throw new InvalidOperationException("Can't go that way!");
    }

    public void MoveRight()
    {
        var options = _mazeMap[(_currX, _currY)];
        if (options[1])
            _currX++;
        else
            throw new InvalidOperationException("Can't go that way!");
    }

    public void MoveUp()
    {
        var options = _mazeMap[(_currX, _currY)];
        if (options[2])
            _currY--;
        else
            throw new InvalidOperationException("Can't go that way!");
    }

    public void MoveDown()
    {
        var options = _mazeMap[(_currX, _currY)];
        if (options[3])
            _currY++;
        else
            throw new InvalidOperationException("Can't go that way!");
    }

    public string GetStatus()
    {
        return $"Current location (x={_currX}, y={_currY})";
    }
}