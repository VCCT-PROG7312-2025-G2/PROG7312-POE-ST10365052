namespace PROG7312.Models
{
    public class serviceRequestMinHeap
    {
        private List<Issues> heap = new List<Issues>();

        public void Insert(Issues issue)
        {
            heap.Add(issue);
            HeapifyUp(heap.Count - 1);
        }

        private void HeapifyUp(int index)
        {
            while (index > 0 && Compare(heap[index], heap[(index - 1) / 2]) < 0)
            {
                var temp = heap[index];
                heap[index] = heap[(index - 1) / 2];
                heap[(index - 1) / 2] = temp;
                index = (index - 1) / 2;
            }
        }

        private int Compare(Issues a, Issues b)
        {
            // Compare by Category
            return string.Compare(a.Category, b.Category, StringComparison.OrdinalIgnoreCase);
        }
        public Issues ExtractMin()
        {
            if (heap.Count == 0) return null;
            var min = heap[0];
            heap[0] = heap[heap.Count - 1];
            heap.RemoveAt(heap.Count - 1);
            HeapifyDown(0);
            return min;
        }

        private void HeapifyDown(int index)
        {
            int smallest = index;
            int left = 2 * index + 1;
            int right = 2 * index + 2;

            if (left < heap.Count && Compare(heap[left], heap[smallest]) < 0)
                smallest = left;
            if (right < heap.Count && Compare(heap[right], heap[smallest]) < 0)
                smallest = right;
            if (smallest != index)
            {
                var temp = heap[index];
                heap[index] = heap[smallest];
                heap[smallest] = temp;
                HeapifyDown(smallest);
            }
        }
    }
}
