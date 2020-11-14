using System.Collections.Generic;
using Commander.Data;
using Commander.Models;

namespace Commander.Date
{
    public class MockCommanderRepo : ICommanderRepo
    {
        public void CreateCommand(Command info)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Command> GetAllCommands() 
       {
           var commands = new List<Command>
           {
                new Command{Id=0, Howto="Boil an egg", Line ="Boil water", Platform = "kettle & Pan" },
                new Command{Id=1, Howto="Boil an beans", Line ="help me", Platform = "youre not special" },
                new Command{Id=2, Howto="fish", Line ="on God", Platform = "make money" }
           };
           return commands;
       }

        public Command GetCommandById(int id)
        {
            return new Command{Id=0, Howto="Boil an egg", Line ="Boil water", Platform = "kettle & Pan" };
        }

        public bool saveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdateCommand(Command info)
        {
            throw new System.NotImplementedException();
        }
    }
}