using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    /// <summary>
    /// 用户角色信息
    /// </summary>
    public class UserRoleReq
    {
        public string UserId { get; set; }
        public string MenuId { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string RoleCode { get; set; }
        public string UserName { get; set; }
        public string UserPhone { get; set; }
        public string UserEmail { get; set; }
        public string MenuName { get; set; }
        public string MenuCode { get; set; }
    }
}
