using LEXEnprise.Blazor.Application.Models;
using LEXEnprise.Blazor.Application.Models.Clients;
using LEXEnprise.Blazor.Application.Models.Lookup;
using LEXEnprise.Blazor.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LEXEnprise.Blazor.Clients.Mapping
{
    public static class ClientsMapper
    {
        public static UpdateClientRequest MapToUpdateClientRequest(GetClientResponse source)
        {
            var request = new UpdateClientRequest
            {
                Id                  = source.Id,
                ClientNumber        = source.ClientNumber     ,
                ClientName          = source.ClientName       ,
                UnitDescription     = source.UnitDescription  ,
                Address1            = source.Address1         ,
                Address2            = source.Address2         ,
                CityId              = source.CityId           ,
                StateId             = source.StateId          ,
                CountryId           = source.CountryId        ,
                ClientIndustryId    = source.ClientIndustryId ,
                Website             = source.Website          ,
                PhoneNumber         = source.PhoneNumber      ,
                MobileNumber        = source.MobileNumber     ,
                Email               = source.Email            ,
                ClientCategoryId    = source.ClientCategoryId ,
                BillingCurrencyId   = source.BillingCurrencyId,
                DateAcquired        = source.DateAcquired     ,
                ClientStatusId      = source.ClientStatusId   ,
                ClientTypeId        = source.ClientTypeId     ,
                Remarks             = source.Remarks          ,
                AccountManagerId    = source.AccountManagerId ,

                Status = new ClientStatus
                {
                    Id = source.Status.Id,
                    Status = source.Status.Status
                }
                
                //City = new City { Id = source.City.Id, CityName = source.City.CityName },
                //State = new State { Id = source.State.Id, StateCode = source.State.StateCode, StateName = source.State.StateName },
                //Country = new Country { Id = source.Country.Id, CountryCode = source.Country.CountryCode, CountryName = source.Country.CountryName },
                //Category = new ClientCategory { Id = source.Category.Id, Category = source.Category.Category },
                //Status = new ClientStatus { Id = source.Status.Id, Status = source.Status.Status },
                //BillingCurrency = new Currency { Id = source.BillingCurrency.Id, CurrencyCode = source.BillingCurrency.CurrencyCode, CurrencyName = source.BillingCurrency.CurrencyName },
                //Industry = new Industry { Id = source.Industry.Id, IndustryName = source.Industry.IndustryName },
                //ClientType = new ClientType { Id = source.ClientType.Id, ClientTypeName = source.ClientType.ClientTypeName },
                //AccountManager
            };

            foreach (var contact in source.Contacts)
            {
                request.Contacts.Add(new Contact
                {
                    Id = contact.Id,
                    ContactPerson = contact.ContactPerson,
                    Email = contact.Email,
                    Address1 = contact.Address1,
                    Address2 = contact.Address2,
                    PhoneNumber = contact.PhoneNumber,
                    Mobile = contact.Mobile,
                    Position = contact.Position,
                    Remarks = contact.Remarks,
                    IsMainAccountOfficer = contact.IsMainAccountOfficer,
                    Action = DataActions.None
                });
            }

            return request;
        }
    }
}
