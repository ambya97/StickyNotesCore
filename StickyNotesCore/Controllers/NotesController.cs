using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StickyNotesCore.Domain.Commands.Notes;
using StickyNotesCore.Domain.Data.Queries.Notes;
using StickyNotesCore.Domain.Logic.Repository;
using StickyNotesCore.Domain.Models;
using StickyNotesCore.Domain.Queries.Notes;
using StickyNotesCore.Shared.Resources.Errors;
using StickyNotesCore.Shared.Resources.Notes;
using StickyNotesCore.Shared.Resources.Queries;
using StickyNotesCore.Shared.Responses;
using System.Net;

namespace StickyNotesCore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public NotesController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpPost("InsertNoteDetails")]
        [ProducesResponseType(typeof(NoteResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ResultModel> InsertNoteDetails([FromBody] CreateNoteResource resource)
        {
            var response = await _mediator.Send(_mapper.Map<CreateNoteCommand>(resource));
            var noteResource = (response.Success) ? _mapper.Map<NoteResource>(response.Resource) : null;
            if (resource == null)
            {
                return new ResultModel
                {
                    Data = null,
                    Message = "An unhandled error happened during your request. Please, try again later.",
                    Code = HttpStatusCode.InternalServerError
                };
            }
            return new ResultModel
            {
                Data = noteResource,
                Code = HttpStatusCode.OK,
                Message = response.Message
            };
        }
        [HttpPost("UpdateNoteDetails")]
        [ProducesResponseType(typeof(NoteResource), 201)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ResultModel> UpdateNoteDetails(Guid id, [FromBody] PatchNoteResource resource)
        {
            var command = _mapper.Map<PatchNoteCommand>(resource);
            command.Id = id;

            var response = await _mediator.Send(command);
            var articleresource = (response.Success) ? _mapper.Map<NoteResource>(response.Resource) : null;
            if (resource == null)
            {
                return new ResultModel
                {
                    Data = null,
                    Message = "An unhandled error happened during your request. Please, try again later.",
                    Code = HttpStatusCode.InternalServerError
                };
            }
            return new ResultModel
            {
                Data = articleresource,
                Code = HttpStatusCode.OK,
                Message = response.Message
            };
        }
        /// <summary>
		/// Deletes a sticky note using the note's ID.
		/// </summary>
		/// <param name="id">Note ID.</param>
		/// <returns>Response for the request.</returns>
		[HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ResultModel> DeleteAsync(Guid id)
        {
            var resource = await _mediator.Send(new DeleteNoteCommand { Id = id });
            if (resource == null)
            {
                return new ResultModel
                {
                    Data = null,
                    Message = "An unhandled error happened during your request. Please, try again later.",
                    Code = HttpStatusCode.InternalServerError
                };
            }
            if (resource.Status == Status.NotFound)
            {
                return new ResultModel
                {
                    Data = null,
                    Code = HttpStatusCode.NotFound,
                    Message = resource.Message
                };
            }
            else
            {
                return new ResultModel
                {
                    Data = null,
                    Code = HttpStatusCode.OK,
                    Message = resource.Message
                };
            }
           
        }

        /// <summary>
		/// Lists all the sticky notes that match provided filters.
		/// </summary>
		/// <param name="queryResource">Resource containing query filters.</param>
		/// <returns>The query result.</returns>
		[HttpGet]
        [ProducesResponseType(typeof(QueryResultResource<NoteResource>), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        [ProducesResponseType(typeof(ErrorResource), 401)]
        [ProducesResponseType(typeof(ErrorResource), 403)]
        public async Task<ResultModel> ListAsync()
        {
            //var queryResult = await _mediator.Send(new ListNotesRequest { _mapper.Map<NotesQuery>(queryResource) });
            //  var queryResult = await _mediator.Send(new ListNotesRequest { });
            //  var noteResource = (queryResult.su) ? _mapper.Map<NoteResource>(response.Resource) : null;
            //return Ok(_mapper.Map<QueryResultResource<NoteResource>>(queryResult));
            var ListDetails = await _mediator.Send(new ListNotesRequest());
            if(ListDetails == null)
            {
                return new ResultModel
                {
                    Data = null,
                    Message = "An unhandled error happened during your request. Please, try again later.",
                    Code = HttpStatusCode.InternalServerError
                };
            }
            return new ResultModel
            {
                Data = ListDetails,
                Code = HttpStatusCode.OK,
                Message = "All Record Details"
            };

        }

        /// <summary>
		/// Retrieves a sticky note by its ID.
		/// </summary>
		/// <param name="id">Note ID.</param>
		/// <returns>Response for the request.</returns>
		[HttpGet("{id}")]
        [ProducesResponseType(typeof(NoteResource), 200)]
        [ProducesResponseType(typeof(ErrorResource), 400)]
        public async Task<ResultModel> GetByIdAsync(Guid id)
        {
            var response = await _mediator.Send(new GetNoteByIdRequest { Id = id });
            var noteResource = (response.Success) ? _mapper.Map<NoteResource>(response.Resource) : null;
            if (response == null)
            {
                return new ResultModel
                {
                    Data = null,
                    Message = "An unhandled error happened during your request. Please, try again later.",
                    Code = HttpStatusCode.InternalServerError
                };
            }
            return new ResultModel
            {
                Data = noteResource,
                Code = HttpStatusCode.OK,
                Message = response.Message
            };
        }
    }
}
