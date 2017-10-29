using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;


namespace WcfServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name 
    //       "MyService" in code, svc and config file together.  
    // NOTE: In order to launch WCF Test Client for testing this service, please select 
    //       MyService.svc or MyService.svc.cs at the Solution Explorer and start debugging.
    [ServiceContract]
    public interface IMyService
    {
        [OperationContract]
        List<UserDetail> GetAllUser();
        [OperationContract]
        int AddUser(string Name, string Email);
        [OperationContract]
        UserDetail GetAllUserById(int id);

        [OperationContract]
        int UpdateUser(int Id, string Name, string Email);

        [OperationContract]
        int DeleteUserById(int Id);
    }

    [DataContract]
    public class UserDetails
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Email { get; set; }
    }

}
