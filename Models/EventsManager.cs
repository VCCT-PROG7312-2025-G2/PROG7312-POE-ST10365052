namespace PROG7312.Models
{
    public class EventsManager
    {
        public SortedDictionary<DateTime, List<Events>> EventsByDate { get; } = new SortedDictionary<DateTime, List<Events>>();
        public HashSet<string> Categories { get; } = new HashSet<string>();
        public Queue<Events> EventQueue { get; } = new Queue<Events>();
        public Dictionary<string, int> CategorySearchCounts { get; } = new Dictionary<string, int>();

        public void AddEvent(Events ev)
        {
            if (!EventsByDate.ContainsKey(ev.Date))
                EventsByDate[ev.Date] = new List<Events>();
            EventsByDate[ev.Date].Add(ev);
            Categories.Add(ev.Category);
            EventQueue.Enqueue(ev);
        }

        public void RegisterCategorySearch(string category)
        {
            if (string.IsNullOrEmpty(category)) return;
            if (!CategorySearchCounts.ContainsKey(category))
                CategorySearchCounts[category] = 0;
            CategorySearchCounts[category]++;
        }

        public List<Events> RecommendEvents()
        {
            if (CategorySearchCounts.Count == 0)
                return new List<Events>();

            var mostSearchedCategory = CategorySearchCounts
                .OrderByDescending(kvp => kvp.Value)
                .First().Key;

            return EventsByDate.Values
                .SelectMany(list => list)
                .Where(e => e.Category == mostSearchedCategory)
                .OrderBy(e => e.Date)
                .Take(3)
                .ToList();
        }
    }

}
