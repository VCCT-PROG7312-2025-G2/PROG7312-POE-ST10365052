namespace PROG7312.Models
{
    public class serviceRequestGraph
    {
        private Dictionary<Issues, List<Issues>> adjacencyList = new Dictionary<Issues, List<Issues>>();

        public void AddEdge(Issues from, Issues to)
        {
            if (!adjacencyList.ContainsKey(from))
                adjacencyList[from] = new List<Issues>();
            adjacencyList[from].Add(to);
        }

        public List<Issues> BFS(Issues start)
        {
            var visited = new HashSet<Issues>();
            var queue = new Queue<Issues>();
            var result = new List<Issues>();

            queue.Enqueue(start);
            visited.Add(start);
            while (queue.Count > 0)
            {
                var current = queue.Dequeue();
                result.Add(current);

                if (adjacencyList.ContainsKey(current))
                {
                    foreach (var neighbor in adjacencyList[current])
                    {
                        if (!visited.Contains(neighbor))
                        {
                            visited.Add(neighbor);
                            queue.Enqueue(neighbor);
                        }
                    }
                }
            }
            return result;
        }
    }
}
