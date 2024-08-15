namespace Deol.ASTM.LabOnline
{
    //1     Record Type
    //2     Sequence Number
    //3     Universal Test ID
    //4     Measurement Value
    //5     Units
    //6     Reference Ranges
    //7     Result Abnormal Flags
    //8     Nature of Abnormality Testing
    //9     Result Status
    //10    Date of Change in Instrument Normative Values or Units
    //11    Operator Identification
    //12    Date/Time Test Starter
    //13    Date/Time Test Completed
    //14    Instrument Identification

    public class ASTMResult : ASTMRecord
    {
        public override char RecordType => 'R';

        public ASTMList<ASTMComment>? Comments { get; set; }

        #region Protocol

        //3 Universal Test ID
        public ASTMTestId? TestId { get; set; }

        private string? TestIdProtocol => TestId?.ToString();

        //4 Measurement Value
        public string? Value { get; set; }

        //5 Units
        public string? Units { get; set; }

        //6 Reference Ranges
        public string? ReferenceRanges { get; set; }

        //7 Result Abnormal Flags
        public ASTMResultNormality? Normality { get; set; }

        private string? NormalityProtocol => Normality.HasValue ? ((int)Normality.Value).ToString() : null;

        //8 Nature of Abnormality Testing
        public string? NatureOfAbnormalityTesting { get; set; }

        //9 Result Status
        public ASTMResultStatus? ResultStatus { get; set; }

        private string? ResultStatusProtocol => ResultStatus?.ToString();

        //11 Operator Identification
        public ASTMOperatorId? OperatorId { get; set; }

        private string? OperatorIdProtocol => OperatorId?.ToString();

        //12 Date/Time Test Starter
        public DateTime? StartDate { get; set; }

        private string? StartDateProtocol => StartDate?.ToString(Consts.FullDateFormat);

        //13 Date/Time Test Completed
        public DateTime? ValidationDate { get; set; }

        public DateTime? CompletedDate { get; set; }

        private string? CompletedDateProtocol
        {
            get
            {
                if (CompletedDate == null)
                    return null;

                if (ValidationDate != null)
                    return $"{CompletedDate?.ToString(Consts.FullDateFormat)}^{ValidationDate?.ToString(Consts.FullDateFormat)}";

                return $"{CompletedDate?.ToString(Consts.FullDateFormat)}";
            }
        }

        //14 Instrument Identification
        public ASTMInstrumentId? InstrumentId { get; set; }

        private string? InstrumentIdProtocol => InstrumentId?.ToString();

        #endregion

        #region Get fields

        public override string?[] GetFields() =>
        [
            /*3*/TestIdProtocol,
            /*4*/Value,
            /*5*/Units,
            /*6*/ReferenceRanges,
            /*7*/NormalityProtocol,
            /*8*/NatureOfAbnormalityTesting,
            /*9*/ResultStatusProtocol,
            /*10*/null,
            /*11*/OperatorIdProtocol,
            /*12*/StartDateProtocol,
            /*13*/CompletedDateProtocol,
            /*14*/InstrumentIdProtocol
        ];

        #endregion
    }

    public enum ASTMResultNormality
    {
        Normal = 0,
        OutOfNormalValues = 1,
        OutOfAttentionValues = 2,
        OutOfPanicValues = 3
    }

    public enum ASTMResultStatus
    {
        F = 0, //final result
        R = 1  //rerun
    }

    public readonly struct ASTMOperatorId(string code)
    {
        public readonly string Code { get; } = code;
        public readonly string? Code1 { get; }
        public readonly string? Code2 { get; }

        public ASTMOperatorId(string code, string? code1, string? code2) : this(code)
        {
            Code1 = code1;
            Code2 = code2;
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(Code2))
                return $"{Code}^{Code1}^{Code2}";

            if (!string.IsNullOrEmpty(Code1))
                return $"{Code}^{Code1}";

            return Code;
        }
    }

    public class ASTMInstrumentId(ASTMInstrumentActionType actionType, string code) : ASTMFieldSet
    {
        private readonly ASTMInstrumentActionType _actionType = actionType;

        public string Code { get; set; } = code;
        public string? SerialNumber { get; set; }
        public string? RackBarcode { get; set; }
        public string? TubePosition { get; set; }
        public string? RackLocation { get; set; }
        public string? BayNumber { get; set; }
        public string? ProcessPathId { get; set; }
        public string? ProcessingLaneId { get; set; }


        public override char Separator => '^';

        public override string?[] GetFields() => _actionType switch
        {
            ASTMInstrumentActionType.Normal => [Code, null, SerialNumber, RackBarcode, TubePosition, RackLocation, BayNumber, ProcessPathId, ProcessingLaneId],
            ASTMInstrumentActionType.QPL    => ["QPL", Code, SerialNumber, RackBarcode, TubePosition, RackLocation, BayNumber, ProcessPathId, ProcessingLaneId],
            ASTMInstrumentActionType.Edit   => ["Edit", Code, SerialNumber, RackBarcode, TubePosition, RackLocation, BayNumber, ProcessPathId, ProcessingLaneId],
            _ => []
        };
    }

    public enum ASTMInstrumentActionType
    {
        Normal = 1,
        QPL = 2,
        Edit = 3
    }
}
