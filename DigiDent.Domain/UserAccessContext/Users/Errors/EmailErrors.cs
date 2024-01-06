﻿using DigiDent.Domain.SharedKernel;

namespace DigiDent.Domain.UserAccessContext.Roles.Errors;

public static class EmailErrors
{
    public static Error EmailDoesNotMatchRules
        => new (ErrorType.Validation, 
            "Email should match the default set of email creation rules.");
    
    public static Error EmailIsNotUnique(string email)
        => new (ErrorType.Conflict, $"User with email {email} already exists.");
    
    public static Error EmailIsNotRegistered(string email)
        => new (ErrorType.NotFound, $"User with email {email} is not registered.");
}