using System.Collections.Generic;
using AutoMapper;
using Commander.Data;
using Commander.Date;
using Commander.Dtos;
using Commander.Models;
using Microsoft.AspNetCore.Mvc;

namespace Commander.Controllers
{

    [Route("api/commands")]
    [ApiController]
    public class CommandsController : ControllerBase
    {
        private readonly ICommanderRepo _repository;
        private readonly IMapper _mapper;

        public CommandsController(ICommanderRepo repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        
        //Get api/commands
        [HttpGet]
        public ActionResult<IEnumerable<CommandReadDto>> GetAllCommands()
        {
            var commandItems = _repository.GetAllCommands();
            return Ok(_mapper.Map<IEnumerable< CommandReadDto>>(commandItems));
        }

        // GET api/commands/{id}
        [HttpGet("{id}", Name="GetCommandById")]
        public ActionResult <CommandReadDto> GetCommandById(int id)
        {
            var commandItem = _repository.GetCommandById(id);
            if(commandItem != null) {
                return Ok(_mapper.Map<CommandReadDto>(commandItem) );
            }

            return NotFound();
            
        }

        [HttpPost]
        public ActionResult <CommandReadDto> CreateCommand(CommandCreateDto create) {
            
            var commandModel = _mapper.Map<Command>(create);
            _repository.CreateCommand(commandModel);
            _repository.saveChanges();

            var commandReadDto = _mapper.Map<CommandReadDto>(commandModel);

            return CreatedAtRoute(nameof(GetCommandById),new {Id = commandReadDto.Id}, commandReadDto);

        }

        [HttpPut("{id}")]
        public ActionResult UpdateCommand(int id, CommandUpdateDto command) {

            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null) {
                return NotFound();
            }
            _mapper.Map(command, commandModelFromRepo);
            _repository.UpdateCommand(commandModelFromRepo);
            _repository.saveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteCommand(int id) {

            var commandModelFromRepo = _repository.GetCommandById(id);
            if(commandModelFromRepo == null) {
                return NotFound();
            }

            _repository.DeleteCommand(commandModelFromRepo);
            _repository.saveChanges();
            return NoContent();

        }
    }
}