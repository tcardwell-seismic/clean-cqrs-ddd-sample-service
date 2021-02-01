using System;
using System.IO;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Seismic.Clean.Application.Contents.Commands.CreateContent;
using Seismic.Clean.Application.Contents.Commands.CreateContentVersion;
using Seismic.Clean.Application.Contents.Commands.DeleteContent;
using Seismic.Clean.Application.Contents.Commands.PromoteContent;
using Seismic.Clean.Application.Contents.Commands.PublishContent;
using Seismic.Clean.Application.Contents.Commands.RateContent;
using Seismic.Clean.Application.Contents.Queries.GetContent;
using Seismic.Clean.Domain.Common.Enums;
using Seismic.Clean.Domain.ContentAggregate;

namespace Seismic.Clean.Api.Controllers
{
    [Route("api/content")]
    [AllowAnonymous]
    public class ContentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // TODO Request models for this body
        [HttpPost]
        public async Task<ActionResult<Content>> CreateContent(IFormFile file, [FromBody] Guid authorId, [FromBody] Repository repository)
        {
            var fileInfo = new FileInfo(Path.GetTempFileName());
            using (var fileStream = fileInfo.OpenWrite())
            {
                await file.CopyToAsync(fileStream);
            }

            var content = await _mediator.Send(new CreateContentCommand(fileInfo, authorId, repository));
            return Ok(content);
        }

        // TODO Request models for this body 
        [HttpPost]
        [Route("{contentId}/versions")]
        public async Task<ActionResult<Content>> CreateContentVersion(IFormFile file, [FromQuery] Guid contentId, [FromBody] Guid authorId, [FromBody] bool isMajor)
        {
            var fileInfo = new FileInfo(Path.GetTempFileName());
            using (var fileStream = fileInfo.OpenWrite())
            {
                await file.CopyToAsync(fileStream);
            }

            var content = await _mediator.Send(new CreateContentVersionCommand(contentId, authorId, isMajor, fileInfo));
            return Ok(content);
        }

        [HttpDelete]
        [Route("{contentId}/versions/{versionId}")]
        public async Task<IActionResult> DeleteContent([FromQuery] Guid contentId, [FromQuery] Guid versionId)
        {
            var content = await _mediator.Send(new DeleteContentCommand(contentId, versionId));
            return NoContent();
        }

        [HttpGet]
        [Route("{contentId}/versions/{versionId}")]
        public async Task<ActionResult<GetContentQueryVm>> GetContent([FromQuery] Guid contentId, [FromQuery] Guid versionId)
        {
            var content = await _mediator.Send(new GetContentQuery(contentId, versionId));
            return Ok(content);
        }

        [HttpPost]
        [Route("{contentId}/versions/{versionId}/promote")]
        public async Task<ActionResult<Content>> PromoteContent([FromQuery] Guid contentId, [FromQuery] Guid versionId)
        {
            var content = await _mediator.Send(new PromoteContentCommand(contentId, versionId));
            return Ok(content);
        }

        [HttpPost]
        [Route("{contentId}/versions/{versionId}/publish")]
        public async Task<ActionResult<Content>> PublishContent([FromQuery] Guid contentId, [FromQuery] Guid versionId)
        {
            var content = await _mediator.Send(new PublishContentCommand(contentId, versionId));
            return Ok(content);
        }

        [HttpPost]
        [Route("{contentId}/versions/{versionId}/rate")]
        public async Task<ActionResult<Content>> RateContent([FromQuery] Guid contentId, [FromQuery] Guid versionId, [FromBody] int rating)
        {
            var content = await _mediator.Send(new RateContentCommand(contentId, versionId, rating));
            return Ok(content);
        }
    }
}