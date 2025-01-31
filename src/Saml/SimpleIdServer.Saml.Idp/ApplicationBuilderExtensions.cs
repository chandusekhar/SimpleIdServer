﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using SimpleIdServer.Saml.Middlewares;

namespace Microsoft.AspNetCore.Builder
{
    public static class ApplicationBuilderExtensions
    {
        public static IApplicationBuilder UseSamlIdp(this IApplicationBuilder applicationBuilder) 
        {
            applicationBuilder.UseMiddleware<SamlExceptionMiddleware>();
            return applicationBuilder;
        }
    }
}
