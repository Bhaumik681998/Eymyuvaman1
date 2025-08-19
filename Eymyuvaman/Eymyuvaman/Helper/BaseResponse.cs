using System.ComponentModel.DataAnnotations;

namespace Eymyuvaman.Helper
{
    public class BaseResponse
    {
        private bool _success { get; set; }
        [Required]
        public bool Success
        {
            get => _success;
            set
            {
                _success = value;
                Code = _success ? 200 : 400;
            }
        }
        [Required]
        public string Message { get; set; }
        public int Code { get; set; }
    }

    public class BaseResponseObject<T>
    {
        private bool _success { get; set; }
        [Required]
        public bool Success
        {
            get => _success;
            set
            {
                _success = value;
                Code = _success ? 200 : 400;
            }
        }
        [Required]
        public string Message { get; set; }
        [Required]
        public int Code { get; set; }
        public T? Data { get; set; }
    }

    public class BaseResponseModel<T>
    {
        private bool _success { get; set; }
        [Required]
        public bool Success
        {
            get => _success;
            set
            {
                _success = value;
                Code = _success ? 200 : 400;
            }
        }
        [Required]
        public string Message { get; set; }
        [Required]
        public int Code { get; set; }
        public int TotalRecored { get; set; }
        [Required]
        public T Data { get; set; }
    }

    public class BaseResponseError
    {
        public bool Success { get; set; }
        public ApiError error { get; set; }
    }

    public class ApiError
    {
        public int code { get; set; }
        public string? Message { get; set; }
    }
}
