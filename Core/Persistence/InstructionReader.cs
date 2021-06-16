using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Core.Persistence
{
    public interface IInstructionReader
    {
        InstructionsWithNumber Read();
    }   

    public class InstructionReader : IInstructionReader
    {
        private Dictionary<string,IInstructionFactory> instructionFactories; // Dictionary is to ensure O(1) access time
        private IFileReader fileReader;

        public InstructionReader(IEnumerable<IInstructionFactory> instructionFactories, IFileReader fileReader)
        {
            this.instructionFactories = instructionFactories.ToDictionary(x => x.OperationName.ToLower());
            this.fileReader = fileReader;
        }

        public InstructionsWithNumber Read()
        {
            var previousInstructions = new List<IInstruction>();

            IEnumerable<string> lines = fileReader.ReadLines(); // Production code will read and process lines one by one
            foreach (var line in lines)
            {
                var instruction = ReadLine(line);

                if (instruction is ApplyInstruction)
                {
                    return new InstructionsWithNumber(instruction.Number, previousInstructions);
                }
                else
                {
                    previousInstructions.Add(instruction);
                }
            }

            throw new Exception("Reached end of file but could not find the apply instruction");
        }

        private IInstruction ReadLine(string line)
        {
            var parsedLine = line.Split(new[] { ' ' });

            Validate(line);

            string operationName = parsedLine[0].ToLower();
            decimal number = decimal.Parse(parsedLine[1]);

            var instructionFactory = instructionFactories[operationName];
            var instruction = instructionFactory.Create(number);
            return instruction;
        }

        private void Validate(string line)
        {
            // Production version of this code will validate that
            //  parsedLine.Length = 2
            //  parsedLine[0] is not empty
            //  parsedLine[0] is in the list of supported operations (instructionFactories)
            //  parsedLine[1] is a decimal
            // 
            //  any other validation rules if required 
            // Validation will be done in a separate class
            // Error messages will include a human-friendly message and a line number 
            // If at least one validation error exists, execution will stop and errors will be shown to the user
        }
    }
}