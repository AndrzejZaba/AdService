﻿using Microsoft.AspNetCore.Identity;


namespace AdService.Infrastructure.Identity;

public class LocalizedIdentityErrorDescriber : IdentityErrorDescriber
{
    private const string Password = "Password";
    private const string Email = "Email";

    public override IdentityError PasswordMismatch()
    {
        return new IdentityError
        {
            Code = Password,
            Description = "Hasło i Potwierdzone hasło są różne."
        };
    }

    public override IdentityError PasswordRequiresDigit()
    {
        return new IdentityError
        {
            Code = Password,
            Description = "Hasło musi zawierać przynajmniej 1 cyfrę."
        };
    }

    public override IdentityError PasswordRequiresLower()
    {
        return new IdentityError
        {
            Code = Password,
            Description = "Hasło musi zawierać przynajmniej 1 małą literę."
        };
    }

    public override IdentityError PasswordRequiresNonAlphanumeric()
    {
        return new IdentityError
        {
            Code = Password,
            Description = "Hasło musi zawierać przynajmniej 1 znak specjalny (np. $, #, & itp)."
        };
    }

    public override IdentityError PasswordRequiresUpper()
    {
        return new IdentityError
        {
            Code = Password,
            Description = "Hasło musi zawierać przynajmniej 1 dużą literę."
        };
    }

    public override IdentityError PasswordTooShort(int length)
    {
        return new IdentityError
        {
            Code = Password,
            Description = "Hasło musi mieć co najmniej 8 znaków i nie więcej niż 100 znaków."
        };
    }

    public override IdentityError DuplicateUserName(string userName)
    {
        return new IdentityError
        {
            Code = Email,
            Description = "Wybrany e-mail jest już zajęty."
        };
    }
}
