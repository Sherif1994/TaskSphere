using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSphere.Application.Tasks.Dto;

namespace TaskSphere.Application.Tasks.Queries
{
    public record GetAllTasksQuery : IRequest<List<TaskItemDto>>;
}
