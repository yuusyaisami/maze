using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace maze
{
    internal class Maze
    {
        // 1 : startPoint, 995 : endPoint , 999 : wall , 0 : road
        /*static int[][] maze = { new int[] { 999, 999, 999, 999, 999},
                                new int[]   { 999,   0, 995,   0, 999},
                                new int[]   { 999,   0, 999,   0, 999},
                                new int[]   { 999,   1,   0,   0, 999},
                                new int[]   { 999, 999, 999, 999, 999} };*/

        static int[][] maze = { new int[] {   0, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999},
                                new int[] {   1,   0,   0,   0, 999,   0,   0,   0,   0, 999,   0, 999},
                                new int[] { 999,   0, 999,   0, 999, 999,   0, 999,   0,   0,   0, 999},
                                new int[] { 999,   0, 999,   0,   0,   0,   0,   0,   0,   0,   0, 999},
                                new int[] { 999, 999, 999,   0, 999,   0, 999, 999,   0,   0,   0, 999},
                                new int[] { 999,   0,   0,   0, 999,   0,   0, 999, 999, 999, 999, 999},
                                new int[] { 999, 999, 999, 999, 999, 999,   0,   0,   0,   0, 999, 999},
                                new int[] { 999, 999,   0,   0,   0, 999,   0, 999,   0,   0,   0, 999},
                                new int[] { 999,   0,   0, 999,   0, 999, 999, 999, 999, 999,   0, 999},
                                new int[] { 999, 999,   0, 999,   0,   0,   0, 999,   0,   0,   0, 999},
                                new int[] { 999, 999,   0, 999,   0, 999,   0, 999,   0,   0, 999, 999},
                                new int[] { 999,   0,   0, 999,   0, 999,   0,   0,   0,   0, 999, 999},
                                new int[] { 999, 999, 999, 999, 999, 999, 999, 999,   0, 999, 999, 999},
                                new int[] { 999, 995, 999, 999,   0, 999,   0, 999,   0,   0,   0, 999},
                                new int[] { 999,   0, 999,   0,   0,   0,   0,   0, 999, 999,   0, 999},
                                new int[] { 999,   0,   0,   0, 999,   0, 999,   0,   0, 999,   0, 999},
                                new int[] { 999,   0, 999,   0, 999,   0,   0, 999,   0,   0,   0, 999},
                                new int[] { 999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999, 999}};

        /*static int[][] maze = { new int[] {  1,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
                                new int[] {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
                                new int[] {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
                                new int[] {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
                                new int[] {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
                                new int[] {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
                                new int[] {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
                                new int[] {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
                                new int[] {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
                                new int[] {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
                                new int[] {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
                                new int[] {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0},
                                new int[] {  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  0,  995} };*/
        /*static int[][] maze = { new int[] {  1,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0},
                                new int[] {  0,  999,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0},
                                new int[] {  0,    0,  999,    0,    0,    0,    0,    0,    0,    0,    0,    0},
                                new int[] {  0,    0,    0,  999,    0,    0,    0,    0,    0,    0,    0,    0},
                                new int[] {  0,    0,    0,    0,  999,    0,    0,    0,    0,    0,    0,    0},
                                new int[] {  0,    0,    0,    0,    0,    0,    0,  995,    0,    0,    0,    0},
                                new int[] {  0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0},
                                new int[] {  0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0},
                                new int[] {  0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0},
                                new int[] {  0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0},
                                new int[] {  0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0},
                                new int[] {  0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0},
                                new int[] {  0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0,    0} };*/
        static int GOAL = 995;
        static int START = 1;
        static int ROAD = 0;
        static int OPTIMALROUTE = 990;
        static int WALL = 999;
        static int CANTGOAL = 0;
        static void Main(string[] args)
        {
            OutPutArray("First");
            //mazeをSから順番にカウントする
            int End = 0;
            CANTGOAL = 0;
            for (int Count = 1; ; Count++)
            {
                for (int i = 0; i < maze.GetLength(0); i++)
                {
                    for (int j = 0; j <  maze[i].Length; j++)
                    {
                        if (maze[i][j] == Count)
                        {
                            //配列から外れるので、制限する↓
                            if (i < maze.GetLength(0) - 1)
                                if (maze[i + 1][j] == ROAD)
                                {
                                    maze[i + 1][j] = Count + 1;
                                    End = 1;
                                }
                            if (j < maze[i].Length - 1)
                                if (maze[i][j + 1] == ROAD)
                                {
                                    maze[i][j + 1] = Count + 1;
                                    End = 1;
                                }
                            if (i != 0)
                                if (maze[i - 1][j] == ROAD)
                                {
                                    maze[i - 1][j] = Count + 1;
                                    End = 1;
                                }
                            if (j != 0)
                                if (maze[i][j - 1] == ROAD)
                                {
                                    maze[i][j - 1] = Count + 1;
                                    End = 1;
                                }
                        }
                    }
                }
                //処理が行われなかったら
                if (End == 1) End = 0;
                else if (End == 0) break;
                //ゴールにたどり着かない場合これになる
                else if (Count == WALL)
                {
                    CANTGOAL = 1;
                    break;
                }
            }
            OutPutArray("RoadValue");
            //mazeの最適ルートを90の数値にする
            int CountStep = 0;
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                //ゴールにたどり着いていない場合
                if (CANTGOAL == 1) break;
                for (int j = 0; j <  maze[i].Length; j++)
                {
                    //95 = Goal ,Goalの列と行を読み取る
                    if (maze[i][j] == GOAL)
                    {
                        int x = j;
                        int y = i;
                        int Value = 0;
                        CountStep = 0;
                        int Temp = 0, DirectionIndex;
                        for (int k = 0; ; k++)
                        {
                            DirectionIndex = 5;
                            if (CountStep == 0)
                            {
                                if (y < maze.GetLength(0) - 1 && Value == 0)
                                {
                                    if (maze[y + 1][x] == 1) Value = 2;
                                    Temp = maze[y + 1][x];
                                    DirectionIndex = 4;
                                }
                                if (x < maze[y].Length - 1&& Value == 0)
                                {
                                    if (maze[y][x + 1] == 1) Value = 2;
                                    if (Temp > maze[y][x + 1])
                                    {
                                        Temp = maze[y][x + 1];
                                        DirectionIndex = 2;
                                    }
                                }
                                if (y != 0 && Value == 0)
                                {
                                    if (maze[y - 1][x] == 1) Value = 2;
                                    if (Temp > maze[y - 1][x])
                                    {
                                        Temp = maze[y - 1][x];
                                        DirectionIndex = 1;
                                    }
                                }
                                if (x != 0 && Value == 0)
                                {
                                    if (maze[y][x - 1] == 1) Value = 2;
                                    if (Temp > maze[y][x - 1])
                                    {
                                        Temp = maze[y][x - 1];
                                        DirectionIndex = 3;
                                    }
                                }
                            }
                            CountStep++;
                            if (y < maze.GetLength(0) - 1 && Value == 0 )
                            {
                                if (DirectionIndex == 4 || DirectionIndex == 5)
                                {
                                    if (maze[y][x] > maze[y + 1][x])
                                    {
                                        if (maze[y][x] != GOAL) maze[y][x] = OPTIMALROUTE;
                                        y = y + 1;
                                        Value = 1;
                                    }
                                }
                            }
                            if (x < maze[y].Length - 1&& Value == 0)
                            {
                                if (DirectionIndex == 2 || DirectionIndex == 5)
                                {
                                    if (maze[y][x] > maze[y][x + 1])
                                    {
                                        if (maze[y][x] != GOAL) maze[y][x] = OPTIMALROUTE;
                                        x = x + 1;
                                        Value = 1;
                                    }
                                }
                            }
                            if (y != 0 && Value == 0)
                            {
                                if (DirectionIndex == 1|| DirectionIndex == 5)
                                {
                                    if (maze[y][x] > maze[y - 1][x])
                                    {
                                        if (maze[y][x] != GOAL) maze[y][x] = OPTIMALROUTE;
                                        y = y - 1;
                                        Value = 1;
                                    }
                                }
                            }
                            if (x != 0 && Value == 0)
                            {
                                if (DirectionIndex == 3 || DirectionIndex == 5)
                                {
                                    if (maze[y][x] > maze[y][x - 1])
                                    {
                                        if (maze[y][x] != GOAL)
                                            maze[y][x] = OPTIMALROUTE;
                                        x = x - 1;
                                        Value = 1;
                                    }
                                }
                            }
                            if(Value == 0 || Value == 2) break;
                            else Value = 0;
                        }
                    }
                }

            }
            OutPutArray("Finish");
            ConvertInttoStringArray("StringMaze");
            Console.WriteLine("Step : " + CountStep);
            Console.ReadLine();
        }
        static void OutPutArray(string Name)
        {
            Console.WriteLine("--------------------" + Name + "------------------------");
            string output = "";
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze[i].Length; j++)
                {
                    if (maze[i][j] < 10) output += "   " + maze[i][j];
                    else if (maze[i][j] < 100) output += "  " + maze[i][j];
                    else if (maze[i][j] <= WALL) output += " " + maze[i][j];
                }
                Console.WriteLine(output);
                output = "";
            }
           
        } 
        static void ConvertInttoStringArray(string Name)
        {
            Console.WriteLine("--------------------" + Name + "------------------------");
            string output = "";
            for (int i = 0; i < maze.GetLength(0); i++)
            {
                for (int j = 0; j < maze[i].Length; j++)
                {

                    if (maze[i][j] ==  WALL) output += " " + "#";
                    else if (maze[i][j] < 89 && maze[i][j] > 1) output += " " + ".";
                    else if (maze[i][j] == OPTIMALROUTE) output += " " + "-";
                    else if (maze[i][j] == START)  output += " " + "S";
                    else if (maze[i][j] == GOAL)output += " " + "G";
                    else if (maze[i][j] == ROAD)  output += " " + ".";
                }
                Console.WriteLine(output);
                output = "";
            }
        }
    }
}
