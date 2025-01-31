﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Microsoft.Extensions.Configuration;

namespace SimpleIdServer.Gateway.Host.Handlers
{
    public class ManageClientClientCredentialsHandler : BaseClientCredentialsHandler
    {
        public ManageClientClientCredentialsHandler(IConfiguration configuration) : base(configuration, new[] { 
            "manage_clients", 
            "manage_scopes",
            "manage_users",
            "query_scim_resource",
            "add_scim_resource",
            "delete_scim_resource",
            "update_scim_resource",
            "bulk_scim_resource",
            "scim_provision",
            "manage_authschemeproviders",
            "manage_relying_parties"
        }) { }
    }
}
