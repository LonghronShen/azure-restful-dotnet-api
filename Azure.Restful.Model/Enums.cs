using System;

namespace Azure.Restful.Model
{
    [Flags]
    public enum Enums
    {
        None = 0,
        Create = 1,
        Get = 2,
        Update = 4,
        Delete = 8,
        List = 16,
        Others = 32,
        /// <summary>
        /// Create, Update
        /// </summary>
        CU = 5,
        /// <summary>
        /// Create, Get, Update, Delete
        /// </summary>
        CGUD = 15,
        /// <summary>
        /// Create,Update, List 
        /// </summary>
        CUL = 21,
        /// <summary>
        /// Create, Get, Update, Delete, List
        /// </summary>
        CGUDL = 31,
        All = 63
    }
}
