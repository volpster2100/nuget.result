namespace Fcbc.Utility.Result
{
    /// <summary>
    /// A wrapper class that indicates the success or failure of an operation.
    /// </summary>
    /// <typeparam name="TSuccess">The type of your success value.</typeparam>
    /// <typeparam name="TError">The type of your error value.</typeparam>
    public class Result<TSuccess, TError>
    {
        /// <summary>
        /// When true, indicates that the operation was a success and the result of the operation can be pulled from the Value property.
        /// When false, indicates that the operation failed and error information can be pulled from the Error property.
        /// </summary>
        public readonly bool IsSuccess;

        /// <summary>
        /// Contains the result of the operation.
        /// </summary>
        public readonly TSuccess Value;

        /// <summary>
        /// Contains the error information for the failed operation.
        /// </summary>
        public readonly TError Error;

        /// <summary>
        /// Instantiates a new Result that indicates a successful operation.
        /// </summary>
        /// <param name="success">The success value to be returned by th</param>
        public Result(TSuccess success)
        {
            IsSuccess = true;
            Value = success;
        }

        /// <summary>
        /// Instantiates a new Result that indicates a failed operation.
        /// </summary>
        /// <param name="error"></param>
        public Result(TError error)
        {
            IsSuccess = false;
            Error = error;
        }

        /// <summary>
        /// Allows return statements to be implicitly converted into a success response.
        /// </summary>
        public static implicit operator Result<TSuccess, TError>(TSuccess success){
            return new Result<TSuccess, TError>(success);
        }

        /// <summary>
        /// Allows return statements to be implicitly converted into a failure response.
        /// </summary>
        public static implicit operator Result<TSuccess, TError>(TError error){
            return new Result<TSuccess, TError>(error);
        }
    }

    /// <summary>
    /// A wrapper class that indicates the success or failure of operations that return no value.
    /// </summary>
    /// <typeparam name="TError">The type of your error value.</typeparam>
    public class VoidResult<TError>
    {
        /// <summary>
        /// When true, indicates that the operation was a success.
        /// When false, indicates that the operation failed and error information can be pulled from the Error property.
        /// </summary>
        public readonly bool IsSuccess;

        /// <summary>
        /// Contains the error information for the failed operation.
        /// </summary>
        public readonly TError Error;

        /// <summary>
        /// Instantiates a new VoidResult that indicates a successful operation.
        /// </summary>
        public VoidResult()
        {
            IsSuccess = true;
        }

        /// <summary>
        /// Instantiates a new VoidResult that indicates a failed operation.
        /// </summary>
        public VoidResult(TError error){
            IsSuccess = false;
            Error = error;
        }

        /// <summary>
        /// Allows return statements to be implicitly converted into a failure response.
        /// </summary>
        public static implicit operator VoidResult<TError>(TError error){
            return new VoidResult<TError>(error);
        }
    }
}
