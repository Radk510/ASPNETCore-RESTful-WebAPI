using System.Collections.Generic;
using CommandWebApi.Models;

namespace CommandWebApi.Data
{
    public interface ICommandWebApiRepo
    {
        bool SaveChanges();
        
         IEnumerable<Command> GetCommands();

         Command GetCommand(int id);

         void CreateCommand(Command command);

         void UpdateCommand(Command command);

         void DeleteCommand(Command command);
    }
}