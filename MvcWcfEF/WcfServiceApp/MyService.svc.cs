using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace WcfServiceApp
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "MyService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select MyService.svc or MyService.svc.cs at the Solution Explorer and start debugging.
    public class MyService : IMyService
    {
        public List<UserDetail> GetAllUser()
        {
            List<UserDetail> userlst = new List<UserDetail>();
            TestDBEntities tstDb = new TestDBEntities();
            var lstUsr = from k in tstDb.UserDetails select k;
            foreach (var item in lstUsr)
            {
                UserDetail usr = new UserDetail();
                usr.Id = item.Id;
                usr.Name = item.Name;
                usr.Email = item.Email;
                userlst.Add(usr);

            }

            return userlst;
        }

        public UserDetail GetAllUserById(int id)
        {

            TestDBEntities tstDb = new TestDBEntities();
            var lstUsr = from k in tstDb.UserDetails where k.Id == id select k;
            UserDetail usr = new UserDetail();
            foreach (var item in lstUsr)
            {

                usr.Id = item.Id;
                usr.Name = item.Name;
                usr.Email = item.Email;


            }

            return usr;
        }

        public int DeleteUserById(int Id)
        {

            TestDBEntities tstDb = new TestDBEntities();
            UserDetail usrdtl = new UserDetail();
            usrdtl.Id = Id;
            tstDb.Entry(usrdtl).State = EntityState.Deleted;
            int Retval = tstDb.SaveChanges();
            return Retval;
        }

        public int AddUser(string Name, string Email)
        {
            TestDBEntities tstDb = new TestDBEntities();
            UserDetail usrdtl = new UserDetail();
            usrdtl.Name = Name;
            usrdtl.Email = Email;
            tstDb.UserDetails.Add(usrdtl);
            int Retval = tstDb.SaveChanges();
            return Retval;
        }

        public int UpdateUser(int Id, string Name, string Email)
        {
            TestDBEntities tstDb = new TestDBEntities();
            UserDetail usrdtl = new UserDetail();
            usrdtl.Id = Id;
            usrdtl.Name = Name;
            usrdtl.Email = Email;
            tstDb.Entry(usrdtl).State = EntityState.Modified;
            int Retval = tstDb.SaveChanges();
            return Retval;
        }

    }
}
