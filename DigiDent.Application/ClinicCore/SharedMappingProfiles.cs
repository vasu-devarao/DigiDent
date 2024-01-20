﻿using AutoMapper;
using DigiDent.Domain.ClinicCoreContext.Shared.ValueObjects;
using DigiDent.Domain.SharedKernel.Abstractions;
using DigiDent.Domain.SharedKernel.ValueObjects;

namespace DigiDent.Application.ClinicCore;

/// <summary>
/// Contains common AutoMapper profiles that are shared among multiple aggregates.
/// </summary>
public class SharedMappingProfiles: Profile
{
    public SharedMappingProfiles()
    {
        CreateMap(typeof(ITypedId<Guid>), typeof(Guid))
            .ConvertUsing(typeof(TypedIdGuidResolver));
        
        CreateMap<FullName, string>()
            .ConvertUsing(fullName => fullName.ToString());
        
        CreateMap<Email, string>()
            .ConvertUsing(email => email.Value);
        
        CreateMap<PhoneNumber, string>()
            .ConvertUsing(phoneNumber => phoneNumber.Value);

        CreateMap<Gender, string>()
            .ConvertUsing(gender => gender.ToString());
    }
    
    private class TypedIdGuidResolver: IValueResolver<ITypedId<Guid>, Guid, Guid>
    {
        public Guid Resolve(ITypedId<Guid> source, Guid destination, Guid destMember, ResolutionContext context)
        {
            return source.Value;
        }
    }
}

