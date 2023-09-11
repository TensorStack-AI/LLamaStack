﻿using LLamaStack.Core.Services;
using LLamaStack.WebApi.Models;

namespace LLamaStack.WebApi.Services
{
    public interface IApiSessionService
    {
        Task<ServiceResult<CreateResponse, ErrorResponse>> Create(CreateRequest request);
        Task<ServiceResult<CloseResponse, ErrorResponse>> Close(CloseRequest request);
        Task<ServiceResult<CancelResponse, ErrorResponse>> Cancel(CancelRequest request);
        Task<ServiceResult<InferResponse, ErrorResponse>> InferAsync(InferRequest request, CancellationToken cancellationToken);
        Task<ServiceResult<InferTextResponse, ErrorResponse>> InferTextAsync(InferRequest request, CancellationToken cancellationToken);
        Task<ServiceResult<InferTextCompleteResponse, ErrorResponse>> InferTextCompleteAsync(InferRequest request, CancellationToken cancellationToken);
        Task<ServiceResult<InferTextCompleteQueuedResponse, ErrorResponse>> InferTextCompleteQueuedAsync(InferRequest request, CancellationToken cancellationToken);
    }
}
