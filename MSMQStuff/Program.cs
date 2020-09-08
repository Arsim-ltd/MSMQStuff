using System;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Messaging;

namespace MSMQStuff
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageQueue queue = new MessageQueue("FormatName:DIRECT=OS:server\\queue");
            // Get all messages in a queue

            // Loop through the messages. 
            //Console.WriteLine("Name:"+qu.Label.ToString());
            //foreach (Message msg in queue.GetAllMessages())
            //{
            //    msg.Formatter = new XmlMessageFormatter(new String[] { "System.String,mscorlib" });
            //    Console.WriteLine("Message " + msg.Id +" found."); 
            //}

            queue.MessageReadPropertyFilter.Priority = true;

            // Set the formatter to indicate body contains a string.
            var queueIter = queue.GetMessageEnumerator2();
            while (queueIter.MoveNext())
            {
                try
                {
                    // Receive and format the message. 
                    Message msg = queue.Receive();
                    //Console.WriteLine("Priority: " + myMessage.Priority.ToString());
                    Console.WriteLine("Message " + msg.Id + " received.");

                }
                catch (MessageQueueException)
                {
                    // Handle Message Queuing exceptions.
                }

                // Handle invalid serialization format.
                catch (InvalidOperationException e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            Console.ReadLine();
        }
    }
}
