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
    interface ISystem
    {
        #region SystemCountryCode Contracts
        [OperationContract]
        void AddSystemCountryCode(SystemCountryCodePoco[] items);
        [OperationContract]
        List<SystemCountryCodePoco> GetAllSystemCountryCode();
        [OperationContract]
        SystemCountryCodePoco GetSingleSystemCountryCode(string Id);
        [OperationContract]
        void RemoveSystemCountryCode(SystemCountryCodePoco[] items);
        [OperationContract]
        void UpdateSystemCountryCode(SystemCountryCodePoco[] items);
        #endregion SystemCountryCode Contracts

        #region SystemLanguageCode Contracts
        [OperationContract]
        void AddSystemLanguageCode(SystemLanguageCodePoco[] items);
        [OperationContract]
        List<SystemLanguageCodePoco> GetAllSystemLanguageCode();
        [OperationContract]
        SystemLanguageCodePoco GetSingleSystemLanguageCode(string Id);
        [OperationContract]
        void RemoveSystemLanguageCode(SystemLanguageCodePoco[] items);
        [OperationContract]
        void UpdateSystemLanguageCode(SystemLanguageCodePoco[] items);
        #endregion SystemLanguageCode Contracts
    }
}
