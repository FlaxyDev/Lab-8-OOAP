using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8._2
{
    public class PhoneBookEntry
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }

        public PhoneBookEntry(string name, string phoneNumber)
        {
            Name = name;
            PhoneNumber = phoneNumber;
        }
    }
    public class ListNode
    {
        public PhoneBookEntry Data;
        public ListNode Next;
        public ListNode Previous;

        public ListNode(PhoneBookEntry data)
        {
            Data = data;
            Next = null;
            Previous = null;
        }
    }

    public class PhoneBook
    {
        private ListNode head;
        private ListNode tail;

        public void AddEntry(PhoneBookEntry entry)
        {
            ListNode newNode = new ListNode(entry);
            if (head == null)
            {
                head = newNode;
                tail = newNode;
            }
            else
            {
                tail.Next = newNode;
                newNode.Previous = tail;
                tail = newNode;
            }
        }

        public class PhoneBookIterator
        {
            private ListNode current;

            public PhoneBookIterator(ListNode head)
            {
                current = head;
            }

            public bool HasNext()
            {
                return current != null;
            }

            public PhoneBookEntry Next()
            {
                if (current == null)
                {
                    throw new InvalidOperationException("Iterator has reached the end of the list");
                }

                PhoneBookEntry data = current.Data;
                current = current.Next;
                return data;
            }
        }

        public PhoneBookIterator GetIterator()
        {
            return new PhoneBookIterator(head);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            PhoneBook phoneBook = new PhoneBook();
            phoneBook.AddEntry(new PhoneBookEntry("Max", "380632384566"));
            phoneBook.AddEntry(new PhoneBookEntry("Pavlo", "380932384211"));
            phoneBook.AddEntry(new PhoneBookEntry("Ivan", "380772114263"));

            PhoneBook.PhoneBookIterator iterator = phoneBook.GetIterator();
            while (iterator.HasNext())
            {
                PhoneBookEntry entry = iterator.Next();
                Console.WriteLine($"Name: {entry.Name}, Phone: {entry.PhoneNumber}");
            }
        }
    }
}
