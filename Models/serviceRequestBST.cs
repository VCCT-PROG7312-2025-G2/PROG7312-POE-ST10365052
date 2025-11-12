namespace PROG7312.Models
{
    public class serviceRequestBST
    {
        public serviceRequestNode Root { get; private set; }

        public void Insert(Issues issue)
        {
            Root = Insert(Root, issue);
        }

        private serviceRequestNode Insert(serviceRequestNode node, Issues issue)
        {
            if (node == null)
                return new serviceRequestNode(issue);

            // Able to use location as key
            int cmp = string.Compare(issue.Location, node.Data.Location, StringComparison.OrdinalIgnoreCase);
            if (cmp < 0)
                node.Left = Insert(node.Left, issue);
            else
                node.Right = Insert(node.Right, issue);

            return node;
        }

        public Issues Search(string location)
        {
            var node = Root;
            while (node != null)
            {
                int cmp = string.Compare(location, node.Data.Location, StringComparison.OrdinalIgnoreCase);
                if (cmp == 0)
                    return node.Data;
                node = cmp < 0 ? node.Left : node.Right;
            }
            return null;
        }
    }
}
