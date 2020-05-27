using System;
using System.Collections.Generic;
using System.Linq;
using CommandWebApi.Models;

namespace CommandWebApi.Data
{
    public class SqlCommandRepo : ICommandWebApiRepo
    {
        private readonly CommandContext _context;

        public SqlCommandRepo(CommandContext context)
        {
            _context = context;
        }

        public void CreateCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            _context.Commands.Add(command);
        }

        public void DeleteCommand(Command command)
        {
            if (command == null)
            {
                throw new ArgumentNullException(nameof(command));
            }

            _context.Commands.Remove(command);
        }

        public Command GetCommand(int id)
        {
            return _context.Commands.FirstOrDefault(m => m.Id == id);
        }

        public IEnumerable<Command> GetCommands()
        {
            return _context.Commands.ToList();
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateCommand(Command command) 
        { 
        }
    }
}