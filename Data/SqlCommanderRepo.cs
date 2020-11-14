using System;
using System.Collections.Generic;
using System.Linq;
using Commander.Models;

namespace Commander.Data
{
    public class SqlCommanderRepo : ICommanderRepo
    {
        private readonly CommanderContext _context;

        public SqlCommanderRepo(CommanderContext context)
        {
            _context = context;
        }

        public void CreateCommand(Command info)
        {
            if(info == null) {
               throw new ArgumentNullException(nameof(info));
            }

            _context.Commands.Add(info);

        }

        public void DeleteCommand(Command info)
        {
            if(info == null) {
               throw new ArgumentNullException(nameof(info));
            }
            _context.Commands.Remove(info);
            
        }

        public IEnumerable<Command> GetAllCommands()
        {
            return _context.Commands.ToList();
        }

        public Command GetCommandById(int id)
        {
            return _context.Commands.FirstOrDefault(p => p.Id == id);
        }

        public bool saveChanges()
        {
           return (_context.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command info)
        {
            
        }
    }
}