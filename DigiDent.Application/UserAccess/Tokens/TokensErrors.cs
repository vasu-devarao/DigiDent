﻿using DigiDent.Domain.SharedKernel;

namespace DigiDent.Application.UserAccess.Tokens;

public static class TokensErrors
{
    public static Error InvalidToken =>
        new(ErrorType.Validation, "Invalid token.");
    
    public static Error TokenIsNotExpired =>
        new(ErrorType.Conflict, "This token hasn't expired yet.");
    
}