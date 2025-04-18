﻿using Microsoft.AspNetCore.Authorization;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace AspNetCoreWithSecrets.Authz;

public class StorageBlobDataReaderRoleHandler : AuthorizationHandler<StorageBlobDataReaderRoleRequirement>
{
    protected override Task HandleRequirementAsync(
        AuthorizationHandlerContext context,
        StorageBlobDataReaderRoleRequirement requirement
    )
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentNullException.ThrowIfNull(requirement);

        //  "6705345e-c37e-4f7a-b2d9-e2f43e029524" // StorageContributorsAzureADfiles
        //  "a7bd0f89-ff92-48af-b14b-c4b4a77ea6cf" // StorageReadersAzureADfiles

        var spIdUserGroup = context.User.Claims.FirstOrDefault(t => t.Type == "groups" &&
          (t.Value == "6705345e-c37e-4f7a-b2d9-e2f43e029524" ||
          t.Value == "a7bd0f89-ff92-48af-b14b-c4b4a77ea6cf"));

        if (spIdUserGroup != null)
        {
            context.Succeed(requirement);
        }
        context.Succeed(requirement);

        return Task.CompletedTask;
    }
}