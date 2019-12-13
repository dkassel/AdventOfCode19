using AdventOfCode19.lib;
using System;
using System.Collections.Generic;

namespace AdventOfCode19.Tasks.Day8 {

    public enum Pixel {
        BLK = 0,
        WHT = 1,
        TRP = 2
    }

    public class Day8 {
        private const int width = 25;
        private const int height = 6;
        private const string INPUT_FILE_PATH = @"..\..\Tasks\Day8\input.txt";
        private const int layerSize = width * height;

        private int[] readImageDataFromInputfile() {
            string[] fileLines = SantasLittleHelperClass.textfileToStringArray(INPUT_FILE_PATH);
            string input = fileLines[0];
            List<int> numbers = new List<int>();
            foreach (char c in input) {
                numbers.Add(int.Parse(c.ToString()));
            }
            return numbers.ToArray();
        }

        public void solveTask1() {
            List<Pixel[]> layers = imageDataToLayers();

            int lowestNumberOfZeroes = -1;
            Pixel[] layerWithLowestNumberOfZeroes = null;
            foreach (var l in layers) {
                int zeroes = countNumberOccourenceInLayer(l, 0);

                if (layerWithLowestNumberOfZeroes == null || zeroes < lowestNumberOfZeroes) {
                    lowestNumberOfZeroes = zeroes;
                    layerWithLowestNumberOfZeroes = l;
                }
            }

            int result = countNumberOccourenceInLayer(layerWithLowestNumberOfZeroes, Pixel.WHT) * countNumberOccourenceInLayer(layerWithLowestNumberOfZeroes, Pixel.TRP);
            Console.WriteLine("Endresult for task1 " + result);
        }

        public int countNumberOccourenceInLayer(Pixel[] layer, Pixel numberToSearch) {
            int result = 0;
            foreach (Pixel number in layer) {
                if (number == numberToSearch) result++;
            }
            return result;
        }

        public List<Pixel[]> imageDataToLayers(int[] imgData = null) {
            if (imgData == null)
                imgData = readImageDataFromInputfile();
            List<Pixel[]> layers = new List<Pixel[]>();
            Pixel[] layer = new Pixel[layerSize];

            for (int i = 0, cnt = 0; i <= imgData.Length; i++) {
                if (i == imgData.Length)
                    layers.Add(layer);
                else {
                    if (cnt == layerSize) {
                        layers.Add(layer);
                        cnt = 0;
                        layer = new Pixel[layerSize];
                    }
                    layer[cnt] = (Pixel)imgData[i];
                    cnt++;
                }
            }
            return layers;
        }

        public void solveTask2() {
            List<Pixel[]> layers = imageDataToLayers();
            decodeImage(layers);
        }

        public void decodeImage(List<Pixel[]> layers) {
            Pixel[] decodedImage = new Pixel[layerSize];
            for (int i = 0; i < decodedImage.Length; i++) {
                foreach (var layer in layers) {
                    if (layer[i] != Pixel.TRP) {
                        decodedImage[i] = layer[i];
                        break;
                    }
                }
            }
            Console.Write("Endresult for Task2, decodedImage: ");
            for (int i = 0; i < decodedImage.Length; i++) {
                if (i % width == 0)
                    Console.WriteLine("");
                Console.Write((int)decodedImage[i]);
            }
        }
    }
}
