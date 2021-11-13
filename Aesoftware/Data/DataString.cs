﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aesoftware.Data
{
    public enum Flag
    {
        LOGIN_SUCCESS,
        LOGIN_USER_DOES_NOT_EXIST,
        LOGIN_INVALID_PASSWORD,
        LOGIN_WRONG_MACHINE,
        REGISTER_SUCCESS,
        REGISTER_EMPTY_FIELD,
        REGISTER_USER_ALREADY_EXIST,
        REGISTER_INVALID_INVITE,
        REGISTER_ACCOUNT_WITH_MACHINE_EXIST,
    }
    public class DataString
    {
        public const string QuerySelectAccount = "SELECT * FROM Account";
        public const string QuerySelectInvite = "SELECT * FROM Invite";
        public const string QuerySelectModule = "SELECT * FROM Module";
        public const string QuerySelectModulePermission = "SELECT * FROM ModulePermission";
        public const string QuerySelectRole = "SELECT * FROM Role";
        public const string QuerySelectConnection = "SELECT * FROM Connection";
    }
}
