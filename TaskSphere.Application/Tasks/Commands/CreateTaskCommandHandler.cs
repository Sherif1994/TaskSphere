using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSphere.Application.Tasks.Dto;
using TaskSphere.Domain.Entities;
using TaskSphere.Infrastructure.Persistence;

namespace TaskSphere.Application.Tasks.Commands
{
    public class CreateTaskCommandHandler : IRequestHandler<CreateTaskCommand, TaskItemDto>
    {
        private readonly AppDbContext _db;
        public CreateTaskCommandHandler(AppDbContext db)
        {
            _db = db;
        }
        public async Task<TaskItemDto> Handle(CreateTaskCommand request, CancellationToken cancellationToken)
        {
            var task = new TaskItem
            {
                Title = request.Title,
                Description = request.Description,
                IsCompleted = false,
                CreatedAt = DateTime.UtcNow,
            };
            _db.TaskItems.Add(task);
            await _db.SaveChangesAsync();
            return new TaskItemDto(
                task.Id,
                task.Title,
                task.Description,
                task.IsCompleted,
                task.CreatedAt);
        }
    }
}
