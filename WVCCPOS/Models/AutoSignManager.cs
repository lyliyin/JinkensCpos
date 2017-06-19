using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Threading.Tasks;

namespace WVCCPOS.Models
{
    public class AutoSignManager
    {
        public class MyUserInfo : IUser<Guid>
        {
            public Guid Id
            {
                get
                {
                    throw new NotImplementedException();
                }
            }

            public string UserName
            {
                get
                {
                    throw new NotImplementedException();
                }

                set
                {
                    throw new NotImplementedException();
                }
            }
        }
        public class IUserStoreImpl : IUserStore<MyUserInfo, Guid>
        {
            public Task CreateAsync(MyUserInfo user)
            {
                throw new NotImplementedException();
            }

            public Task DeleteAsync(MyUserInfo user)
            {
                throw new NotImplementedException();
            }

            public void Dispose()
            {
                throw new NotImplementedException();
            }

            public Task<MyUserInfo> FindByIdAsync(Guid userId)
            {
                throw new NotImplementedException();
            }

            public Task<MyUserInfo> FindByNameAsync(string userName)
            {
                throw new NotImplementedException();
            }

            public Task UpdateAsync(MyUserInfo user)
            {
                throw new NotImplementedException();
            }
        }
    }
}