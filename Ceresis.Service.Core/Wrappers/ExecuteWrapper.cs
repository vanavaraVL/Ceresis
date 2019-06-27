using Ceresis.Data.Core.Response;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ceresis.Service.Core.Wrappers
{
    public static class ExecuteWrapper
    {
        public static TResponse Execute<TResponse>(Func<TResponse> action) where TResponse : ResponseBase, new()
        {
            var response = new TResponse();

            try
            {
                response = action.Invoke();
            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Message = ex.Message;
            }

            return response;
        }

        public static async Task<TResponse> Execute<TResponse>(Func<Task<TResponse>> action) where TResponse : ResponseBase, new()
        {
            var response = new TResponse();

            try
            {
                response = await action.Invoke();
            }
            catch (Exception ex)
            {
                response.IsError = true;
                response.Message = ex.Message;
            }

            return response;
        }
    }
}
