namespace TheTankGame.Core
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using IO.Contracts;

    public class Engine : IEngine
    {
        private bool isRunning;
        private readonly IReader reader;
        private readonly IWriter writer;
        private readonly ICommandInterpreter commandInterpreter;

        public Engine(
            IReader reader, 
            IWriter writer, 
            ICommandInterpreter commandInterpreter)
        {
            this.reader = reader;
            this.writer = writer;
            this.commandInterpreter = commandInterpreter;

            this.isRunning = false;
        }

        public void Run()
        {
            while (!isRunning)
            {
                try
                {
                    string input = reader.ReadLine();
                    if (input == "Terminate ")
                    {
                        isRunning = true;
                        
                    }
                    List<string> data = input.Split().ToList();

                    string result = this.commandInterpreter.ProcessInput(data);

                    writer.WriteLine(result);
                }
                catch (Exception e)
                {
                    writer.WriteLine(e.Message);
                }
              
            }
            Environment.Exit(0);


        }
    }
}