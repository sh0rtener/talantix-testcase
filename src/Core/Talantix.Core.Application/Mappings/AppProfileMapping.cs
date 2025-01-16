using AutoMapper;
using Talantix.Core.Application.Todos;
using Talantix.Core.Domain.Todos;

namespace Talantix.Core.Application.Mappings;

public class AppMappingProfile : Profile
{
    public AppMappingProfile()
    {
        CreateMap<Todo, TodoDto>()
            .ForMember(x => x.Status, opt => opt.MapFrom(x => x.Status.Status))
            .ReverseMap()
            .ForMember(x => x.Status, opt => opt.MapFrom(x => MapFromString(x.Status)));
    }

    private TodoStatus MapFromString(string value) =>
        value switch
        {
            "not completed" => TodoStatus.NotCompleted,
            "completed" => TodoStatus.Completed,
            _ => throw new InvalidCastException(),
        };
}
