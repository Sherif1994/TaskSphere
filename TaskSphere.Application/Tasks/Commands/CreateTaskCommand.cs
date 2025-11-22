using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskSphere.Application.Tasks.Dto;
using TaskSphere.Domain.Entities;

namespace TaskSphere.Application.Tasks.Commands
{
    public record CreateTaskCommand(
        string Title,
        string? Description):IRequest<TaskItemDto>;
}
