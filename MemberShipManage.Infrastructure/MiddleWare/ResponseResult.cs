using System;

namespace MemberShipManage.Infrastructure.MiddleWare
{
    public class ResponseResult
    {
        /// <summary>
        /// 响应码
        /// </summary>
        public ResponseResultStatus Status { get; set; }

        /// <summary>
        /// 响应信息
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// 成功
        /// </summary>
        public bool Success => Status == ResponseResultStatus.Succedeed;

        /// <summary>
        /// 时间戳(毫秒)
        /// </summary>
        public long Timestamp { get; } = DateTimeOffset.UtcNow.ToUnixTimeMilliseconds();

        /// <summary>
        /// 响应成功
        /// </summary>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public void BuildSucceededResult(string message = "")
        {
            Message = message;
            Status = ResponseResultStatus.Succedeed;
        }

        /// <summary>
        /// 响应失败
        /// </summary>
        /// <param name="message"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public void BuildFailedResult(string message = "")
        {
            Message = message;
            Status = ResponseResultStatus.Failed;
        }

        /// <summary>
        /// 响应失败
        /// </summary>
        /// <param name="exexception></param>
        /// <param name="data"></param>
        /// <returns></returns>
        public void BuildFailedResult(Exception exception)
        {
            Message = exception.InnerException?.StackTrace;
            Status = ResponseResultStatus.Failed;
        }
    }
}
