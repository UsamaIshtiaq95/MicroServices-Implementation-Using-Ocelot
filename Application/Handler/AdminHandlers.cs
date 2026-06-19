using Application.DTO;
using Application.Request;
using MediatR;
using UserDomain;
using UserDomain.Entities;
using UserDomain.Interface;

namespace Application.Handler;

public class CreateAdminHandler : IRequestHandler<CreateAdminRequest, CreateAdminResponse>
{
    private readonly IAdminRepository _adminRepository;

    public CreateAdminHandler(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public async Task<CreateAdminResponse> Handle(CreateAdminRequest request, CancellationToken cancellationToken)
    {
        var admin = new Admins
        {
            Username = request.AdminDto.Username,
            Email = request.AdminDto.Email,
            PasswordHash = request.AdminDto.PasswordHash,
            IsActive = request.AdminDto.IsActive,
            CreatedAt = DateTime.Now
        };

        var createdAdmin = await _adminRepository.AddAsync(admin);

        return new CreateAdminResponse
        {
            Admin = new AdminResponseDto
            {
                AdminId = createdAdmin.AdminId,
                Username = createdAdmin.Username,
                Email = createdAdmin.Email,
                IsActive = createdAdmin.IsActive,
                CreatedAt = createdAdmin.CreatedAt
            },
            Message = "Admin created successfully"
        };
    }
}

public class GetAllAdminsHandler : IRequestHandler<GetAllAdminsRequest, GetAllAdminsResponse>
{
    private readonly IAdminRepository _adminRepository;

    public GetAllAdminsHandler(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public async Task<GetAllAdminsResponse> Handle(GetAllAdminsRequest request, CancellationToken cancellationToken)
    {
        var admins = await _adminRepository.GetAllAsync();

        var adminDtos = admins.Select(a => new AdminResponseDto
        {
            AdminId = a.AdminId,
            Username = a.Username,
            Email = a.Email,
            IsActive = a.IsActive,
            CreatedAt = a.CreatedAt
        });

        return new GetAllAdminsResponse { Admins = adminDtos };
    }
}

public class GetAdminByIdHandler : IRequestHandler<GetAdminByIdRequest, GetAdminByIdResponse>
{
    private readonly IAdminRepository _adminRepository;

    public GetAdminByIdHandler(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public async Task<GetAdminByIdResponse> Handle(GetAdminByIdRequest request, CancellationToken cancellationToken)
    {
        var admin = await _adminRepository.GetByIdAsync(request.Id);

        if (admin == null)
            throw new NotFoundException("Admin not found");

        return new GetAdminByIdResponse
        {
            Admin = new AdminResponseDto
            {
                AdminId = admin.AdminId,
                Username = admin.Username,
                Email = admin.Email,
                IsActive = admin.IsActive,
                CreatedAt = admin.CreatedAt
            }
        };
    }
}

public class UpdateAdminHandler : IRequestHandler<UpdateAdminRequest, UpdateAdminResponse>
{
    private readonly IAdminRepository _adminRepository;

    public UpdateAdminHandler(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public async Task<UpdateAdminResponse> Handle(UpdateAdminRequest request, CancellationToken cancellationToken)
    {
        var admin = await _adminRepository.GetByIdAsync(request.Id);

        if (admin == null)
            throw new NotFoundException("Admin not found");

        admin.Username = request.AdminDto.Username;
        admin.Email = request.AdminDto.Email;
        admin.IsActive = request.AdminDto.IsActive;

        await _adminRepository.UpdateAsync(admin);

        return new UpdateAdminResponse { Message = "Admin updated successfully" };
    }
}

public class DeleteAdminHandler : IRequestHandler<DeleteAdminRequest, DeleteAdminResponse>
{
    private readonly IAdminRepository _adminRepository;

    public DeleteAdminHandler(IAdminRepository adminRepository)
    {
        _adminRepository = adminRepository;
    }

    public async Task<DeleteAdminResponse> Handle(DeleteAdminRequest request, CancellationToken cancellationToken)
    {
        var admin = await _adminRepository.GetByIdAsync(request.Id);

        if (admin == null)
            throw new NotFoundException("Admin not found");

        await _adminRepository.DeleteAsync(request.Id);

        return new DeleteAdminResponse { Message = "Admin deleted successfully" };
    }
}
