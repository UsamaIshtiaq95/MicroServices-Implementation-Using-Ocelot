using Application.DTO;
using Application.Request;
using MediatR;
using UserDomain;
using UserDomain.Entities;
using UserDomain.Interface;

namespace Application.Handler;

public class CreateLogHandler : IRequestHandler<CreateLogRequest, CreateLogResponse>
{
    private readonly ILogRepository _logRepository;

    public CreateLogHandler(ILogRepository logRepository)
    {
        _logRepository = logRepository;
    }

    public async Task<CreateLogResponse> Handle(CreateLogRequest request, CancellationToken cancellationToken)
    {
        var log = new Logs
        {
            UserId = request.LogDto.UserId,
            Action = request.LogDto.Action,
            CreatedAt = DateTime.Now
        };

        var createdLog = await _logRepository.AddAsync(log);

        return new CreateLogResponse
        {
            Log = new LogResponseDto
            {
                LogId = createdLog.LogId,
                UserId = createdLog.UserId,
                Action = createdLog.Action,
                CreatedAt = createdLog.CreatedAt
            },
            Message = "Log created successfully"
        };
    }
}

public class GetAllLogsHandler : IRequestHandler<GetAllLogsRequest, GetAllLogsResponse>
{
    private readonly ILogRepository _logRepository;

    public GetAllLogsHandler(ILogRepository logRepository)
    {
        _logRepository = logRepository;
    }

    public async Task<GetAllLogsResponse> Handle(GetAllLogsRequest request, CancellationToken cancellationToken)
    {
        var logs = await _logRepository.GetAllAsync();

        var logDtos = logs.Select(l => new LogResponseDto
        {
            LogId = l.LogId,
            UserId = l.UserId,
            Action = l.Action,
            CreatedAt = l.CreatedAt
        });

        return new GetAllLogsResponse { Logs = logDtos };
    }
}

public class GetLogByIdHandler : IRequestHandler<GetLogByIdRequest, GetLogByIdResponse>
{
    private readonly ILogRepository _logRepository;

    public GetLogByIdHandler(ILogRepository logRepository)
    {
        _logRepository = logRepository;
    }

    public async Task<GetLogByIdResponse> Handle(GetLogByIdRequest request, CancellationToken cancellationToken)
    {
        var log = await _logRepository.GetByIdAsync(request.Id);

        if (log == null)
            throw new NotFoundException("Log not found");

        return new GetLogByIdResponse
        {
            Log = new LogResponseDto
            {
                LogId = log.LogId,
                UserId = log.UserId,
                Action = log.Action,
                CreatedAt = log.CreatedAt
            }
        };
    }
}

public class GetLogsByUserIdHandler : IRequestHandler<GetLogsByUserIdRequest, GetLogsByUserIdResponse>
{
    private readonly ILogRepository _logRepository;

    public GetLogsByUserIdHandler(ILogRepository logRepository)
    {
        _logRepository = logRepository;
    }

    public async Task<GetLogsByUserIdResponse> Handle(GetLogsByUserIdRequest request, CancellationToken cancellationToken)
    {
        var logs = await _logRepository.GetByUserIdAsync(request.UserId);

        var logDtos = logs.Select(l => new LogResponseDto
        {
            LogId = l.LogId,
            UserId = l.UserId,
            Action = l.Action,
            CreatedAt = l.CreatedAt
        });

        return new GetLogsByUserIdResponse { Logs = logDtos };
    }
}

public class UpdateLogHandler : IRequestHandler<UpdateLogRequest, UpdateLogResponse>
{
    private readonly ILogRepository _logRepository;

    public UpdateLogHandler(ILogRepository logRepository)
    {
        _logRepository = logRepository;
    }

    public async Task<UpdateLogResponse> Handle(UpdateLogRequest request, CancellationToken cancellationToken)
    {
        var log = await _logRepository.GetByIdAsync(request.Id);

        if (log == null)
            throw new NotFoundException("Log not found");

        log.Action = request.LogDto.Action;

        await _logRepository.UpdateAsync(log);

        return new UpdateLogResponse { Message = "Log updated successfully" };
    }
}

public class DeleteLogHandler : IRequestHandler<DeleteLogRequest, DeleteLogResponse>
{
    private readonly ILogRepository _logRepository;

    public DeleteLogHandler(ILogRepository logRepository)
    {
        _logRepository = logRepository;
    }

    public async Task<DeleteLogResponse> Handle(DeleteLogRequest request, CancellationToken cancellationToken)
    {
        var log = await _logRepository.GetByIdAsync(request.Id);

        if (log == null)
            throw new NotFoundException("Log not found");

        await _logRepository.DeleteAsync(request.Id);

        return new DeleteLogResponse { Message = "Log deleted successfully" };
    }
}
