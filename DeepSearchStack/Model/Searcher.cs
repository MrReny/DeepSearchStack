using System;
using System.Collections.Generic;
using System.Linq;

namespace DeepSearchStack
{
    public class Searcher
    {
        private int[][] _graph;

        private SimpleStack<State> _stack;

        public Searcher(int[][] graph)
        {
            _graph = graph;
        }

        public List<int> Search(int from, int to)
        {
            _stack = new SimpleStack<State>();

            State state = new State
            {
                Id = from, LastVisited = 0, WeightSum = 0,
                ShortestLength = Int32.MaxValue,
                ShortestPath = new List<int>(){from}
            };
            while (!(state.Id == from && state.LastVisited>=_graph[0].Length))
            {
                while (state.LastVisited<_graph[0].Length)
                {
                    if (state.Id == state.LastVisited || _stack.Any(s => s.Id == state.LastVisited))
                    {
                        state.LastVisited++;
                        continue;
                    }

                    if (state.LastVisited == to)
                    {
                        var final = new State
                        {
                            Id = state.LastVisited,
                            LastVisited = 0,
                            ShortestPath = state.ShortestPath,
                            ShortestLength = state.ShortestLength,
                            WeightSum = state.WeightSum + _graph[state.Id][state.LastVisited]
                        };

                        if ( final.WeightSum < final.ShortestLength)
                        {
                            state.ShortestPath = _stack.Select(n=>n.Id).Append(state.Id).Append(final.Id).ToList();
                            state.ShortestLength = final.WeightSum ;
                            Console.WriteLine(state.ShortestLength);
                        }
                        state.LastVisited++;
                        continue;
                    }

                    _stack.Push(state);
                    state = new State
                    {
                        Id = state.LastVisited,
                        LastVisited = 0,
                        ShortestPath = state.ShortestPath,
                        ShortestLength = state.ShortestLength,
                        WeightSum = state.WeightSum + _graph[state.Id][state.LastVisited]
                    };

                }

                var sp = state.ShortestPath;
                var sl = state.ShortestLength;
                if(_stack.IsEmpty) continue;
                state = _stack.Pull();
                state.ShortestPath = sp;
                state.ShortestLength = sl;
                state.LastVisited++;
            }
            return state.ShortestPath;
        }

    }
}