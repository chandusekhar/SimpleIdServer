﻿// Copyright (c) SimpleIdServer. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;
using SimpleIdServer.Gateway.Host.Handlers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;

namespace SimpleIdServer.Gateway.Host
{
    public class Startup
    {
        public Startup(IHostingEnvironment env, IConfiguration configuration) 
        {
            Env = env;
            Configuration = configuration;
        }

        public IHostingEnvironment Env { get; private set; }
        public IConfiguration Configuration { get; private set; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => options.AddPolicy("AllowAll", p => p.AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader()));
            services.AddAuthentication()
            .AddJwtBearer("Authenticated", options =>
            {
                 options.TokenValidationParameters = new TokenValidationParameters
                 {
                     IssuerSigningKey = ExtractKey("openid_puk.txt"),
                     ValidAudiences = new List<string>
                    {
                        "https://localhost:60000"
                    },
                     ValidIssuers = new List<string>
                    {
                        "https://localhost:60000"
                    }
                 };
            });
            services.AddLogging();
            services.AddOcelot(Configuration)
                .AddDelegatingHandler<ManageClientClientCredentialsHandler>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseCors("AllowAll");
            app.UseOcelot().Wait();
        }

        private RsaSecurityKey ExtractKey(string fileName)
        {
            var json = File.ReadAllText(Path.Combine(Env.ContentRootPath, fileName));
            var dic = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
            var rsa = RSA.Create();
            var rsaParameters = new RSAParameters
            {
                Modulus = Convert.FromBase64String(dic["n"].ToString()),
                Exponent = Convert.FromBase64String(dic["e"].ToString())
            };
            rsa.ImportParameters(rsaParameters);
            return new RsaSecurityKey(rsa);
        }
    }
}