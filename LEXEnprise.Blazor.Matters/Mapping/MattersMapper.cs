using LEXEnprise.Blazor.Application.Models.Matters;
using LEXEnprise.Blazor.Matters.ViewModels;
using LEXEnprise.Blazor.Shared.Enums;
using System;

namespace LEXEnprise.Blazor.Matters.Mapping
{
    public static class MattersMapper
    {
        public static AddIPMatterRequest MapToAddIPMatterRequest(AddIPMatterModel source)
        {
            var request = new AddIPMatterRequest
            {
                CaseFolderId = source.CaseFolderId,
                CaseFolderCode = source.CaseFolderCode
            };

            request.Matter = new Matter
            {
                //CaseFolderId = source.CaseFolderId,
                //ClientId = source.ClientId,
                //CaseTypeId = source.CaseTypeId,
                //NatureOfCase = source.NatureOfCase,
                //SubjectMatter = source.SubjectMatter,
                //ParalegalId = source.ParalegalId,
                //DocketNumber = source.DocketNumber,
                //MatterStageId = source.MatterStageId,
                //StageAsOfDate = source.StageAsOfDate,
                //StatusId = source.StatusId,
                //FileNumber = source.FileNumber,
                //FileDate = source.FileDate,
                //ClientReference = source.ClientReference,

                CaseFolderId = source.CaseFolderId,
                ClientId = source.ClientId,
                CaseTypeId = 5,
                NatureOfCase = "Nature Of Case",
                SubjectMatter = "Subject Matter",
                ParalegalId = 4,
                DocketNumber = "Docket No3",
                MatterStageId = 5,
                StageAsOfDate = DateTime.Now,
                StatusId = 5,
                FileNumber = "FileNo3",
                FileDate = DateTime.Now,
                ClientReference = "ClientRef3"

            };

            foreach (var handlingLawyer in source.HandlingLawyers)
            {
                request.Matter.HandlingLawyers.Add(new MatterHandlingLawyer
                {
                    LawyerId = handlingLawyer.LawyerId,
                    IsMainLawyer = handlingLawyer.IsMainLawyer,
                    Action = handlingLawyer.Action
                });
            }

            request.OtherInfo = new IPMatterOtherInfo
            {
                //ApplicantId = source.ApplicantId,
                //ApplicantName = source.ApplicantName,
                //ApplicationTypeId = source.ApplicationTypeId,
                //ApplicationNumber = source.ApplicationNumber,
                //ApplicationDate = source.ApplicationDate,
                //PublicationDate = source.PublicationDate,
                //CertificateNumber = source.CertificateNumber,
                //CertificateDate = source.CertificateDate,
                //PCTApplicationNumber = source.PCTApplicationNumber,
                //PCTApplicationDate = source.PCTApplicationDate,
                //PCTLanguageNumber = source.PCTLanguageNumber,
                //PCTLanguageDate = source.PCTLanguageDate,
                //PCTPublicationNumber = source.PCTPublicationNumber,
                //PCTPublicationDate = source.PCTPublicationDate,
                //PriorityNumber = source.PriorityNumber,
                //PriorityDate = source.PriorityDate,
                //PriorityCountryFilingId = source.PriorityCountryFilingId,
                //DateWithdrawn = source.DateWithdrawn,
                //ReasonOfWithdrawn = source.ReasonOfWithdrawn,
                //RenewalDate = source.RenewalDate,
                //RenewalDau = source.RenewalDau,

                ApplicantId = 1,
                ApplicantName = "Applicant 1",
                ApplicationTypeId = 4,
                ApplicationNumber = "ApplicationNumber3",
                ApplicationDate = DateTime.Now,
                PublicationDate = DateTime.Now,
                CertificateNumber = "CertificateNumber3",
                CertificateDate = DateTime.Now,
                PCTApplicationNumber = "PCTApplicationNumber3",
                PCTApplicationDate = DateTime.Now,
                PCTLanguageNumber = "PCTLanguageNumber3",
                PCTLanguageDate = DateTime.Now,
                PCTPublicationNumber = "PCTPublicationNumber3",
                PCTPublicationDate = DateTime.Now,
                PriorityNumber = "PriorityNumber3",
                PriorityDate = DateTime.Now,
                PriorityCountryFilingId = 1,
                DateWithdrawn = null,
                ReasonOfWithdrawn = null,
                RenewalDate = null,
                RenewalDau = null,
            };

            return request;
        }
    }
}
