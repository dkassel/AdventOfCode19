using AdventOfCode19.lib;
using System;
using System.Windows.Media.Media3D;

namespace AdventOfCode19.Tasks.Day12 {

    public class Moon {
        private string name;
        private Vector3D pos;
        private Vector3D velocity;

        public Moon(string name, Vector3D pos) {
            Name = name;
            Pos = pos;
        }

        public string Name {
            get { return name; }
            set { name = value; }
        }

        public Vector3D Pos {
            get { return pos; }
            set { pos = value; }
        }

        public Vector3D Velocity {
            get { return velocity; }
            set { velocity = value; }
        }

        public void applyGravity(Moon otherMoon) {
            double velX = Velocity.X;
            double velY = Velocity.Y;
            double velZ = Velocity.Z;

            double otherVelX = otherMoon.Velocity.X;
            double otherVelY = otherMoon.Velocity.Y;
            double otherVelZ = otherMoon.Velocity.Z;
            
            if (Pos.X > otherMoon.Pos.X) {
                velX -= 1;
                otherVelX += 1;
            }
            else if (Pos.X < otherMoon.Pos.X) {
                velX += 1;
                otherVelX -= 1;
            }
            
            if (Pos.Y > otherMoon.Pos.Y) {
                velY -= 1;
                otherVelY += 1;
            }
            else if (Pos.Y < otherMoon.Pos.Y) {
                velY += 1;
                otherVelY -= 1;
            }

            if (Pos.Z > otherMoon.Pos.Z) {
                velZ -= 1;
                otherVelZ += 1;
            }
            else if (Pos.Z < otherMoon.Pos.Z) {
                velZ += 1;
                otherVelZ -= 1;
            }

            Velocity = new Vector3D(velX, velY, velZ);
            otherMoon.Velocity = new Vector3D(otherVelX, otherVelY, otherVelZ);
        }

        public void applyVelocity() {
            pos = pos + Velocity;
        }

        public int Energy {
            get { return PotentialEnergy * KineticEnergy; }
        }
        public int PotentialEnergy {
            get { return Math.Abs((int)Pos.X) + Math.Abs((int)Pos.Y) + Math.Abs((int)Pos.Z); }
        }
        public int KineticEnergy {
            get { return Math.Abs((int)Velocity.X) + Math.Abs((int)Velocity.Y) + Math.Abs((int)Velocity.Z); }
        }

    }
    public class N_BodyProblem {
        private const string INPUT_FILE_PATH = @"..\..\Tasks\Day12\input.txt";
        private Vector3D[] input;

        Moon Io;
        Moon Europa;
        Moon Ganymede;
        Moon Callisto;

        Moon[] Moons;

        public Vector3D[] Input {
            get {
                if (input == null) {
                    input = parseInput(SantasLittleHelperClass.textfileToStringArray(INPUT_FILE_PATH));
                }
                return input;
            }
        }

        public N_BodyProblem() {
            solveProblem1();
        }

        public void solveProblem1() {
            Io = new Moon("Io", Input[0]);
            Europa = new Moon("Europa", Input[1]);
            Ganymede = new Moon("Ganymede", Input[2]);
            Callisto = new Moon("Callisto", Input[3]);
            Moons = new Moon[Input.Length];
            Moons[0] = Io;
            Moons[1] = Europa;
            Moons[2] = Ganymede;
            Moons[3] = Callisto;

            const int numberOfTimeSteps = 1000;
            for (int i = 1; i <= numberOfTimeSteps; i++) {
                doTimeStep();
                /*
                Console.WriteLine("");
                Console.WriteLine("Step " + i);
                Console.Write("Pos " + Moons[0].Pos);
                Console.Write("Vel " + Moons[0].Velocity);
                */
            }
            /*
            Console.WriteLine(Moons[0].PotentialEnergy);
            Console.WriteLine(Moons[0].KineticEnergy);
            Console.WriteLine(Moons[0].Energy);
            */
            Console.WriteLine("End result= " + calculateTotalEnergy());

        }

        private int calculateTotalEnergy() {
            int sum = 0;
            for (int i = 0; i < Moons.Length; i++) {
                sum += Moons[i].Energy;
            }
            return sum;
        }

        private void applyGravity() {
            for (int i = 0; i < Moons.Length; i++) {
                for (int j = i + 1; j < Moons.Length; j++) {
                    Moons[j].applyGravity(Moons[i]);
                }
            }
        }

        private void applyVelocity() {
            for (int i = 0; i < Moons.Length; i++) {
                Moons[i].applyVelocity();
            }
        }

        private void doTimeStep() {
            applyGravity();
            applyVelocity();
        }

        private Vector3D[] parseInput(string[] input) {
            Vector3D[] result = new Vector3D[input.Length];
            for (int i = 0; i < input.Length; i++) {
                string magicString = input[i];
                string[] split = input[i].Replace("<", "").Replace(">", "").Replace(" ", "").Split(',');

                double x = Double.Parse(split[0].Substring(2));
                double y = Double.Parse(split[1].Substring(2));
                double z = Double.Parse(split[2].Substring(2));
                result[i] = new Vector3D(x, y, z);
            }
            return result;
        }

    }
}
