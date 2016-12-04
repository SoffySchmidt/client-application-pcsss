using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;
using System.Text;

namespace client_app
{
    class Client
    {
        //initialize variables
        private TcpClient _client;
        private Boolean _connected;
        private StreamWriter _clWriter;
        private StreamReader _clReader;

        //constructor creates tcpclient obj for listener in server class to accept
        //also runs streaming func when instance is made in main class
        public Client() {
            _client = new TcpClient(Convert.ToString(IPAddress.Loopback), 8888);
            ClientStream();
        }

        //func handling streams for client to write and read while creating bool to run while loop
        public void ClientStream()
        {
            _connected = true;
            _clWriter = new StreamWriter(_client.GetStream(), Encoding.ASCII);
            _clReader = new StreamReader(_client.GetStream(), Encoding.ASCII);

            //create var to store client data which will be send via streams
            String data = null;

            while (_connected)
            {
                //calculation functions
                //writes buffer to stream and flushses buffer to send data approx. simuntaiously..
                //..to avoid waiting to send when buffer is full
                double result = 0;

                Console.WriteLine("Enter first number:");
                string _firstNumber = Console.ReadLine();
                double firstNumber = Convert.ToDouble(_firstNumber);

                Console.WriteLine("Choose operation: ");
                Console.WriteLine("+ (addition), ");
                Console.WriteLine("- (substraction), ");
                Console.WriteLine("* (multiplication, ");
                Console.WriteLine("/ (division), ");
                Console.WriteLine("^ (exponentiation), ");
                Console.WriteLine("% (modulus)");
                string operation = Console.ReadLine();
               

                Console.WriteLine("Enter second number: ");
                string _secondNumber = Console.ReadLine();
                double secondNumber = Convert.ToDouble(_secondNumber);

                //go to case operation
                switch (operation)
                {
                    case "+":
                    case "addition":
                        result = firstNumber + secondNumber;
                        break;

                    case "-":
                    case "substraction":
                        result = firstNumber - secondNumber;
                        break;

                    case "*":
                    case "multiplication":
                        result = firstNumber * secondNumber;
                        break;

                    case "/":
                    case "division":
                        result = firstNumber / secondNumber;
                        break;

                    case "^":
                    case "exponentiation":
                        result = Math.Pow(firstNumber, secondNumber);
                        break;

                    case "modulus":
                    case "%":
                        result = firstNumber % secondNumber;
                        break;
                    case "x":
                    case "exit":
                        Console.WriteLine("Client disconnected");
                        break;
                }
                Console.WriteLine("\nResult of " + firstNumber + " " + operation + " " + secondNumber + " = " + result + ".");
                Console.WriteLine("Press any key to make a new calculation");
                Console.ReadKey();
            }
            _clWriter.WriteLine(data);
            _clWriter.Flush();
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Simply Math");
            Console.WriteLine("This console projekt allows you to solve very simple math operations");
            Console.WriteLine(" [a] Start calculations\n [x] Exit application");

            string data = null;
            data = Console.ReadLine();

            switch (data)
            {
                case "a":
                    Client client = new Client();
                    break;
                case "x":
                    //Exits program
                    break; 
            }
           
        }
    }
}
