using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskSphere.Application.Tasks.Dto
{
    public record TaskItemDto(
        int Id,
        string Title,
        string? Description,
        bool IsCompleted,
        DateTime CreatedTime
        );
}
