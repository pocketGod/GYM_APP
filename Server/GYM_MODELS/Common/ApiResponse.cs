using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GYM_MODELS.Common
{
    /// <summary>
    /// Standard API response model.
    /// </summary>
    /// <typeparam name="T">Type of the result.</typeparam>
    public class ApiResponse<T>
    {
        /// <summary>
        /// The actual result data.
        /// </summary>
        public T result { get; set; }

        /// <summary>
        /// Unique ID for the operation.
        /// </summary>
        public int id { get; set; }

        /// <summary>
        /// Information about any exception that occurred.
        /// </summary>
        public object exception { get; set; }

        /// <summary>
        /// HTTP status code.
        /// </summary>
        public int status { get; set; }

        /// <summary>
        /// Indicates whether the operation was canceled.
        /// </summary>
        public bool isCanceled { get; set; }

        /// <summary>
        /// Indicates whether the operation is complete.
        /// </summary>
        public bool isCompleted { get; set; }

        /// <summary>
        /// Indicates whether the operation completed successfully.
        /// </summary>
        public bool isCompletedSuccessfully { get; set; }

        /// <summary>
        /// Provides task creation options.
        /// </summary>
        public int creationOptions { get; set; }

        /// <summary>
        /// State information that can be used by the task's callback.
        /// </summary>
        public object asyncState { get; set; }

        /// <summary>
        /// Indicates whether the operation is faulted (i.e., has exceptions).
        /// </summary>
        public bool isFaulted { get; set; }
    }


}
