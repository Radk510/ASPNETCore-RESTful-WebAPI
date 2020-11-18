using System.Collections.Generic;
using AutoMapper;
using CommandWebApi.Data;
using CommandWebApi.DTOs;
using CommandWebApi.Models;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;

namespace CommandWebApi.Controllers 
{
    // api/commands
    [Route("api/[controller]")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommandWebApiRepo _repository;
        private IMapper _mapper;

        public CommandsController(ICommandWebApiRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        // GET api/commands 6565656
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commands = _repository.GetCommands();

            var result = _mapper.Map<IEnumerable<CommandReadDto>>(commands);
            
            return Ok(result);
        }

        // GET api/commands/34
        [HttpGet("{id}", Name="GetCommand")]
        public ActionResult<CommandReadDto> GetCommand(int id)
        {
            var command = _repository.GetCommand(id);

            if (command != null)
            {
                return Ok(_mapper.Map<CommandReadDto>(command));
            }

            return NotFound();
        }

        // POST api/command
        [HttpPost]
        public ActionResult<CommandReadDto> CreateCommand(CommandCreateDto commandCreateDto)
        {
            var commandModel = _mapper.Map<Command>(commandCreateDto);

            _repository.CreateCommand(commandModel);

            _repository.SaveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommand), new { Id = commandReadDto.Id }, commandReadDto);
        }

        // PUT api/commands/34
        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto commandUpdateDto)
        {
            var commandModelFromRepo = _repository.GetCommand(id);

            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            _mapper.Map(commandUpdateDto, commandModelFromRepo);

            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // PATCH api/commands/34
        [HttpPatch("{id}")]
        public ActionResult PartialCommandUpdate(int id, JsonPatchDocument<CommandUpdateDto> patchDoc)
        {
            var commandModelFromRepo = _repository.GetCommand(id);

            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            var commandToPatch = _mapper.Map<CommandUpdateDto>(commandModelFromRepo);

            patchDoc.ApplyTo(commandToPatch, ModelState);

            if (!TryValidateModel(commandToPatch))
            {
                return ValidationProblem(ModelState);
            }

            _mapper.Map(commandToPatch, commandModelFromRepo);

            _repository.UpdateCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

        // DELETE api/commands/26
        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id)
        {
            var commandModelFromRepo = _repository.GetCommand(id);

            if (commandModelFromRepo == null)
            {
                return NotFound();
            }

            _repository.DeleteCommand(commandModelFromRepo);

            _repository.SaveChanges();

            return NoContent();
        }

    }
}