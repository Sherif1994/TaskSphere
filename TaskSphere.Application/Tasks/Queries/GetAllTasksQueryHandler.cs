using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSphere.Application.Tasks.Dto;
using TaskSphere.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace TaskSphere.Application.Tasks.Queries
{
    public class GetAllTasksQueryHandler : IRequestHandler<GetAllTasksQuery, List<TaskItemDto>>
    {
        private readonly AppDbContext _db;
        public GetAllTasksQueryHandler(AppDbContext db)
        {
            _db = db;
        }
        public async Task<List<TaskItemDto>> Handle(GetAllTasksQuery request, CancellationToken cancellationToken)
        {
            return await _db.TaskItems.AsNoTracking().Select(o=>new TaskItemDto
            (
                o.Id,
                o.Title,
                o.Description,
                o.IsCompleted,
                o.CreatedAt
            )).ToListAsync(cancellationToken);
        }
    }
}
