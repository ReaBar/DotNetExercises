namespace AttribDemo
{
    [System.AttributeUsage(System.AttributeTargets.Class |
                       System.AttributeTargets.Struct,
                       AllowMultiple = true)]

    class CodeReviewAttribute : System.Attribute
    {
        private readonly string _reviewName;
        private readonly string _reviewDate;
        private readonly bool _codeApproved;

        public CodeReviewAttribute(string name, string date, bool codeApprove)
        {
            _reviewName = name;
            _reviewDate = date;
            _codeApproved = codeApprove;
        }

        public string ReviewrName => _reviewName;
        public string ReviewDate => _reviewDate;
        public bool CodeApproved => _codeApproved;
    }
}
