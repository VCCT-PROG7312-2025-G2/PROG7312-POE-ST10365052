namespace PROG7312.Models
{
    public class serviceRequestNode
    {
        public Issues Data { get; set; }
        public serviceRequestNode? Left { get; set; }
        public serviceRequestNode? Right { get; set; }

        public serviceRequestNode(Issues data)
        {
            Data = data;
        }
    }
}
