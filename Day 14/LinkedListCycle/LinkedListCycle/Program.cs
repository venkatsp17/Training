namespace LinkedListCycle
{
    public class Node
    {
        public int value;
        public Node next;
        public Node(int x)
        {
            value = x;
            next = null;
        }
    }

    public class Program
    {
        bool HasLoop(Node head)
        {
            if (head == null || head.next == null)
            {
                return false;
            }

            Node node1 = head;
            Node node2 = head.next;

            while (node2 != null && node2.next != null)
            {
                if (node1 == node2)
                {
                    return true; 
                }
                node1 = node1.next; 
                node2 = node2.next.next; 
            }

            return false; 
        }
        static void Main(string[] args)
        {
            Node head = new Node(3);
            head.next = new Node(2);
            head.next.next = new Node(0);
            head.next.next.next = new Node(-4);
            head.next.next.next.next = head.next; 

            Program program = new Program();

            bool HasLoop = program.HasLoop(head);

            Console.WriteLine("Does following linked list have loop? "+HasLoop);
        }
    }
}
