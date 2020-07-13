using AdventOfCode19.lib;
using AdventOfCode19.Tasks.Day7;
using System;
using System.Collections.Generic;

namespace AdventOfCode19.Tasks.Day13 {

    public enum TileType {
        Empty,
        Wall,
        Block,
        Paddle,
        Ball
    }

    public struct Tile {
        public long x, y;
        public TileType tileType;
        public Tile(long x, long y, TileType tileType) {
            this.x = x;
            this.y = y;
            this.tileType = tileType;
        }
    }

    enum JoystickPosition {
        Neutral = 0,
        Left = -1,
        Right = 1
    }

    public class ArcadeCabinet {

        private IntCodeComputer intCodeComputer = new IntCodeComputer();
        private List<Tile> gameGrid;
        private const string InputFilePath = @"..\..\Tasks\Day13\input.txt";
        private long[] testOutput = { 1, 2, 3, 6, 5, 4 };

        private JoystickPosition joystickPosition;


        public void solveTask1() {
            long[] inputArray = { 0 };
            long[] tileInstructions = intCodeComputer.RunProgram(inputFileToIntArray(), inputArray);
            drawGameGrid(tileInstructions);
        }

        public void solveTask2() {
            long[] inputArray = { 0 };
            long[] tileInstructions = intCodeComputer.RunProgram(inputFileToIntArray(), inputArray);
            drawGameGrid(tileInstructions, 2);
        }

        private long[] inputFileToIntArray() {
            string[] fileLines = SantasLittleHelperClass.TextfileToStringArray(InputFilePath);
            List<long> program = new List<long>();
            for (long i = 0; i < fileLines.Length; i++) {
                string[] split = fileLines[i].Split(',');
                for (long j = 0; j < split.Length; j++) {
                    program.Add(SantasLittleHelperClass.StringToLong(split[j]));
                }
            }
            return program.ToArray();
        }

        public void drawGameGrid(long[] tileInstructions, long nrOfQuarters = -1) {
            gameGrid = new List<Tile>();
            for (int i = 0; i < tileInstructions.Length; i += 3) {
                long x = tileInstructions[i];
                long y = tileInstructions[i + 1];
                TileType type = (TileType)tileInstructions[i + 2];
                gameGrid.Add(new Tile(x, y, type));
            }
            Console.WriteLine("Ball Cnt " + countTileTypeOnGrid(gameGrid, TileType.Ball));
            Console.WriteLine("Block Cnt " + countTileTypeOnGrid(gameGrid, TileType.Block));
            Console.WriteLine("Paddle Cnt " + countTileTypeOnGrid(gameGrid, TileType.Paddle));
        }

        private int countTileTypeOnGrid(List<Tile> gameGrid, TileType type) {
            int cnt = 0;
            foreach (Tile t in this.gameGrid)
                if (t.tileType == type) cnt++;
            return cnt;
        }

    }
}
