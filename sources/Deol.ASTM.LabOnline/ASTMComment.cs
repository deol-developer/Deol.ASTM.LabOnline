namespace Deol.ASTM.LabOnline
{
    //Comment Record
    //Number    Name               Values       Comments               Options
    //1         Record Type ID     C                                   M
    //2         Sequence Number    1            Sequence Number        M
    //3         Comment Source     I            Always I               M
    //4         Comment Text       CK^APS^Text  Code^Text1^…^TextN     M
    //5         Comment Type       G            Fixed value            M

    public class ASTMComment : ASTMRecord
    {
        public override char RecordType => 'C';

        public string? Code { get; set; }

        public ASTMList<string> Text { get; } = [];

        private string? CommentProtocol
        {
            get
            {
                if (Text.Count == 0)
                    return Code;

                return $"{Code}^{string.Join('^', Text)}";
            }
        }

        public override string?[] GetFields() => 
        [
            "I",
            CommentProtocol,
            "G"
        ];
    }
}
