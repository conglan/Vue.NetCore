using VOL.Core.Enums;
using System;

namespace VOL.Core.Extensions
{
    public static class CacheKeyExtensions
    {
        public static string GetKey(this CPrefix prefix, object value)
        {
            return prefix.ToString() + value;
        }

        public static string GetUserIdKey(this Guid userId)
        {
            return CPrefix.UID.ToString() + userId;
        }

        public static string GetRoleIdKey(this Guid roleId)
        {
            return CPrefix.Role.ToString() + roleId;
        }
    }
}
