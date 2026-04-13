using Application.DTO;
using Application.Request;
using MediatR;
using UserDomain;
using UserDomain.Entities;
using UserDomain.Interface;

namespace Application.Handler;

public class CreateImageHandler : IRequestHandler<CreateImageRequest, CreateImageResponse>
{
    private readonly IImageRepository _imageRepository;

    public CreateImageHandler(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }

    public async Task<CreateImageResponse> Handle(CreateImageRequest request, CancellationToken cancellationToken)
    {
        var image = new Images
        {
            RoomId = request.ImageDto.RoomId,
            FileName = request.ImageDto.FileName,
            FilePath = request.ImageDto.FilePath,
            UploadedAt = DateTime.Now
        };

        var createdImage = await _imageRepository.AddAsync(image);

        return new CreateImageResponse
        {
            Image = new ImageResponseDto
            {
                ImageId = createdImage.ImageId,
                RoomId = createdImage.RoomId,
                FileName = createdImage.FileName,
                FilePath = createdImage.FilePath,
                UploadedAt = createdImage.UploadedAt
            },
            Message = "Image created successfully"
        };
    }
}

public class GetAllImagesHandler : IRequestHandler<GetAllImagesRequest, GetAllImagesResponse>
{
    private readonly IImageRepository _imageRepository;

    public GetAllImagesHandler(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }

    public async Task<GetAllImagesResponse> Handle(GetAllImagesRequest request, CancellationToken cancellationToken)
    {
        var images = await _imageRepository.GetAllAsync();

        var imageDtos = images.Select(i => new ImageResponseDto
        {
            ImageId = i.ImageId,
            RoomId = i.RoomId,
            FileName = i.FileName,
            FilePath = i.FilePath,
            UploadedAt = i.UploadedAt
        });

        return new GetAllImagesResponse { Images = imageDtos };
    }
}

public class GetImageByIdHandler : IRequestHandler<GetImageByIdRequest, GetImageByIdResponse>
{
    private readonly IImageRepository _imageRepository;

    public GetImageByIdHandler(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }

    public async Task<GetImageByIdResponse> Handle(GetImageByIdRequest request, CancellationToken cancellationToken)
    {
        var image = await _imageRepository.GetByIdAsync(request.Id);

        if (image == null)
            throw new NotFoundException("Image not found");

        return new GetImageByIdResponse
        {
            Image = new ImageResponseDto
            {
                ImageId = image.ImageId,
                RoomId = image.RoomId,
                FileName = image.FileName,
                FilePath = image.FilePath,
                UploadedAt = image.UploadedAt
            }
        };
    }
}

public class GetImagesByRoomIdHandler : IRequestHandler<GetImagesByRoomIdRequest, GetImagesByRoomIdResponse>
{
    private readonly IImageRepository _imageRepository;

    public GetImagesByRoomIdHandler(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }

    public async Task<GetImagesByRoomIdResponse> Handle(GetImagesByRoomIdRequest request, CancellationToken cancellationToken)
    {
        var images = await _imageRepository.GetByRoomIdAsync(request.RoomId);

        var imageDtos = images.Select(i => new ImageResponseDto
        {
            ImageId = i.ImageId,
            RoomId = i.RoomId,
            FileName = i.FileName,
            FilePath = i.FilePath,
            UploadedAt = i.UploadedAt
        });

        return new GetImagesByRoomIdResponse { Images = imageDtos };
    }
}

public class UpdateImageHandler : IRequestHandler<UpdateImageRequest, UpdateImageResponse>
{
    private readonly IImageRepository _imageRepository;

    public UpdateImageHandler(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }

    public async Task<UpdateImageResponse> Handle(UpdateImageRequest request, CancellationToken cancellationToken)
    {
        var image = await _imageRepository.GetByIdAsync(request.Id);

        if (image == null)
            throw new NotFoundException("Image not found");

        image.RoomId = request.ImageDto.RoomId;
        image.FileName = request.ImageDto.FileName;
        image.FilePath = request.ImageDto.FilePath;

        await _imageRepository.UpdateAsync(image);

        return new UpdateImageResponse { Message = "Image updated successfully" };
    }
}

public class DeleteImageHandler : IRequestHandler<DeleteImageRequest, DeleteImageResponse>
{
    private readonly IImageRepository _imageRepository;

    public DeleteImageHandler(IImageRepository imageRepository)
    {
        _imageRepository = imageRepository;
    }

    public async Task<DeleteImageResponse> Handle(DeleteImageRequest request, CancellationToken cancellationToken)
    {
        var image = await _imageRepository.GetByIdAsync(request.Id);

        if (image == null)
            throw new NotFoundException("Image not found");

        await _imageRepository.DeleteAsync(request.Id);

        return new DeleteImageResponse { Message = "Image deleted successfully" };
    }
}
