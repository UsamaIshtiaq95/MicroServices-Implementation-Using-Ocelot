using Application.DTO;
using MediatR;

namespace Application.Request;

// Admin Create
public class CreateAdminRequest : IRequest<CreateAdminResponse>
{
    public AdminCreateDto AdminDto { get; set; }
}

public class CreateAdminResponse
{
    public AdminResponseDto Admin { get; set; }
    public string Message { get; set; }
}

// Admin Get All
public class GetAllAdminsRequest : IRequest<GetAllAdminsResponse>
{
}

public class GetAllAdminsResponse
{
    public IEnumerable<AdminResponseDto> Admins { get; set; }
}

// Admin Get By Id
public class GetAdminByIdRequest : IRequest<GetAdminByIdResponse>
{
    public int Id { get; set; }
}

public class GetAdminByIdResponse
{
    public AdminResponseDto Admin { get; set; }
}

// Admin Update
public class UpdateAdminRequest : IRequest<UpdateAdminResponse>
{
    public int Id { get; set; }
    public AdminUpdateDto AdminDto { get; set; }
}

public class UpdateAdminResponse
{
    public string Message { get; set; }
}

// Admin Delete
public class DeleteAdminRequest : IRequest<DeleteAdminResponse>
{
    public int Id { get; set; }
}

public class DeleteAdminResponse
{
    public string Message { get; set; }
}
