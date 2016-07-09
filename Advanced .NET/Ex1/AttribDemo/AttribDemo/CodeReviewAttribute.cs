namespace AttribDemo
{
    [System.AttributeUsage(System.AttributeTargets.Class |
                       System.AttributeTargets.Struct,
                       AllowMultiple = true)]

    class CodeReviewAttribute : System.Attribute
    {
        public CodeReviewAttribute(string name, string date, bool codeApprove)
        {
            ReviewrName = name;
            ReviewDate = date;
            CodeApproved = codeApprove;
        }

        public string ReviewrName { get; }
        public string ReviewDate { get; }
        public bool CodeApproved { get; }
    }
}
