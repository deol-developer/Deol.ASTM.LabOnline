namespace Deol.ASTM.LabOnline
{
    public abstract class ASTMFieldSet
    {
        public abstract char Separator { get; }

        public abstract string?[] GetFields();

        public override string ToString()
        {
            var fields = GetFields();
            
            int index = GetLastNotEmptyIndex(fields);

            if (index == -1)
                return "";

            return $"{string.Join(Separator, fields, 0, index + 1)}";

            static int GetLastNotEmptyIndex(string?[] strings)
            {
                for (var i = strings.Length - 1; i >= 0; i--)
                {
                    if (!string.IsNullOrEmpty(strings[i]))
                        return i;
                }

                return -1;
            }
        }
    }
    
    public abstract class ASTMRecord : ASTMFieldSet
    {
        public override char Separator => '|';

        //1 Record Type
        public abstract char RecordType { get; }

        //2 Sequence Number
        public virtual string ToString(int number)
        {
            var str = ToString();
            
            if (string.IsNullOrEmpty(str))
                return $"{RecordType}|{number}";

            return $"{RecordType}|{number}|{str}";
        }
    }
}
