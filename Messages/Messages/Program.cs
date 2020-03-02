using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Messages
{
    class Program
    {
        static int totalCounter = 0;
        static int SMSCounter = 0;
        static int MMSCounter = 0;
        static int VoiceCounter = 0;
        static int RAWCounter = 0;

        static void Main(string[] args)
        {
            Thread createMessages = new Thread(new ThreadStart(CreateMessages));
            createMessages.Start();

            Console.ReadKey();
        }

        public static void CreateMessages()
        {
            Random random = new Random();
            Array values = Enum.GetValues(typeof(MessageType));
            
            for (int i = 0; i < random.Next(20, 50); i++)
            {
                Message message = new Message()
                {
                    Body = Library.countries[random.Next(0, Library.countries.Length)],
                    Type = (MessageType)values.GetValue(random.Next(values.Length))
                };
                totalCounter++;
                Console.WriteLine(message.Body + "." + message.Type);

                HandleMessage(message.Body, message.Type.ToString());

                Thread.Sleep(100*random.Next(1, 6));
                
            }

            Console.WriteLine();
            Console.WriteLine($"Total amount of SMS messages: {SMSCounter}");
            Console.WriteLine($"Total amount of MMS messages: {MMSCounter}");
            Console.WriteLine($"Total amount of Voice messages: {VoiceCounter}");
            Console.WriteLine($"Total amount of RAW messages: {RAWCounter}");

            Console.WriteLine($"Total amount of created messages: {totalCounter}");
        }

        public static void HandleMessage(string text, string format)
        {
            string filePath = $"D:\\MESSAGES\\{format}\\";

            if (!Directory.Exists(filePath)) 
            { 
                Directory.CreateDirectory(filePath);
            }
              
            switch (format)
            {
                case "SMS":
                    {
                        SMSCounter++;
                        filePath += format + SMSCounter + ".txt";
                        ToFile(text, filePath);
                    };
                    break;
                case "MMS":
                    {
                        MMSCounter++;
                        filePath += format + MMSCounter + ".txt";
                        ToFile(text, filePath);
                    };
                    break;
                case "Voice":
                    {
                        VoiceCounter++;
                        filePath += format + VoiceCounter + ".txt";
                        ToFile(text, filePath);
                    };
                    break;
                case "RAW":
                    {
                        RAWCounter++;
                        filePath += format + RAWCounter + ".txt";
                        ToFile(text, filePath);
                    };
                    break;
            }
        }

        public static void ToFile(string text, string path)
        {
            using (StreamWriter fileWriter = new StreamWriter(path, false, System.Text.Encoding.Default))
            {
                fileWriter.Write(text);
            }
        }
    }
}