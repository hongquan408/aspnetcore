// Copyright (c) .NET Foundation. All rights reserved.
// Licensed under the Apache License, Version 2.0. See License.txt in the project root for license information.

namespace Microsoft.AspNetCore.Server.HttpSys
{
    public interface IHttpSysRequestTransferFeature
    {
        /// <summary>
        /// Indicates if the server can transfer this request to another HttpSys request queue.
        /// </summary>
        bool IsTransferable { get; }

        /// <summary>
        /// Attempt to transfer the request to another HttpSys request queue. The request body
        /// must not be read before this is invoked. Check <see cref="IsTransferable"/>
        /// before invoking.
        /// </summary>
        void TransferRequest(DelegationRule destination);
    }
}
