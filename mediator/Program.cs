using System;

namespace ConsoleApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var mediator = new Mediator();
            var tarikPerson = new Person(mediator, "Tarik");
            var bobPerson = new Person(mediator, "Bob");
            var joshPerson = new Person(mediator, "Josh");
            tarikPerson.Send("Hello Bob");
        }

        public delegate void MessageReceivedEventHandler(string message, string from);

        public class Mediator
        {
            public event MessageReceivedEventHandler MessageReceived;

            public void Send(string message, string from)
            {
                if (MessageReceived != null)
                {
                    Console.WriteLine("Sending '{0}' from {1}", message, from);
                    MessageReceived(message, from);
                }
            }
        }

        public class Person
        {
            private Mediator _mediator;

            public string Name { get; set; }

            public Person(Mediator mediator, string name)
            {
                Name = name;
                _mediator = mediator;
                _mediator.MessageReceived += (m, f) => { if (f != Name) { Console.WriteLine("{0} received '{1}' from {2}", Name, m, f); } };
            }

            public void Send(string message)
            {
                _mediator.Send(message, Name);
            }
        }
    }
}
