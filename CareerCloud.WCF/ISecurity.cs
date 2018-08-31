using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.WCF
{
    [ServiceContract(Name = "SecurityService")]
    interface ISecurity
    {
        #region SecurityLogin Contracts
        [OperationContract]
        void AddSecurityLogin(SecurityLoginPoco[] items);
        [OperationContract]
        List<SecurityLoginPoco> GetAllSecurityLogin();
        [OperationContract]
        SecurityLoginPoco GetSingleSecurityLogin(Guid Id);
        [OperationContract]
        void RemoveSecurityLogin(SecurityLoginPoco[] items);
        [OperationContract]
        void UpdateSecurityLogin(SecurityLoginPoco[] items);
        #endregion SecurityLogin Contracts

        #region SecurityLoginLog Contracts
        [OperationContract]
        void AddSecurityLoginLog(SecurityLoginsLogPoco[] items);
        [OperationContract]
        List<SecurityLoginsLogPoco> GetAllSecurityLoginLog();
        [OperationContract]
        SecurityLoginsLogPoco GetSingleSecurityLoginLog(Guid Id);
        [OperationContract]
        void RemoveSecurityLoginLog(SecurityLoginsLogPoco[] items);
        [OperationContract]
        void UpdateSecurityLoginLog(SecurityLoginsLogPoco[] items);
        #endregion SecurityLoginLog Contracts

        #region SecurityLoginsRole Contracts
        [OperationContract]
        void AddSecurityLoginsRole(SecurityLoginsRolePoco[] items);
        [OperationContract]
        List<SecurityLoginsRolePoco> GetAllSecurityLoginsRole();
        [OperationContract]
        SecurityLoginsRolePoco GetSingleSecurityLoginsRole(Guid Id);
        [OperationContract]
        void RemoveSecurityLoginsRole(SecurityLoginsRolePoco[] items);
        [OperationContract]
        void UpdateSecurityLoginsRole(SecurityLoginsRolePoco[] items);
        #endregion SecurityLoginsRole Contracts

        #region SecurityRole Contracts
        [OperationContract]
        void AddSecurityRole(SecurityRolePoco[] items);
        [OperationContract]
        List<SecurityRolePoco> GetAllSecurityRole();
        [OperationContract]
        SecurityRolePoco GetSingleSecurityRole(Guid Id);
        [OperationContract]
        void RemoveSecurityRole(SecurityRolePoco[] items);
        [OperationContract]
        void UpdateSecurityRolePoco(SecurityRolePoco[] items);
        #endregion SecurityRolePoco Contracts
    }
}
