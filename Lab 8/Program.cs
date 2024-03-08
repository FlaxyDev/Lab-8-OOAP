using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab_8
{
    public interface IChatMediator
    {
        void SendMessage(string message, User sender, User receiver);
    }

    public class ChatMediator : IChatMediator
    {
        public void SendMessage(string message, User sender, User receiver)
        {
            receiver.Receive(message, sender);
        }
    }

    public abstract class User
    {
        protected IChatMediator mediator;
        public string Name { get; }

        public User(string name, IChatMediator mediator)
        {
            Name = name;
            this.mediator = mediator;
        }

        public abstract void Receive(string message, User sender);
    }

    public class ConcreteUser : User
    {
        public ConcreteUser(string name, IChatMediator mediator) : base(name, mediator) { }

        public override void Receive(string message, User sender)
        {
            Console.WriteLine($"{Name} receives messages from {sender.Name}: {message}");
        }

        public void Send(string message, User  receiver)
        {
            Console.WriteLine($"{Name} sends a message to {receiver.Name}: {message}");
            mediator.SendMessage(message, this, receiver);
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var mediator = new ChatMediator();

            var user1 = new ConcreteUser("User1", mediator);
            var user2 = new ConcreteUser("User2", mediator);
            var user3 = new ConcreteUser("User3", mediator);

            user1.Send("Hi bro!", user2);
            user2.Send("Yo", user1);

            Console.ReadLine();
        }
    }
}
