using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Configuration;

namespace DeepSearchStack
{
    public class Searcher
    {
        private int[][] _graph;

        private SimpleStack<int[]> _nodes;

        private SimpleStack<State> _stack;

        private SimpleStack<int> _weights;

        private List<int> _shortestPath;

        private int _currentFastest = Int32.MaxValue;

        public Searcher(int[][] graph, int from, int to)
        {
            _graph = graph;
            _nodes = new SimpleStack<int[]>();
            _weights = new SimpleStack<int>();
        }

        public List<int> Search(int from, int to)
        {
            /*
            _nodes = new SimpleStack<int[]>();
            _weights = new SimpleStack<int>();

            int i = 0;
            var _s = true;
            while (!_nodes.IsEmpty || _s)
            {
                i++;
                if (i > _graph[from].Length - 1)
                {
                    _s = false;

                    _weights.Pull();
                    var p = _nodes.Pull();
                    from = p[0];
                    i = p[1];
                    continue;
                }
                if (i == from || _graph[from][i] == 0 ||_nodes.Any(n=> n[0]==i)) continue;

                _nodes.Push(new[] {from, i});

                _weights.Push(_graph[from][i]);

                if (i == to)
                {
                    CheckIfFastestAndSave();
                    _weights.Pull();

                    var p = _nodes.Pull();
                    from = p[0];
                    i = p[1];
                    continue;
                }

                from = i;
                i = 0;
            }

            return _nodes.Select(n=>n[0]).ToArray();
            */

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
                        var shortest = CheckIfFastestAndSave(state,final);
                        //state = _stack.Pull();
                        state.ShortestPath = shortest;
                        state.ShortestLength = final.ShortestLength;
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
                state = _stack.Pull();
                state.ShortestPath = sp;
                state.ShortestLength = sl;
                state.LastVisited++;
            }

            return state.ShortestPath;

        }

        //public void CheckIfFastestAndSave()
        //{
        //    var currentSum = _weights.Sum();
        //    if ( currentSum < _currentFastest)
        //    {
        //        _shortestPath = _nodes.Select(n=>n[0]).ToArray();
        //        _currentFastest = currentSum;
        //        Console.WriteLine(_currentFastest);
        //    }
        //}

        public List<int> CheckIfFastestAndSave(State cState,State fState)
        {
            if ( fState.WeightSum < fState.ShortestLength)
            {
                _shortestPath = _stack.Select(n=>n.Id).Append(cState.Id).Append(fState.Id).ToList();
                fState.ShortestLength = fState.WeightSum ;
                Console.WriteLine(fState.ShortestLength);
            }
            return _shortestPath;
        }

    }
}