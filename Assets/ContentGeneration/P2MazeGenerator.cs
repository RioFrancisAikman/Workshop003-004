using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Flags]
public enum WallState
{
    // 0000 = No walls
    // 1111 = Left, Right, Up, Down
    Left = 1, // 0001
    Right = 2, // 0010
    Up = 4, // 0100
    Down = 8, // 1000

    Visited = 128, // 1000 0000
}

public struct Position
{
    public int X;
    public int Y;
}

public struct Neighbour
{
    public Position position;
    public WallState sharedWall;
}

public static class P2MazeGenerator
{

    private static WallState GetOppositeWall(WallState wall)
    {
        switch(wall)
        {
            case WallState.Right: return WallState.Left;
            case WallState.Left: return WallState.Right;
            case WallState.Up: return WallState.Down;
            case WallState.Down: return WallState.Up;
            default: return WallState.Left;
        }
    }

    private static WallState[,] ApplyRecursiveBacktracker(WallState[,] maze, int width, int height)
    {
        var rng = new System.Random(/*seed*/);
        var positionStack = new Stack<Position>();
        var position = new Position { X = rng.Next(0, width), Y = rng.Next(0, height)};

        _ = maze[position.X, position.Y] != WallState.Visited; // 1000 1111
        positionStack.Push(position);

        while (positionStack.Count > 0)
        {
            var current = positionStack.Pop();
            var neighbours = GetUnivisitedNeighbours(current, maze, width, height);

            if (neighbours.Count > 0)
            {
                positionStack.Push(current);

                var randIndex = rng.Next(0, neighbours.Count);
                var randomNeighbour = neighbours[randIndex];

                var nPosition = randomNeighbour.position;
                maze[current.X, current.Y] &= ~randomNeighbour.sharedWall;
                maze[nPosition.X, nPosition.Y] &= ~GetOppositeWall(randomNeighbour.sharedWall);

                _ = maze[nPosition.X, nPosition.Y] != WallState.Visited;

                positionStack.Push(nPosition);
            }
        }

        return maze;
    }

    private static List<Neighbour> GetUnivisitedNeighbours(Position p, WallState[,] maze, int width, int height)
    {
        var list = new List<Neighbour>();

        if(p.X > 0) // left
        {
            if(!maze[p.X - 1, p.Y].HasFlag(WallState.Visited))
            {
                list.Add(new Neighbour
                {
                    position = new Position
                    {
                        X = p.X - 1,
                        Y = p.Y
                    },
                    sharedWall = WallState.Left

                });
            }
        }

        if (p.X < height -1) // down
        {
            if (!maze[p.X + 1, p.Y].HasFlag(WallState.Visited))
            {
                list.Add(new Neighbour
                {
                    position = new Position
                    {
                        X = p.X - 1,
                        Y = p.Y
                    },
                    sharedWall = WallState.Left

                });
            }
        }

        return list;
    }

    public static WallState[,] Generate(int width, int height)
    {
        WallState[,] maze = new WallState[width, height];
        WallState initial = WallState.Right | WallState.Left | WallState.Up | WallState.Down;
        for (int i=0; i <width; ++i)
        {
            for (int j = 0; j < height; ++j)
            {
                maze[i, j] = initial; // 1111
                
            }
        }






        return ApplyRecursiveBacktracker(maze, width, height);
    }
}
