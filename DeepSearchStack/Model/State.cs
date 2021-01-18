using System.Collections.Generic;

namespace DeepSearchStack
{
    public class State
    {
        public int Id { get; set; }

        public int LastVisited { get; set; }

        public int WeightSum { get; set; }

        public List<int> ShortestPath { get; set; }

        public int ShortestLength { get; set; }
    }
}