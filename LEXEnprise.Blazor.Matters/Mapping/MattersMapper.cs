using LEXEnprise.Blazor.Application.Models.Matters;
using LEXEnprise.Blazor.Matters.ViewModels;
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
                DocketNumber = "Docket No1",
                MatterStageId = 5,
                StageAsOfDate = DateTime.Now,
                StatusId = 5,
                FileNumber = "FileNo1",
                FileDate = DateTime.Now,
                ClientReference = "Client 1"

            };

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
                ApplicationNumber = "ApplicationNumber",
                ApplicationDate = DateTime.Now,
                PublicationDate = DateTime.Now,
                CertificateNumber = "CertificateNumber",
                CertificateDate = DateTime.Now,
                PCTApplicationNumber = "PCTApplicationNumber",
                PCTApplicationDate = DateTime.Now,
                PCTLanguageNumber = "PCTLanguageNumber",
                PCTLanguageDate = DateTime.Now,
                PCTPublicationNumber = "PCTPublicationNumber",
                PCTPublicationDate = DateTime.Now,
                PriorityNumber = "PriorityNumber",
                PriorityDate = DateTime.Now,
                PriorityCountryFilingId = 1,
                DateWithdrawn = DateTime.Now,
                ReasonOfWithdrawn = null,
                RenewalDate = null,
                RenewalDau = null,
            };

            return request;
        }
    }
}
