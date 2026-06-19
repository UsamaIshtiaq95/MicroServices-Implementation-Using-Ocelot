using Application.DTO;
using MediatR;

namespace Application.Request;

// Log Create
public class CreateLogRequest : IRequest<CreateLogResponse>
{
    public LogCreateDto LogDto { get; set; }
}

public class CreateLogResponse
{
    public LogResponseDto Log { get; set; }
    public string Message { get; set; }
}

// Log Get All
public class GetAllLogsRequest : IRequest<GetAllLogsResponse>
{
}

public class GetAllLogsResponse
{
    public IEnumerable<LogResponseDto> Logs { get; set; }
}

// Log Get By Id
public class GetLogByIdRequest : IRequest<GetLogByIdResponse>
{
    public int Id { get; set; }
}

public class GetLogByIdResponse
{
    public LogResponseDto Log { get; set; }
}

// Log Get By User Id
public class GetLogsByUserIdRequest : IRequest<GetLogsByUserIdResponse>
{
    public int UserId { get; set; }
}

public class GetLogsByUserIdResponse
{
    public IEnumerable<LogResponseDto> Logs { get; set; }
}

// Log Update
public class UpdateLogRequest : IRequest<UpdateLogResponse>
{
    public int Id { get; set; }
    public LogUpdateDto LogDto { get; set; }
}

public class UpdateLogResponse
{
    public string Message { get; set; }
}

// Log Delete
public class DeleteLogRequest : IRequest<DeleteLogResponse>
{
    public int Id { get; set; }
}

public class DeleteLogResponse
{
    public string Message { get; set; }
}
