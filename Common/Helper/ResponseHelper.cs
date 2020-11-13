using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AutoWrapper;
using AutoWrapper.Wrappers;

namespace Common.Helper
{
    public static class ResponseHelper
    {
        public static ApiResponse CreateSuccessResponse(object data, string message)
        {   
            return new ApiResponse { Message = message, Result = data, StatusCode = (int)HttpStatusCode.OK };
        }

        public static ApiResponse CreateGetSuccessResponse(object data)
        {
            return new ApiResponse { Result = data, StatusCode = (int)HttpStatusCode.OK };
        }

        public static ApiResponse CreateAddSuccessResponse()
        {
            return new ApiResponse { Message = Constants.AddSuccess, StatusCode = (int)HttpStatusCode.OK };
        }

        public static ApiResponse CreateUpdateSuccessResponse()
        {
            return new ApiResponse { Message = Constants.UpdateSuccess, StatusCode = (int)HttpStatusCode.OK };
        }

        public static ApiResponse CreateRemoveSuccessResponse()
        {
            return new ApiResponse { Message = Constants.RemoveSuccess, StatusCode = (int)HttpStatusCode.OK };
        }

        public static ApiResponse CreateErrorResponse(string message)
        {
            return new ApiResponse((int)HttpStatusCode.BadRequest,new List<string>() { message });
        }

        public static ApiResponse CreateNotFoundErrorResponse(string message)
        {
            return new ApiResponse((int)HttpStatusCode.NotFound, new List<string>() { message });
        }
        public static ApiResponse CreateExceptionErrorResponse()
        {
            return new ApiResponse((int)HttpStatusCode.InternalServerError, new List<string>() { Constants.ExceptionMessage });
        }

        public static ApiResponse CreateValidationErrorResponse(object validationErrors)
        {
            return new ApiResponse((int)HttpStatusCode.BadRequest, validationErrors);
        }
    }
}
