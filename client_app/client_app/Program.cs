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
                //reads buffer to stream
                //Console.Write("msg; ");
                //data = Console.ReadLine();

                //writes buffer to stream and flushses buffer to send data approx. simuntaiously..
                //..to avoid waiting to send when buffer is full'

                int operation = 0;
                double result = 0;

                Console.WriteLine("Type your first number :");
                string stringFirstNumber = Console.ReadLine();
                double firstNumber = Convert.ToDouble(stringFirstNumber);

                Console.WriteLine("Type your second number: ");
                string stringSecondNumber = Console.ReadLine();
                double secondNumber = Convert.ToDouble(stringSecondNumber);

                Console.WriteLine("Enter the operation: ");
                Console.WriteLine("+ (addition), ");
                Console.WriteLine("- (substraction), ");
                Console.WriteLine("* (multiplication, ");
                Console.WriteLine("/ (division), ");
                Console.WriteLine("^ (exponentiation), ");
                Console.WriteLine("% (modulus)");
                string stringOperation = Console.ReadLine();


                // Convert string choice to integral
                if (stringOperation == "+" || stringOperation == "addition")
                {
                    operation = 1;
                }
                else if (stringOperation == "-" || stringOperation == "soustraction")
                {
                    operation = 2;
                }
                else if (stringOperation == "*" || stringOperation == "multiplication")
                {
                    operation = 3;
                }
                else if (stringOperation == "/" || stringOperation == "division")
                {
                    operation = 4;
                }
                else if (stringOperation == "^" || stringOperation == "exponentiation")
                {
                    operation = 5;
                }
                else if (stringOperation == "%" || stringOperation == "modulus")
                {
                    operation = 6;
                }
                else if (stringOperation == "x" || stringOperation == "exit")
                {
                    operation = 7; 
                }

                //Do someting depending on the operation choose
                switch (operation)
                {
                    case 1:
                        result = firstNumber + secondNumber;
                        break;

                    case 2:
                        result = firstNumber - secondNumber;
                        break;

                    case 3:
                        result = firstNumber * secondNumber;
                        break;

                    case 4:
                        result = firstNumber / secondNumber;
                        break;

                    case 5:
                        result = Math.Pow(firstNumber, secondNumber);
                        break;

                    case 6:
                        result = firstNumber % secondNumber;
                        break;
                    case 7:
                        Console.WriteLine("Client desconnected");
                        break;
                }
                Console.WriteLine("\nResult of " + firstNumber + " " + stringOperation + " " + secondNumber + " = " + result + ".");
                Console.WriteLine("Press any key to make a new calculation");
                Console.ReadKey();
            }
            _clWriter.WriteLine(data);
            _clWriter.Flush();
        }


        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Simply Sam!");
            Console.WriteLine("Simply Sam is a simplified verison of windows Sam. You can ask sam to help you calculate simple mathematical operations and he wil calculate it for you");
            Console.WriteLine("Press [a] to start asking Sam for help. Press [x] to exit application");

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
