using System;
using Microsoft.Extensions.Logging;

namespace Microsoft.AspNetCore.Server.HttpSys
{
    /// <summary>
    /// Rule that maintains a handle to the Request Queue and UrlPrefix to
    /// delegate to.
    /// </summary>
    public class DelegationRule : IDisposable
    {
        private readonly ILogger _logger;
        /// <summary>
        /// The name of the Http.Sys request queue
        /// </summary>
        public string QueueName { get; }
        /// <summary>
        /// The URL 
        /// </summary>
        public string UrlPrefix { get; }
        internal RequestQueue Queue { get; }

        internal DelegationRule(string queueName, string urlPrefix, ILogger logger)
        {
            _logger = logger;
            QueueName = queueName;
            UrlPrefix = urlPrefix;
            Queue = new RequestQueue(null, queueName, UrlPrefix, _logger, receiver: true);
        }

        public void Dispose()
        {
            Queue.UrlGroup?.Dispose();
            Queue?.Dispose();
        }
    }
}
