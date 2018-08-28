using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.WCF
{
    [ServiceContract]
    interface IApplicant
    {
        #region ApplicantEducation Contracts
        [OperationContract]
        void AddApplicantEducation(ApplicantEducationPoco[] items);
        [OperationContract]
        List<ApplicantEducationPoco> GetAllApplicantEducation();
        [OperationContract]
        ApplicantEducationPoco GetSingleApplicantEducation(Guid Id);
        [OperationContract]
        void RemoveApplicantEducation(ApplicantEducationPoco[] items);
        [OperationContract]
        void UpdateApplicantEducation(ApplicantEducationPoco[] items);
        #endregion ApplicantEducation Contracts

        #region ApplicantJobApplication Contracts
        [OperationContract]
        void AddApplicantJobApplication(ApplicantJobApplicationPoco[] items);
        [OperationContract]
        List<ApplicantJobApplicationPoco> GetAllApplicantJobApplication();
        [OperationContract]
        ApplicantJobApplicationPoco GetSingleApplicantJobApplication(Guid Id);
        [OperationContract]
        void RemoveApplicantJobApplication(ApplicantJobApplicationPoco[] items);
        [OperationContract]
        void UpdateApplicantJobApplication(ApplicantJobApplicationPoco[] items);
        #endregion ApplicantJobApplication Contracts

        #region ApplicantProfile Contracts
        [OperationContract]
        void AddApplicantProfile(ApplicantProfilePoco[] items);
        [OperationContract]
        List<ApplicantProfilePoco> GetAllApplicantProfile();
        [OperationContract]
        ApplicantProfilePoco GetSingleApplicantProfile(Guid Id);
        [OperationContract]
        void RemoveApplicantProfile(ApplicantProfilePoco[] items);
        [OperationContract]
        void UpdateApplicantProfile(ApplicantProfilePoco[] items);
        #endregion ApplicantProfile Contracts

        #region ApplicantResume Contracts
        [OperationContract]
        void AddApplicantResume(ApplicantResumePoco[] items);
        [OperationContract]
        List<ApplicantResumePoco> GetAllApplicantResume();
        [OperationContract]
        ApplicantResumePoco GetSingleApplicantResume(Guid Id);
        [OperationContract]
        void RemoveApplicantResume(ApplicantResumePoco[] items);
        [OperationContract]
        void UpdateApplicantResume(ApplicantResumePoco[] items);
        #endregion ApplicantResume Contracts

        #region ApplicantSkill Contracts
        [OperationContract]
        void AddApplicantSkill(ApplicantSkillPoco[] items);
        [OperationContract]
        List<ApplicantSkillPoco> GetAllApplicantSkill();
        [OperationContract]
        ApplicantSkillPoco GetSingleApplicantSkill(Guid Id);
        [OperationContract]
        void RemoveApplicantSkill(ApplicantSkillPoco[] items);
        [OperationContract]
        void UpdateApplicantSkill(ApplicantSkillPoco[] items);
        #endregion ApplicantSkill Contracts

        #region ApplicantWorkHistory Contracts
        [OperationContract]
        void AddApplicantWorkHistory(ApplicantWorkHistoryPoco[] items);
        [OperationContract]
        List<ApplicantWorkHistoryPoco> GetAllApplicantWorkHistory();
        [OperationContract]
        ApplicantWorkHistoryPoco GetSingleApplicantWorkHistory(Guid Id);
        [OperationContract]
        void RemoveApplicantWorkHistory(ApplicantWorkHistoryPoco[] items);
        [OperationContract]
        void UpdateApplicantWorkHistory(ApplicantWorkHistoryPoco[] items);
        #endregion ApplicantWorkHistory Contracts
    }
}
