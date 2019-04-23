using System;

namespace timesheet.model
{
    internal class IndexAttribute : Attribute
    {
        private string v;
        private bool IsUnique;

        public IndexAttribute(string v, bool IsUnique)
        {
            this.v = v;
            this.IsUnique = IsUnique;
        }
    }
}