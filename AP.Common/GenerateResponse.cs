using AP.Models;

namespace AP.Common
{
    public static class GenerateResponse
    {
        public static ApiResponseViewModel<T> CreateResponse<T>(int nStatusCode, string? sMessage, T? objData, List<T>? lstData)
        {
            ApiResponseViewModel<T> objResult = new ApiResponseViewModel<T>
            {
                StatusCode = nStatusCode,
                Message = sMessage,
                Data = objData,
                DataList = lstData
            };
            return objResult;
        }

    }
}
